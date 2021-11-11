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
        #region Variables

        private bool _isConnectionOpen;
        private bool isConnectionOpen
        {
            get => _isConnectionOpen;

            set
            {
                _isConnectionOpen = value;
                ConnectionStateChanged();
            }
        }

        //private IConnection connection;

        //private IModel _channel;
        //private IModel channel => _channel ?? (_channel = CreateOrGetChannel());

        #endregion

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

        #region App Methods
        private void ConnectionStateChanged()
        {
            btnConnect.Text = isConnectionOpen ? "Disconnect" : "Connect";
            UpdateConnectionStatus();
            pnlMain.Enabled = gbQueueExchange.Enabled = isConnectionOpen;
        }

        private void UpdateConnectionStatus()
        {
            string state = $"{(isConnectionOpen ? "" : "Not")} Connected";
            tsLblConnectionStatus.Text = $"Connection State:{state}";
            AddLog($"Connecction state is {state}");
        }

        private void AddLog(string logStr)
        {
            logStr = $"[{DateTime.Now:dd.MM.yyyy HH:mm:ss}]-{logStr}";
            txtLog.AppendText($"{logStr}\n");

            //set the cursor to end
            txtLog.SelectionStart = txtLog.Text.Length;
            txtLog.ScrollToCaret();
        }






        #endregion


    }
}
