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
using SenML.NET;
using ChoETL;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using DevComponents.DotNetBar;
using DevComponents.Instrumentation;
/* 
 * 
 * [{"bn":"gateway"},{"bn":"dev1","n":"temperature","u":"Cel","v":35.0},{"n":"breadth","u":"beats","v":60.0}]
/*
 Libs: Install-Package Newtonsoft.Json
 */
namespace MQTT_Client
{
    public partial class Form1 : Form
    {
        private delegate void myUICallBack(string myStr, TextBox ctl);
        private delegate void myUI_clearCallBack(TextBox ctl);


        static String[] subTopic = { "arduino/monitor" };
        static byte[] qosLevel = {0};

        static UInt64 gauge_value = 0;

        //Variables for MQTT connection
        static MqttClient client;

        static SenML.NET.SenML senMLInst = new SenML.NET.SenML();

        static string test_senml_buf = "[{\"bn\":\"gateway\"},{\"bn\":\"dev1\",\"n\":\"temperature\",\"u\":\"Cel\",\"v\":35.0},{\"n\":\"breadth\",\"u\":\"beats\",\"v\":60.0}]";

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
        
        private void ShowReceivedData(string txt)
        {
            if (InvokeRequired)
            {
                this.Invoke(new Action<string>(ShowReceivedData), new object[] { txt });
                return;
            }
            //txtTemperature.Text = txt;
        }

        private void AppendTextBox(string txt)
        {
            if (InvokeRequired)
            {
                this.Invoke(new Action<string>(AppendTextBox), new object[] { txt });
                return;
            }
            
        }
         private void AppendTextBox2(string txt)
        {
            if (InvokeRequired)
            {
                this.Invoke(new Action<string>(AppendTextBox2), new object[] { txt });
                return;
            }
        }

        private void UpdateTemperatureGauge(UInt32 temp)
        {
            float conv_temp = (float)((float)temp / 10.0);
            if (InvokeRequired)
            {
                this.Invoke(new Action<UInt32>(UpdateTemperatureGauge), new object[] { temp });
                return;
            }
            gaugeTemperature.SetPointerValue(gaugeTemperature.LinearScales[0].Pointers[0].Name, conv_temp);
        }

        private void UpdateHeartbeatGauge(UInt32 beat)
        {
            if (InvokeRequired)
            {
                this.Invoke(new Action<UInt32>(UpdateHeartbeatGauge), new object[] { beat });
                return;
            }
            gaugeHeartBeat.SetPointerValue(gaugeHeartBeat.CircularScales[0].Pointers[0].Name, beat);
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
            string payload = Encoding.Default.GetString(e.Message);

            JsonTextReader reader = new JsonTextReader(new StringReader(payload));
            while (reader.Read())
            {
                if (reader.TokenType == JsonToken.StartObject)
                {
                    JObject obj = JObject.Load(reader);
                    if ((string)obj["n"] == "temperature")
                    {
                        //AppendTextBox("Temperature: " + (string)obj["v"] + "\r\n");
                        UpdateTemperatureGauge((UInt32)obj["v"]);
                    }
                    else if ((string)obj["n"] == "breadth")
                    {
                        //AppendTextBox("Hearbeat: " + (string)obj["v"] + "\r\n");
                        UpdateHeartbeatGauge((UInt32)obj["v"]);
                    }
                }
            }
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
            client.Publish("arduino/control", Encoding.UTF8.GetBytes(PubMessageTextBox.Text));
        }

        private void label3_Click(object sender, EventArgs e)
        {
            
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            btnSend.Text = "OK";
        }

        private void btnSend_Click_1(object sender, EventArgs e)
        {
            client.Publish("arduino/control", Encoding.UTF8.GetBytes("reboot"));
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void tmrUpdateUI_Tick(object sender, EventArgs e)
        {
        }

        private void knobPWM_Click(object sender, EventArgs e)
        {
            
        }

        private void knobPWM_CursorChanged(object sender, EventArgs e)
        {
            //btnSend.Text = "Knod changed" + knobPWM.Value;
            // TODO: publish value to broker
            client.Publish("arduino/control", Encoding.UTF8.GetBytes(knobPWM.Value.ToString()));
        }
    }
}
