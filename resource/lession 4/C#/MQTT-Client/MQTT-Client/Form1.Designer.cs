namespace MQTT_Client
{
    partial class Form1
    {
        /// <summary>
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置 Managed 資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 設計工具產生的程式碼

        /// <summary>
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器
        /// 修改這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            DevComponents.Instrumentation.GradientFillColor gradientFillColor1 = new DevComponents.Instrumentation.GradientFillColor();
            DevComponents.Instrumentation.GradientFillColor gradientFillColor2 = new DevComponents.Instrumentation.GradientFillColor();
            DevComponents.Instrumentation.GaugeText gaugeText1 = new DevComponents.Instrumentation.GaugeText();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            DevComponents.Instrumentation.GaugeLinearScale gaugeLinearScale1 = new DevComponents.Instrumentation.GaugeLinearScale();
            DevComponents.Instrumentation.GaugePointer gaugePointer1 = new DevComponents.Instrumentation.GaugePointer();
            DevComponents.Instrumentation.GaugeSection gaugeSection1 = new DevComponents.Instrumentation.GaugeSection();
            DevComponents.Instrumentation.GaugeCircularScale gaugeCircularScale1 = new DevComponents.Instrumentation.GaugeCircularScale();
            DevComponents.Instrumentation.GaugePointer gaugePointer2 = new DevComponents.Instrumentation.GaugePointer();
            DevComponents.Instrumentation.GaugeRange gaugeRange1 = new DevComponents.Instrumentation.GaugeRange();
            DevComponents.Instrumentation.GaugeSection gaugeSection2 = new DevComponents.Instrumentation.GaugeSection();
            DevComponents.Instrumentation.GradientFillColor gradientFillColor3 = new DevComponents.Instrumentation.GradientFillColor();
            DevComponents.Instrumentation.GradientFillColor gradientFillColor4 = new DevComponents.Instrumentation.GradientFillColor();
            this.label4 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.ConnectButton = new System.Windows.Forms.Button();
            this.Controller_ID_txt = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.HostCbb = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.Topic_pub_cmb = new System.Windows.Forms.ComboBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btn_publish = new System.Windows.Forms.Button();
            this.PubMessageTextBox = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.tmrUpdateUI = new System.Windows.Forms.Timer(this.components);
            this.btnSend = new System.Windows.Forms.Button();
            this.gaugeTemperature = new DevComponents.Instrumentation.GaugeControl();
            this.knobPWM = new DevComponents.Instrumentation.KnobControl();
            this.gaugeHeartBeat = new DevComponents.Instrumentation.GaugeControl();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtDbgMsg = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gaugeTemperature)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gaugeHeartBeat)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft JhengHei", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label4.ForeColor = System.Drawing.Color.Red;
            this.label4.Location = new System.Drawing.Point(71, 697);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(0, 19);
            this.label4.TabIndex = 10;
            // 
            // label12
            // 
            this.label12.Location = new System.Drawing.Point(0, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(100, 23);
            this.label12.TabIndex = 41;
            // 
            // ConnectButton
            // 
            this.ConnectButton.Font = new System.Drawing.Font("Microsoft JhengHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.ConnectButton.Location = new System.Drawing.Point(302, 12);
            this.ConnectButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.ConnectButton.Name = "ConnectButton";
            this.ConnectButton.Size = new System.Drawing.Size(179, 32);
            this.ConnectButton.TabIndex = 4;
            this.ConnectButton.Text = "Connect";
            this.ConnectButton.UseVisualStyleBackColor = true;
            this.ConnectButton.Click += new System.EventHandler(this.ConnectButton_Click);
            // 
            // Controller_ID_txt
            // 
            this.Controller_ID_txt.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Controller_ID_txt.Location = new System.Drawing.Point(245, 16);
            this.Controller_ID_txt.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Controller_ID_txt.MaxLength = 128;
            this.Controller_ID_txt.Name = "Controller_ID_txt";
            this.Controller_ID_txt.Size = new System.Drawing.Size(46, 19);
            this.Controller_ID_txt.TabIndex = 6;
            this.Controller_ID_txt.Text = "1234";
            this.Controller_ID_txt.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(2, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 24);
            this.label1.TabIndex = 0;
            this.label1.Text = "Host:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.HostCbb);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.Controller_ID_txt);
            this.groupBox1.Controls.Add(this.ConnectButton);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(4, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(855, 47);
            this.groupBox1.TabIndex = 31;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Connection";
            // 
            // HostCbb
            // 
            this.HostCbb.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.HostCbb.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.HostCbb.FormattingEnabled = true;
            this.HostCbb.Items.AddRange(new object[] {
            "localhost"});
            this.HostCbb.Location = new System.Drawing.Point(42, 16);
            this.HostCbb.Name = "HostCbb";
            this.HostCbb.Size = new System.Drawing.Size(171, 21);
            this.HostCbb.TabIndex = 23;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(219, 20);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(25, 24);
            this.label2.TabIndex = 1;
            this.label2.Text = "ID";
            // 
            // Topic_pub_cmb
            // 
            this.Topic_pub_cmb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Topic_pub_cmb.FormattingEnabled = true;
            this.Topic_pub_cmb.Items.AddRange(new object[] {
            "monitor",
            "control"});
            this.Topic_pub_cmb.Location = new System.Drawing.Point(64, 16);
            this.Topic_pub_cmb.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Topic_pub_cmb.MaxDropDownItems = 3;
            this.Topic_pub_cmb.Name = "Topic_pub_cmb";
            this.Topic_pub_cmb.Size = new System.Drawing.Size(698, 24);
            this.Topic_pub_cmb.TabIndex = 32;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btn_publish);
            this.groupBox2.Controls.Add(this.PubMessageTextBox);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.Topic_pub_cmb);
            this.groupBox2.Location = new System.Drawing.Point(4, 53);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(855, 93);
            this.groupBox2.TabIndex = 33;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Publish";
            // 
            // btn_publish
            // 
            this.btn_publish.Location = new System.Drawing.Point(774, 16);
            this.btn_publish.Name = "btn_publish";
            this.btn_publish.Size = new System.Drawing.Size(75, 51);
            this.btn_publish.TabIndex = 69;
            this.btn_publish.Text = "Publish";
            this.btn_publish.UseVisualStyleBackColor = true;
            this.btn_publish.Click += new System.EventHandler(this.btn_publish_Click);
            // 
            // PubMessageTextBox
            // 
            this.PubMessageTextBox.Location = new System.Drawing.Point(64, 44);
            this.PubMessageTextBox.Name = "PubMessageTextBox";
            this.PubMessageTextBox.Size = new System.Drawing.Size(698, 23);
            this.PubMessageTextBox.TabIndex = 68;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(6, 15);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(34, 13);
            this.label5.TabIndex = 33;
            this.label5.Text = "Topic";
            // 
            // tmrUpdateUI
            // 
            this.tmrUpdateUI.Enabled = true;
            this.tmrUpdateUI.Interval = 1000;
            this.tmrUpdateUI.Tick += new System.EventHandler(this.tmrUpdateUI_Tick);
            // 
            // btnSend
            // 
            this.btnSend.Location = new System.Drawing.Point(152, 380);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(98, 50);
            this.btnSend.TabIndex = 72;
            this.btnSend.Text = "Reboot";
            this.btnSend.UseVisualStyleBackColor = true;
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click_1);
            // 
            // gaugeTemperature
            // 
            gradientFillColor1.Color1 = System.Drawing.Color.Gainsboro;
            gradientFillColor1.Color2 = System.Drawing.Color.DarkGray;
            this.gaugeTemperature.Frame.BackColor = gradientFillColor1;
            gradientFillColor2.BorderColor = System.Drawing.Color.Gainsboro;
            gradientFillColor2.BorderWidth = 1;
            gradientFillColor2.Color1 = System.Drawing.Color.White;
            gradientFillColor2.Color2 = System.Drawing.Color.DimGray;
            this.gaugeTemperature.Frame.FrameColor = gradientFillColor2;
            gaugeText1.BackColor.BorderColor = System.Drawing.Color.Black;
            gaugeText1.Location = ((System.Drawing.PointF)(resources.GetObject("gaugeText1.Location")));
            gaugeText1.Name = "Text1";
            gaugeText1.Size = new System.Drawing.SizeF(0.5F, 0.5F);
            gaugeText1.Text = "C°";
            this.gaugeTemperature.GaugeItems.AddRange(new DevComponents.Instrumentation.GaugeItem[] {
            gaugeText1});
            gaugeLinearScale1.Labels.FormatString = "0°";
            gaugeLinearScale1.Location = ((System.Drawing.PointF)(resources.GetObject("gaugeLinearScale1.Location")));
            gaugeLinearScale1.MajorTickMarks.Layout.Placement = DevComponents.Instrumentation.DisplayPlacement.Near;
            gaugeLinearScale1.MajorTickMarks.Layout.Style = DevComponents.Instrumentation.GaugeMarkerStyle.Rectangle;
            gaugeLinearScale1.MajorTickMarks.Layout.Width = 0.008F;
            gaugeLinearScale1.MaxPin.Name = "MaxPin";
            gaugeLinearScale1.MaxPin.Visible = false;
            gaugeLinearScale1.MaxValue = 40D;
            gaugeLinearScale1.MinorTickMarks.Layout.Placement = DevComponents.Instrumentation.DisplayPlacement.Near;
            gaugeLinearScale1.MinorTickMarks.Layout.Width = 0.016F;
            gaugeLinearScale1.MinPin.Name = "MinPin";
            gaugeLinearScale1.MinPin.Visible = false;
            gaugeLinearScale1.Name = "Scale1";
            gaugePointer1.BulbOffset = 0.026F;
            gaugePointer1.BulbSize = 0.132F;
            gaugePointer1.CapFillColor.BorderColor = System.Drawing.Color.DimGray;
            gaugePointer1.CapFillColor.BorderWidth = 1;
            gaugePointer1.CapFillColor.Color1 = System.Drawing.Color.WhiteSmoke;
            gaugePointer1.CapFillColor.Color2 = System.Drawing.Color.DimGray;
            gaugePointer1.FillColor.Color1 = System.Drawing.Color.Red;
            gaugePointer1.Name = "Pointer1";
            gaugePointer1.Style = DevComponents.Instrumentation.PointerStyle.Thermometer;
            gaugePointer1.ThermoBackColor.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            gaugePointer1.Value = 12D;
            gaugePointer1.Width = 0.1F;
            gaugeLinearScale1.Pointers.AddRange(new DevComponents.Instrumentation.GaugePointer[] {
            gaugePointer1});
            gaugeSection1.FillColor.Color1 = System.Drawing.Color.SteelBlue;
            gaugeSection1.FillColor.Color2 = System.Drawing.Color.LightCyan;
            gaugeSection1.FillColor.GradientFillType = DevComponents.Instrumentation.GradientFillType.HorizontalCenter;
            gaugeSection1.Name = "Section1";
            gaugeLinearScale1.Sections.AddRange(new DevComponents.Instrumentation.GaugeSection[] {
            gaugeSection1});
            gaugeLinearScale1.Width = 0.1F;
            this.gaugeTemperature.LinearScales.AddRange(new DevComponents.Instrumentation.GaugeLinearScale[] {
            gaugeLinearScale1});
            this.gaugeTemperature.Location = new System.Drawing.Point(10, 22);
            this.gaugeTemperature.Name = "gaugeTemperature";
            this.gaugeTemperature.Size = new System.Drawing.Size(404, 71);
            this.gaugeTemperature.TabIndex = 75;
            this.gaugeTemperature.Text = "gaugeTemperature";
            // 
            // knobPWM
            // 
            this.knobPWM.Location = new System.Drawing.Point(24, 22);
            this.knobPWM.MinValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.knobPWM.Name = "knobPWM";
            this.knobPWM.Size = new System.Drawing.Size(350, 336);
            this.knobPWM.TabIndex = 76;
            this.knobPWM.Text = "knobPWM";
            this.knobPWM.CursorChanged += new System.EventHandler(this.knobPWM_CursorChanged);
            this.knobPWM.Click += new System.EventHandler(this.knobPWM_Click);
            // 
            // gaugeHeartBeat
            // 
            gaugeCircularScale1.MaxPin.Name = "MaxPin";
            gaugeCircularScale1.MaxValue = 150D;
            gaugeCircularScale1.MinPin.Name = "MinPin";
            gaugeCircularScale1.Name = "Scale1";
            gaugePointer2.CapFillColor.BorderColor = System.Drawing.Color.DimGray;
            gaugePointer2.CapFillColor.BorderWidth = 1;
            gaugePointer2.CapFillColor.Color1 = System.Drawing.Color.WhiteSmoke;
            gaugePointer2.CapFillColor.Color2 = System.Drawing.Color.DimGray;
            gaugePointer2.FillColor.BorderColor = System.Drawing.Color.DimGray;
            gaugePointer2.FillColor.BorderWidth = 1;
            gaugePointer2.FillColor.Color1 = System.Drawing.Color.WhiteSmoke;
            gaugePointer2.FillColor.Color2 = System.Drawing.Color.Red;
            gaugePointer2.Length = 0.358F;
            gaugePointer2.Name = "Pointer1";
            gaugePointer2.Style = DevComponents.Instrumentation.PointerStyle.Needle;
            gaugeCircularScale1.Pointers.AddRange(new DevComponents.Instrumentation.GaugePointer[] {
            gaugePointer2});
            gaugeRange1.FillColor.BorderColor = System.Drawing.Color.DimGray;
            gaugeRange1.FillColor.BorderWidth = 1;
            gaugeRange1.FillColor.Color1 = System.Drawing.Color.Lime;
            gaugeRange1.FillColor.Color2 = System.Drawing.Color.Red;
            gaugeRange1.Name = "Range1";
            gaugeRange1.ScaleOffset = 0.28F;
            gaugeRange1.StartValue = 70D;
            gaugeCircularScale1.Ranges.AddRange(new DevComponents.Instrumentation.GaugeRange[] {
            gaugeRange1});
            gaugeSection2.FillColor.Color1 = System.Drawing.Color.CornflowerBlue;
            gaugeSection2.FillColor.Color2 = System.Drawing.Color.Purple;
            gaugeSection2.Name = "Section1";
            gaugeCircularScale1.Sections.AddRange(new DevComponents.Instrumentation.GaugeSection[] {
            gaugeSection2});
            this.gaugeHeartBeat.CircularScales.AddRange(new DevComponents.Instrumentation.GaugeCircularScale[] {
            gaugeCircularScale1});
            gradientFillColor3.Color1 = System.Drawing.Color.Gainsboro;
            gradientFillColor3.Color2 = System.Drawing.Color.DarkGray;
            this.gaugeHeartBeat.Frame.BackColor = gradientFillColor3;
            gradientFillColor4.BorderColor = System.Drawing.Color.Gainsboro;
            gradientFillColor4.BorderWidth = 1;
            gradientFillColor4.Color1 = System.Drawing.Color.White;
            gradientFillColor4.Color2 = System.Drawing.Color.DimGray;
            this.gaugeHeartBeat.Frame.FrameColor = gradientFillColor4;
            this.gaugeHeartBeat.Frame.Style = DevComponents.Instrumentation.GaugeFrameStyle.Circular;
            this.gaugeHeartBeat.Location = new System.Drawing.Point(14, 99);
            this.gaugeHeartBeat.Name = "gaugeHeartBeat";
            this.gaugeHeartBeat.Size = new System.Drawing.Size(399, 331);
            this.gaugeHeartBeat.TabIndex = 77;
            this.gaugeHeartBeat.Text = "gaugeHeartBeat";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.gaugeHeartBeat);
            this.groupBox3.Controls.Add(this.gaugeTemperature);
            this.groupBox3.Location = new System.Drawing.Point(3, 176);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(436, 445);
            this.groupBox3.TabIndex = 78;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Monitor";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.btnSend);
            this.groupBox4.Controls.Add(this.knobPWM);
            this.groupBox4.Location = new System.Drawing.Point(463, 176);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(396, 445);
            this.groupBox4.TabIndex = 79;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Control";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(32, 647);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(104, 16);
            this.label3.TabIndex = 80;
            this.label3.Text = "Debug Message:";
            // 
            // txtDbgMsg
            // 
            this.txtDbgMsg.Location = new System.Drawing.Point(143, 642);
            this.txtDbgMsg.Name = "txtDbgMsg";
            this.txtDbgMsg.ReadOnly = true;
            this.txtDbgMsg.Size = new System.Drawing.Size(683, 23);
            this.txtDbgMsg.TabIndex = 81;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(873, 677);
            this.Controls.Add(this.txtDbgMsg);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label4);
            this.Font = new System.Drawing.Font("Microsoft JhengHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "Form1";
            this.Text = "HT-MQTT-CLENT";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_Closing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gaugeTemperature)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gaugeHeartBeat)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Button ConnectButton;
        private System.Windows.Forms.TextBox Controller_ID_txt;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox Topic_pub_cmb;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox PubMessageTextBox;
        private System.Windows.Forms.ComboBox HostCbb;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Timer tmrUpdateUI;
        private System.Windows.Forms.Button btn_publish;
        private System.Windows.Forms.Button btnSend;
        private DevComponents.Instrumentation.GaugeControl gaugeTemperature;
        private DevComponents.Instrumentation.KnobControl knobPWM;
        private DevComponents.Instrumentation.GaugeControl gaugeHeartBeat;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtDbgMsg;
    }
}

