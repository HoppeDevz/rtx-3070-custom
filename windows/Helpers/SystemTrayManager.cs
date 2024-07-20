using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace rtx_display.Helpers
{
    public class SystemTrayManager
    {

        private Form window;
        private NotifyIcon icon;

        public SystemTrayManager(Form window, NotifyIcon icon)
        {
            this.window = window;
            this.icon = icon;
        }

        public void createSystemTrayIcon()
        {
            try
            {

                this.icon.Icon = this.window.Icon;
                this.icon.Visible = true;

            }
            catch
            {

                throw;
            }
        }

    }
}
