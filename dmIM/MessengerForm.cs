using System;
using System.Collections.Concurrent;
using System.Net;
using System.Net.Sockets;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;
using dmIM.Win32;
using System.Media;
using System.Reflection;

namespace dmIM
{
    public partial class MessengerForm : Form
    {
        private bool IsServer;
        private TcpListener _listener;
        private TcpClient _client;

        private bool _stopping;
        private readonly ConcurrentDictionary<string, LocalClient> _clients = new ConcurrentDictionary<string, LocalClient>();
        private StreamWriter sw;
        private StreamReader sr;
        private bool _disposing;
        private string Password
        {
            get { return EncryptionKeyTextBox.Text; }
        }

        public MessengerForm()
        {
            InitializeComponent();
        }

        private void ConnectButton_Click(object sender, EventArgs e)
        {
            ConnectButton.Enabled = false;
            HostTextBox.Enabled = false;
            MessageTextBox.Enabled = true;

            if (String.IsNullOrEmpty(HostTextBox.Text))
            {
                IsServer = true;
                Listen();
            }
            else
            {
                IsServer = false;
                Connect(HostTextBox.Text);
            }
        }

        private void DisconnectButton_Click(object sender, EventArgs e)
        {
            ConnectButton.Enabled = true;
            HostTextBox.Enabled = true;
            MessageTextBox.Enabled = false;

            Disconnect();
        }

