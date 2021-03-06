using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Producer
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {

        }

        private void btnDeclareQueue_Click(object sender, EventArgs e)
        {

        }

        private void btnDeclareExchange_Click(object sender, EventArgs e)
        {

        }

        private void btnBindQueue_Click(object sender, EventArgs e)
        {

        }

        private void btnPublish_Click(object sender, EventArgs e)
        {

        }

        private void ConnectionStateChanged()
        {
            btnConnect.Text = isConnectionOpen ? "Disconnect" : "Connect";
        }

        private void UpdateConnectionStatus()
        {
            string state = $"{(isConnectionOpen ? "" : "Not")} Connected";
            tsLblConnectionStatus.Text = $"Connection State:{state}";
            AddLog($"Connecction state is {state}");
        }
    }
}
