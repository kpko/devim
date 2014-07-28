namespace dmIM
{
    partial class MessengerForm
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.HostTextBox = new System.Windows.Forms.TextBox();
            this.ConnectButton = new System.Windows.Forms.Button();
            this.DisconnectButton = new System.Windows.Forms.Button();
            this.LogTextBox = new System.Windows.Forms.TextBox();
            this.MessageTextBox = new System.Windows.Forms.TextBox();
            this.EncryptionKeyTextBox = new System.Windows.Forms.TextBox();
            this.SettingsPanel = new System.Windows.Forms.Panel();
            this.BeepCheckBox = new System.Windows.Forms.CheckBox();
            this.FlashCheckBox = new System.Windows.Forms.CheckBox();
            this.SettingsPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // HostTextBox
            // 
            this.HostTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.HostTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.HostTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.HostTextBox.ForeColor = System.Drawing.Color.Gainsboro;
            this.HostTextBox.Location = new System.Drawing.Point(14, 14);
            this.HostTextBox.Name = "HostTextBox";
            this.HostTextBox.Size = new System.Drawing.Size(279, 23);
            this.HostTextBox.TabIndex = 0;
            // 
            // ConnectButton
            // 
            this.ConnectButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ConnectButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.ConnectButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ConnectButton.Location = new System.Drawing.Point(299, 14);
            this.ConnectButton.Name = "ConnectButton";
            this.ConnectButton.Size = new System.Drawing.Size(68, 23);
            this.ConnectButton.TabIndex = 1;
            this.ConnectButton.Text = "Connect";
            this.ConnectButton.UseVisualStyleBackColor = true;
            this.ConnectButton.Click += new System.EventHandler(this.ConnectButton_Click);
            // 
            // DisconnectButton
            // 
            this.DisconnectButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.DisconnectButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.DisconnectButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.DisconnectButton.Location = new System.Drawing.Point(373, 14);
            this.DisconnectButton.Name = "DisconnectButton";
            this.DisconnectButton.Size = new System.Drawing.Size(87, 23);
            this.DisconnectButton.TabIndex = 2;
            this.DisconnectButton.Text = "Disconnect";
            this.DisconnectButton.UseVisualStyleBackColor = true;
            this.DisconnectButton.Click += new System.EventHandler(this.DisconnectButton_Click);
            // 
            // LogTextBox
            // 
            this.LogTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.LogTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.LogTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.LogTextBox.ForeColor = System.Drawing.Color.Gainsboro;
            this.LogTextBox.Location = new System.Drawing.Point(14, 74);
            this.LogTextBox.Multiline = true;
            this.LogTextBox.Name = "LogTextBox";
            this.LogTextBox.ReadOnly = true;
            this.LogTextBox.Size = new System.Drawing.Size(446, 256);
            this.LogTextBox.TabIndex = 5;
            // 
            // MessageTextBox
            // 
            this.MessageTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.MessageTextBox.AutoCompleteCustomSource.AddRange(new string[] {
            ":tf:",
            ":dunno:"});
            this.MessageTextBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.MessageTextBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.MessageTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.MessageTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.MessageTextBox.Enabled = false;
            this.MessageTextBox.ForeColor = System.Drawing.Color.Gainsboro;
            this.MessageTextBox.Location = new System.Drawing.Point(14, 337);
            this.MessageTextBox.Multiline = true;
            this.MessageTextBox.Name = "MessageTextBox";
            this.MessageTextBox.Size = new System.Drawing.Size(446, 74);
            this.MessageTextBox.TabIndex = 4;
            this.MessageTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MessageTextBox_KeyDown);
            // 
            // EncryptionKeyTextBox
            // 
            this.EncryptionKeyTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.EncryptionKeyTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.EncryptionKeyTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.EncryptionKeyTextBox.ForeColor = System.Drawing.Color.Gainsboro;
            this.EncryptionKeyTextBox.Location = new System.Drawing.Point(14, 44);
            this.EncryptionKeyTextBox.Name = "EncryptionKeyTextBox";
            this.EncryptionKeyTextBox.PasswordChar = '*';
            this.EncryptionKeyTextBox.Size = new System.Drawing.Size(446, 23);
            this.EncryptionKeyTextBox.TabIndex = 3;
            // 
            // SettingsPanel
            // 
            this.SettingsPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.SettingsPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.SettingsPanel.Controls.Add(this.FlashCheckBox);
            this.SettingsPanel.Controls.Add(this.BeepCheckBox);
            this.SettingsPanel.Location = new System.Drawing.Point(14, 74);
            this.SettingsPanel.Name = "SettingsPanel";
            this.SettingsPanel.Size = new System.Drawing.Size(446, 256);
            this.SettingsPanel.TabIndex = 6;
            this.SettingsPanel.Visible = false;
            // 
            // BeepCheckBox
            // 
            this.BeepCheckBox.AutoSize = true;
            this.BeepCheckBox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BeepCheckBox.Location = new System.Drawing.Point(7, 3);
            this.BeepCheckBox.Name = "BeepCheckBox";
            this.BeepCheckBox.Size = new System.Drawing.Size(289, 19);
            this.BeepCheckBox.TabIndex = 0;
            this.BeepCheckBox.Text = "Beep on new message (when not focused)";
            this.BeepCheckBox.UseVisualStyleBackColor = true;
            // 
            // FlashCheckBox
            // 
            this.FlashCheckBox.AutoSize = true;
            this.FlashCheckBox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.FlashCheckBox.Location = new System.Drawing.Point(7, 22);
            this.FlashCheckBox.Name = "FlashCheckBox";
            this.FlashCheckBox.Size = new System.Drawing.Size(296, 19);
            this.FlashCheckBox.TabIndex = 0;
            this.FlashCheckBox.Text = "Flash on new message (when not focused)";
            this.FlashCheckBox.UseVisualStyleBackColor = true;
            // 
            // MessengerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.ClientSize = new System.Drawing.Size(474, 422);
            this.Controls.Add(this.SettingsPanel);
            this.Controls.Add(this.EncryptionKeyTextBox);
            this.Controls.Add(this.MessageTextBox);
            this.Controls.Add(this.LogTextBox);
            this.Controls.Add(this.DisconnectButton);
            this.Controls.Add(this.ConnectButton);
            this.Controls.Add(this.HostTextBox);
            this.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.Gainsboro;
            this.KeyPreview = true;
            this.Name = "MessengerForm";
            this.Load += new System.EventHandler(this.MessengerForm_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MessengerForm_KeyDown);
            this.SettingsPanel.ResumeLayout(false);
            this.SettingsPanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox HostTextBox;
        private System.Windows.Forms.Button ConnectButton;
        private System.Windows.Forms.Button DisconnectButton;
        private System.Windows.Forms.TextBox LogTextBox;
        private System.Windows.Forms.TextBox MessageTextBox;
        private System.Windows.Forms.TextBox EncryptionKeyTextBox;
        private System.Windows.Forms.Panel SettingsPanel;
        private System.Windows.Forms.CheckBox BeepCheckBox;
        private System.Windows.Forms.CheckBox FlashCheckBox;
    }
}

