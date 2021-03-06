using RabbitMQ.Client;
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

        private IModel _channel;
        private IModel channel => _channel ??(_channel = CreateOrGetChannel()); //singleton pattern

        IConnection connection;


        #endregion

        public Form1()
        {
            InitializeComponent();
            Init();
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            if (!isConnectionOpen || connection==null)
            {
                connection = GetConnection();
            }
            else
                connection.Close();
            isConnectionOpen = connection.IsOpen;
        }
        private void btnDeclareQueue_Click(object sender, EventArgs e)
        {
            channel.QueueDeclare(txtDeclareQueueName.Text,false,false,false);
            AddLog($"Queue created with Name:{txtDeclareQueueName.Text}");
        }

        private void btnDeclareExchange_Click(object sender, EventArgs e)
        {
            //önce bir kanal oluşturmalıyız.
            channel.ExchangeDeclare(txtDeclareExchangeName.Text,cbDeclareExchangeType.Text); //exchange yaratmış olduk.
            AddLog($"Exchange created with Name:{txtDeclareExchangeName.Text},Type:{cbDeclareExchangeType.Text}");
             
        }

        private void btnBindQueue_Click(object sender, EventArgs e)
        {
            channel.QueueBind(txtDeclareQueueName.Text,txtDeclareExchangeName.Text,txtRoutingKey.Text);
        }

        private void btnPublish_Click(object sender, EventArgs e)
        {
            channel.BasicPublish();
        }

        private IConnection GetConnection()
        {
            ConnectionFactory factory = new ConnectionFactory()
            {
                Uri = new Uri(txtConnectionString.Text, UriKind.RelativeOrAbsolute)
            };
            return factory.CreateConnection();
        }

        private IModel CreateOrGetChannel()
        {
            //Imodel tipinde bir interface dönüyor bu da bizim channel 'ımız oluyor.
            return  connection.CreateModel();
        }

        private void WriteDataToExchange(string exchangeName,string routingKey,object data)
        {

        }


        #region App Methods
        private void ConnectionStateChanged()
        {
            //butonun ismini değiştiriyoruz.
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
        private void Init()
        {
            cbDeclareExchangeType.Items.Add("direct");
            cbDeclareExchangeType.Items.Add("fanout");
            cbDeclareExchangeType.Items.Add("headers");
            cbDeclareExchangeType.Items.Add("topic");

            cbDeclareExchangeType.SelectedIndex = 0;
        }








        #endregion

    }
}






