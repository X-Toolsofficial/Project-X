using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project_X
{
    public partial class Form1 : Form
    {
        bool mousedown;
        public Form1()
        {
            InitializeComponent();
            guna2GradientPanel1.MouseDown += panel1_MouseDown;
            guna2GradientPanel1.MouseMove += panel1_MouseMove;
        }

        private Point mouseOffset;

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                mouseOffset = new Point(-e.X, -e.Y);
            }
        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Point mousePos = Control.MousePosition;
                mousePos.Offset(mouseOffset.X, mouseOffset.Y);
                Location = mousePos;
            }
        }

        private void guna2GradientCircleButton1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void guna2GradientCircleButton2_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void guna2CircleButton1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void guna2ToggleSwitch3_CheckedChanged(object sender, EventArgs e)
        {
            if (guna2ToggleSwitch3.Checked)
            {
                EnableWiFi();
            }
            else
            {
                DisableWiFi();
            }
        }

        private void DisableWiFi()
        {
            NetworkInterface[] adapters = NetworkInterface.GetAllNetworkInterfaces();
            foreach (NetworkInterface adapter in adapters)
            {
                if (adapter.NetworkInterfaceType == NetworkInterfaceType.Wireless80211)
                {
                    Process.Start("netsh", $"interface set interface name=\"{adapter.Name}\" admin=disable");
                }
            }
        }

        private void EnableWiFi()
        {
            Process.Start("netsh", "interface set interface admin=enable");
        }

        private void guna2CircleButton2_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized | FormWindowState.Normal;
        }

        private void guna2GradientPanel1_Paint(object sender, PaintEventArgs e)
        {
           guna2ShadowForm1.SetShadowForm(this);
        }
    }
}