        private void MessageTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && !e.Shift)
            {

                string actualMessage = MessageTextBox.Text
                    .Replace(":tf:", "(╯°□°)╯︵ ┻━┻")
                    .Replace(":dunno:", @"¯\_(ツ)_/¯")
                    .Replace(":srs:", "ಠ_ಠ");

                Log(actualMessage, "You");

                string encrypted = StringCipher.Encrypt(actualMessage, Password);
                SendMessage(encrypted);

                e.SuppressKeyPress = true;
                MessageTextBox.Clear();
            }
        }

        private async void Connect(string host)
        {
            _client = new TcpClient();
            await _client.ConnectAsync(host, 6666);

            if (_client.Connected)
            {
                Log(String.Format("Connected to {0}", host), "System");
                sr = new StreamReader(_client.GetStream());
                StartReceive();
            }
        }
        public async void StartReceive()
        {
            try
            {
                while (true)
                {
                    if (sr == null) return;
                    var message = await sr.ReadLineAsync();

                    if (message == null)
                    {
                        return;
                    }

                    ReceivedMessage(message, "other");
                }
            }
            catch (ArgumentOutOfRangeException)
            {
                if (!_disposing)
                    Console.WriteLine("ArgumentOutOfRangeException");
            }
            catch (ObjectDisposedException)
            {
                if (!_disposing)
                    Console.WriteLine("ObjectDisposedException");
            }
            catch (InvalidOperationException)
            {
                if (!_disposing)
                    Console.WriteLine("InvalidOperationException");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
        private async void Listen()
        {
            try
            {
                _listener = new TcpListener(IPAddress.Any, 6666);
                _listener.Start();
                while (!_stopping)
                {
                    try
                    {
                        Log("Listening...");
                        var client = await _listener.AcceptTcpClientAsync();

                        if (client == null) break;

                        Log("Client connected");
                        var id = Guid.NewGuid().ToString();
                        if (_clients.TryAdd(id, new LocalClient(client, ReceivedMessage, ClientClosed, id))) continue;

                        Log("Client {0} already exists in dictionary", id);
                        client.Close();
                    }
                    catch (InvalidOperationException)
                    {
                        if (!_stopping)
                        {
                            Log("InvalidOperationException");
                        }
                        break;
                    }
                    catch (SocketException ex)
                    {

                        if (!_stopping)
                        {
                            Log("SocketException");
                            Log(ex.Message);
                        }
                        break;
                    }
                    catch (Exception ex)
                    {
                        Log(ex.Message);
                        break;
                    }
                }
            }
            catch (Exception ex)
            {
                Log(ex.Message);
            }

            _stopping = false;
        }

        private void Disconnect()
        {
            if (IsServer)
            {
                _stopping = true;
                _listener.Stop();
                foreach (var client in _clients.Values)
                {
                    if (client.Client.Connected)
                        client.Client.Close();
                }
            }
            else
            {
                _client.Close();
                sw.Dispose();
                sw = null;
            }
        }

        private async void SendMessage(string message)
        {
            if (IsServer)
            {
                foreach (var client in _clients.Values)
                {
                    client.Send(message);
                }
            }
            else
            {
                if (!String.IsNullOrEmpty(MessageTextBox.Text))
                {
                    if (sw == null)
                    {
                        var stream = _client.GetStream();
                        sw = new StreamWriter(stream);
                        sw.AutoFlush = true;
                    }
                    await sw.WriteLineAsync(message);
                }
            }
        }
        private void Log(string message, string sender = "")
        {
            LogTextBox.AppendText(String.Format("{0:HH:mm:ss} {1}: {2}\r\n", DateTime.Now, sender, message));
        }

        public void ClientClosed(LocalClient client)
        {
            Console.WriteLine("Client {0} disconnected", client.Id);

            LocalClient tempLocalClient;
            _clients.TryRemove(client.Id, out tempLocalClient);
            client.Dispose();

            Console.WriteLine("Client {0} Closed", client.Id);
            ReceivedMessage("Client disconnected", client.Id);
        }

        public void ReceivedMessage(string message, string id)
        {
            try
            {
                string msg = "";
                try
                {
                    msg = StringCipher.Decrypt(message, Password);
                }
                catch
                {
                    msg = message;
                }
                this.SafeInvoke(form => form.Log(msg, "Other"));
                this.SafeInvoke(form => form.NotifyUser());
            }
            catch (Exception ex)
            {
                Log(ex.Message);
            }
        }

        private void NotifyUser()
        {
            if (!ActiveWindow.IsApplicationActive())
            {
                if (BeepCheckBox.Checked)
                {
                    using (var stream = Assembly.GetExecutingAssembly().GetManifestResourceStream("dmIM.notif.wav"))
                    {
                        using (SoundPlayer sp = new SoundPlayer(stream))
                        {
                            sp.Play();
                        }
                    }
                }

                if (FlashCheckBox.Checked)
                {
                    FlashWindow.FlashWindowEx(this);
                }
            }
        }

        private void MessengerForm_Load(object sender, EventArgs e)
        {
            this.ShowInTaskbar = true;
        }

        private void MessengerForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.Shift && e.KeyCode == Keys.C)
            {
                LogTextBox.Clear();
                HostTextBox.Clear();
            }

            if (e.Control && e.Shift && e.KeyCode == Keys.D)
            {
                this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
                this.WindowState = FormWindowState.Minimized;
                this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable;

                this.FlashCheckBox.Checked = false;
                this.BeepCheckBox.Checked = false;
            }

            if (e.Control && e.Shift && e.KeyCode == Keys.S)
            {
                SettingsPanel.Visible = !SettingsPanel.Visible;
            }
        }

        private void OpacityTrackBar_Scroll(object sender, EventArgs e)
        {
            this.Opacity = (OpacityTrackBar.Value / 100d);
        }
    }

    public class LocalClient : IDisposable
    {
        private readonly TcpClient _client;
        public TcpClient Client { get { return _client; } }

        private readonly Action<LocalClient> _closedCallback;
        private readonly Action<string, string> _recvCallback;

        private readonly StreamReader _reader;
        private readonly StreamWriter _writer;

        private readonly string _id;
        public string Id { get { return _id; } }

        private bool _disposing;

        public LocalClient(TcpClient client, Action<string, string> recvCallback, Action<LocalClient> closedCallback, string id)
        {
            _closedCallback = closedCallback;
            try
            {
                _client = client;
                _recvCallback = recvCallback;
                _id = id;

                _reader = new StreamReader(_client.GetStream());
                _writer = new StreamWriter(_client.GetStream()) { AutoFlush = true };

                StartReceive();

                Console.WriteLine("Local client {0} receiving...", id);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        public async void StartReceive()
        {
            try
            {
                while (true)
                {
                    if (_reader == null) return;

                    var message = await _reader.ReadLineAsync();
                    if (message == null)
                    {
                        await Task.Run(() => _closedCallback(this));
                        return;
                    }

                    _recvCallback(message, _id);
                    Console.WriteLine("{0} > {1}", _id, message);
                }
            }
            catch (ArgumentOutOfRangeException)
            {
                if (!_disposing)
                    Console.WriteLine("ArgumentOutOfRangeException");
            }
            catch (ObjectDisposedException)
            {
                if (!_disposing)
                    Console.WriteLine("ObjectDisposedException");
            }
            catch (InvalidOperationException)
            {
                if (!_disposing)
                    Console.WriteLine("InvalidOperationException");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        public async void Send(string message)
        {
            try
            {
                if (String.IsNullOrEmpty(message)) return;
                if (_writer == null) return;

                await _writer.WriteLineAsync(message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        public void Dispose()
        {
            _disposing = true;

            if (_reader != null)
                _reader.Dispose();
            if (_writer != null)
                _writer.Dispose();
        }
    }
}
