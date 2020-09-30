using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using uPLibrary.Networking.M2Mqtt;
using uPLibrary.Networking.M2Mqtt.Messages;
using Excel = Microsoft.Office.Interop.Excel;
using System.IO;
using System.IO.Ports;


namespace MQTT_Client
{
    public partial class Form1 : Form
    {
        private delegate void myUICallBack(string myStr, TextBox ctl);
        private delegate void myUI_clearCallBack(TextBox ctl);


        static String[] subTopic = { "monitor" };
        static byte[] qosLevel = {0};

        //Variables for MQTT connection
        static MqttClient client;

        string str_broker_add = "";
        string str_acc = "";
        string str_pass = "";

        string monitor_topic = "";
        static int port = 1883;
        string str_controller_ID = "";

        string str_monitor_topic = "";

        private void myUI(string myStr, TextBox ctl)
        {
            if (this.InvokeRequired)
            {
                myUICallBack myUpdate = new myUICallBack(myUI);
                this.Invoke(myUpdate, myStr, ctl);
            }
            else
            {
                ctl.AppendText(myStr + Environment.NewLine);
            }
        }
        private void myUI_clear(TextBox ctl)
        {
            if (this.InvokeRequired)
            {
                myUI_clearCallBack myUpdate = new myUI_clearCallBack(myUI_clear);
                this.Invoke(myUpdate, ctl);
            }
            else
            {
                ctl.Clear();
            }
        }
        private void myUI_text(string myStr, TextBox ctl)
        {
            if (this.InvokeRequired)
            {
                myUICallBack myUpdate = new myUICallBack(myUI);
                this.Invoke(myUpdate, myStr, ctl);
            }
            else
            {
                ctl.Text = myStr;
            }
        }

        private void AppendTextBox(string txt)
        {
            if (InvokeRequired)
            {
                this.Invoke(new Action<string>(AppendTextBox), new object[] { txt });
                return;
            }
            txtShow.Text += txt;
            txtShow.SelectionStart = txtShow.TextLength;
            txtShow.ScrollToCaret();
        }

        /* Start Display Mqtt Message */
        private delegate void displayMqttMsgCallback(string displayString, TextBox displayTextbox);

        private void displayMqttMsg(string displayString, TextBox displayTextbox)
        {
            if (this.InvokeRequired)
            {
                displayMqttMsgCallback displayMqttMsgUpdate = new displayMqttMsgCallback(displayMqttMsg);
                this.Invoke(displayMqttMsgUpdate, displayString, displayTextbox);
            }
            else
            {
                displayTextbox.AppendText(displayString + Environment.NewLine);
            }
        }

        private void client_MqttMsgPublishReceived(object sender, MqttMsgPublishEventArgs e)
        {
            AppendTextBox(Encoding.Default.GetString(e.Message));
        }

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.AcceptButton = this.ConnectButton;
            Topic_pub_cmb.SelectedIndex = 1;
        }

        private void Form1_Closing(object sender, FormClosingEventArgs e)
        {
            if (client != null && client.IsConnected) client.Disconnect();
        }

        private void ConnectButton_Click(object sender, EventArgs e)
        {
            if (ConnectButton.Text == "Connect")
            {
                try
                {
                    str_broker_add = HostCbb.Text;
                    client = new MqttClient(str_broker_add, port, false, null);
                    client.Connect(Guid.NewGuid().ToString(), str_acc, str_pass);
                    client.MqttMsgPublishReceived += new MqttClient.MqttMsgPublishEventHandler(client_MqttMsgPublishReceived);


                    client.Subscribe(subTopic, qosLevel);
                }
                catch
                {
                    label4.Text = "Can't connect to server";
                }
                if (client != null && client.IsConnected)
                {

                    label4.Text = "";
                    tmrUpdateUI.Enabled = true;
                    HostCbb.Enabled = false;
                    Controller_ID_txt.Enabled = false;

                    //switch connect button to disconnect button
                    ConnectButton.Text = "Disconnect";

                    //subscribe monitor topic
                    str_controller_ID = Controller_ID_txt.Text;
                    str_monitor_topic = monitor_topic + str_controller_ID;
                }
            }
            else if (ConnectButton.Text == "Disconnect")
            {
                if (client != null && client.IsConnected) client.Disconnect();
                HostCbb.Enabled = true;
                Controller_ID_txt.Enabled = true;

                //switch disconnect button to connect button
                ConnectButton.Text = "Connect";
            }
        }

        private void btn_publish_Click(object sender, EventArgs e)
        {
            byte[] pubData = new byte[5];
            for (int i = 0;i < 5; i++){
                pubData[i] = (byte)'A';
            }

            client.Publish("command", pubData);
        }
    }
}
