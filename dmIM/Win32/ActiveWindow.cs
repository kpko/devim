using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace dmIM.Win32
{
    class ActiveWindow
    {
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        static extern IntPtr GetForegroundWindow();

        private static bool IsActive(Form form)
        {
            // workaround for minimization bug
            // Managed .IsActive may return wrong value
            if (form == null) return false;

            return GetForegroundWindow() == form.Handle;
        }

        public static bool IsApplicationActive()
        {
            foreach (var form in Application.OpenForms.Cast<Form>())
                if (IsActive(form)) return true;
            return false;
        }
    }
}
