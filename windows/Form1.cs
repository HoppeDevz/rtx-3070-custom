using System;
using System.Windows.Forms;

using rtx_display.Helpers;

namespace rtx_display
{
    public partial class Form1 : Form
    {

        public static Form windowRef;
        public static NotifyIcon systemTrayIcon = new NotifyIcon();
        public static SystemTrayManager systemTrayManager;

        public Form1()
        {
            InitializeComponent();
            windowRef = this;
        }

        private void initializeSystemTrayIcon()
        {
            systemTrayManager = new SystemTrayManager(windowRef, systemTrayIcon);
            systemTrayManager.createSystemTrayIcon();

            systemTrayIcon.MouseDoubleClick += new MouseEventHandler(SystemTrayIcon_MouseDoubleClick);
        }

        private void SystemTrayIcon_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            this.Show();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            CheckForIllegalCrossThreadCalls = false;

            threadIndicatorLabel.Text = "";

            initializeSystemTrayIcon();
            NVIDIAHelper.StartGpuThread(gpuUsageLabel, gpuTempLabel, threadIndicatorLabel);
        }

        private void Form1_Resize(object sender, EventArgs e)
        {

            if (WindowState == FormWindowState.Minimized)
            {
                this.Hide();
            }
        }
    }
}
