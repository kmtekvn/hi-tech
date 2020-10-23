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
            DevComponents.Instrumentation.GradientFillColor gradientFillColor9 = new DevComponents.Instrumentation.GradientFillColor();
            DevComponents.Instrumentation.GradientFillColor gradientFillColor10 = new DevComponents.Instrumentation.GradientFillColor();
            DevComponents.Instrumentation.GaugeText gaugeText5 = new DevComponents.Instrumentation.GaugeText();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            DevComponents.Instrumentation.GaugeText gaugeText6 = new DevComponents.Instrumentation.GaugeText();
            DevComponents.Instrumentation.GaugeLinearScale gaugeLinearScale5 = new DevComponents.Instrumentation.GaugeLinearScale();
            DevComponents.Instrumentation.GaugePointer gaugePointer5 = new DevComponents.Instrumentation.GaugePointer();
            DevComponents.Instrumentation.GaugeSection gaugeSection5 = new DevComponents.Instrumentation.GaugeSection();
            DevComponents.Instrumentation.GaugeLinearScale gaugeLinearScale6 = new DevComponents.Instrumentation.GaugeLinearScale();
            DevComponents.Instrumentation.GaugeCircularScale gaugeCircularScale3 = new DevComponents.Instrumentation.GaugeCircularScale();
            DevComponents.Instrumentation.GaugePointer gaugePointer6 = new DevComponents.Instrumentation.GaugePointer();
            DevComponents.Instrumentation.GaugeRange gaugeRange3 = new DevComponents.Instrumentation.GaugeRange();
            DevComponents.Instrumentation.GaugeSection gaugeSection6 = new DevComponents.Instrumentation.GaugeSection();
            DevComponents.Instrumentation.GradientFillColor gradientFillColor11 = new DevComponents.Instrumentation.GradientFillColor();
            DevComponents.Instrumentation.GradientFillColor gradientFillColor12 = new DevComponents.Instrumentation.GradientFillColor();
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
            this.txtShow = new System.Windows.Forms.TextBox();
            this.tmrUpdateUI = new System.Windows.Forms.Timer(this.components);
            this.txtShow2 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.btnSend = new System.Windows.Forms.Button();
            this.txtTemperature = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.gaugeTemperature = new DevComponents.Instrumentation.GaugeControl();
            this.knobPWM = new DevComponents.Instrumentation.KnobControl();
            this.gaugeHeartBeat = new DevComponents.Instrumentation.GaugeControl();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gaugeTemperature)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gaugeHeartBeat)).BeginInit();
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
            this.groupBox1.Controls.Add(this.txtTemperature);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.Controller_ID_txt);
            this.groupBox1.Controls.Add(this.ConnectButton);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(4, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(855, 47);
            this.groupBox1.TabIndex = 31;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Connect";
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
            // txtShow
            // 
            this.txtShow.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtShow.Location = new System.Drawing.Point(688, 178);
            this.txtShow.Multiline = true;
            this.txtShow.Name = "txtShow";
            this.txtShow.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtShow.Size = new System.Drawing.Size(171, 229);
            this.txtShow.TabIndex = 40;
            // 
            // tmrUpdateUI
            // 
            this.tmrUpdateUI.Enabled = true;
            this.tmrUpdateUI.Interval = 1000;
            this.tmrUpdateUI.Tick += new System.EventHandler(this.tmrUpdateUI_Tick);
            // 
            // txtShow2
            // 
            this.txtShow2.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtShow2.Location = new System.Drawing.Point(10, 178);
            this.txtShow2.Multiline = true;
            this.txtShow2.Name = "txtShow2";
            this.txtShow2.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtShow2.Size = new System.Drawing.Size(155, 211);
            this.txtShow2.TabIndex = 42;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(12, 152);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(55, 13);
            this.label3.TabIndex = 70;
            this.label3.Text = "Sent Data";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(705, 152);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(79, 13);
            this.label6.TabIndex = 71;
            this.label6.Text = "Received Data";
            // 
            // btnSend
            // 
            this.btnSend.Location = new System.Drawing.Point(514, 357);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(98, 50);
            this.btnSend.TabIndex = 72;
            this.btnSend.Text = "Reboot";
            this.btnSend.UseVisualStyleBackColor = true;
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click_1);
            // 
            // txtTemperature
            // 
            this.txtTemperature.Location = new System.Drawing.Point(569, 16);
            this.txtTemperature.Name = "txtTemperature";
            this.txtTemperature.Size = new System.Drawing.Size(50, 19);
            this.txtTemperature.TabIndex = 73;
            this.txtTemperature.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(487, 20);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(67, 13);
            this.label7.TabIndex = 74;
            this.label7.Text = "Temperature";
            // 
            // gaugeTemperature
            // 
            gradientFillColor9.Color1 = System.Drawing.Color.Gainsboro;
            gradientFillColor9.Color2 = System.Drawing.Color.DarkGray;
            this.gaugeTemperature.Frame.BackColor = gradientFillColor9;
            gradientFillColor10.BorderColor = System.Drawing.Color.Gainsboro;
            gradientFillColor10.BorderWidth = 1;
            gradientFillColor10.Color1 = System.Drawing.Color.White;
            gradientFillColor10.Color2 = System.Drawing.Color.DimGray;
            this.gaugeTemperature.Frame.FrameColor = gradientFillColor10;
            gaugeText5.BackColor.BorderColor = System.Drawing.Color.Black;
            gaugeText5.Location = ((System.Drawing.PointF)(resources.GetObject("gaugeText5.Location")));
            gaugeText5.Name = "Text1";
            gaugeText5.Text = "C°";
            gaugeText6.BackColor.BorderColor = System.Drawing.Color.Black;
            gaugeText6.Location = ((System.Drawing.PointF)(resources.GetObject("gaugeText6.Location")));
            gaugeText6.Name = "Text2";
            gaugeText6.Text = "F°";
            this.gaugeTemperature.GaugeItems.AddRange(new DevComponents.Instrumentation.GaugeItem[] {
            gaugeText5,
            gaugeText6});
            gaugeLinearScale5.Labels.FormatString = "0°";
            gaugeLinearScale5.Location = ((System.Drawing.PointF)(resources.GetObject("gaugeLinearScale5.Location")));
            gaugeLinearScale5.MajorTickMarks.Layout.Placement = DevComponents.Instrumentation.DisplayPlacement.Near;
            gaugeLinearScale5.MajorTickMarks.Layout.Style = DevComponents.Instrumentation.GaugeMarkerStyle.Rectangle;
            gaugeLinearScale5.MajorTickMarks.Layout.Width = 0.008F;
            gaugeLinearScale5.MaxPin.Name = "MaxPin";
            gaugeLinearScale5.MaxPin.Visible = false;
            gaugeLinearScale5.MaxValue = 40D;
            gaugeLinearScale5.MinorTickMarks.Layout.Placement = DevComponents.Instrumentation.DisplayPlacement.Near;
            gaugeLinearScale5.MinorTickMarks.Layout.Width = 0.016F;
            gaugeLinearScale5.MinPin.Name = "MinPin";
            gaugeLinearScale5.MinPin.Visible = false;
            gaugeLinearScale5.MinValue = -30D;
            gaugeLinearScale5.Name = "Scale1";
            gaugePointer5.BulbOffset = 0.026F;
            gaugePointer5.BulbSize = 0.132F;
            gaugePointer5.CapFillColor.BorderColor = System.Drawing.Color.DimGray;
            gaugePointer5.CapFillColor.BorderWidth = 1;
            gaugePointer5.CapFillColor.Color1 = System.Drawing.Color.WhiteSmoke;
            gaugePointer5.CapFillColor.Color2 = System.Drawing.Color.DimGray;
            gaugePointer5.FillColor.Color1 = System.Drawing.Color.Red;
            gaugePointer5.Name = "Pointer1";
            gaugePointer5.Style = DevComponents.Instrumentation.PointerStyle.Thermometer;
            gaugePointer5.ThermoBackColor.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            gaugePointer5.Value = 12D;
            gaugePointer5.Width = 0.1F;
            gaugeLinearScale5.Pointers.AddRange(new DevComponents.Instrumentation.GaugePointer[] {
            gaugePointer5});
            gaugeSection5.FillColor.Color1 = System.Drawing.Color.SteelBlue;
            gaugeSection5.FillColor.Color2 = System.Drawing.Color.LightCyan;
            gaugeSection5.FillColor.GradientFillType = DevComponents.Instrumentation.GradientFillType.HorizontalCenter;
            gaugeSection5.Name = "Section1";
            gaugeLinearScale5.Sections.AddRange(new DevComponents.Instrumentation.GaugeSection[] {
            gaugeSection5});
            gaugeLinearScale5.Width = 0.1F;
            gaugeLinearScale6.Labels.FormatString = "0°";
            gaugeLinearScale6.Labels.Layout.Placement = DevComponents.Instrumentation.DisplayPlacement.Far;
            gaugeLinearScale6.Labels.ShowMaxLabel = false;
            gaugeLinearScale6.Labels.ShowMinLabel = false;
            gaugeLinearScale6.Location = ((System.Drawing.PointF)(resources.GetObject("gaugeLinearScale6.Location")));
            gaugeLinearScale6.MajorTickMarks.Interval = 20D;
            gaugeLinearScale6.MajorTickMarks.IntervalOffset = 2D;
            gaugeLinearScale6.MajorTickMarks.Layout.Placement = DevComponents.Instrumentation.DisplayPlacement.Far;
            gaugeLinearScale6.MajorTickMarks.Layout.Style = DevComponents.Instrumentation.GaugeMarkerStyle.Rectangle;
            gaugeLinearScale6.MajorTickMarks.Layout.Width = 0.008F;
            gaugeLinearScale6.MaxPin.Name = "MaxPin";
            gaugeLinearScale6.MaxPin.Visible = false;
            gaugeLinearScale6.MaxValue = 104D;
            gaugeLinearScale6.MinorTickMarks.Interval = 4D;
            gaugeLinearScale6.MinorTickMarks.IntervalOffset = 2D;
            gaugeLinearScale6.MinorTickMarks.Layout.Placement = DevComponents.Instrumentation.DisplayPlacement.Far;
            gaugeLinearScale6.MinorTickMarks.Layout.Width = 0.016F;
            gaugeLinearScale6.MinPin.Name = "MinPin";
            gaugeLinearScale6.MinPin.Visible = false;
            gaugeLinearScale6.MinValue = -22D;
            gaugeLinearScale6.Name = "Scale2";
            gaugeLinearScale6.Width = 0.1F;
            this.gaugeTemperature.LinearScales.AddRange(new DevComponents.Instrumentation.GaugeLinearScale[] {
            gaugeLinearScale5,
            gaugeLinearScale6});
            this.gaugeTemperature.Location = new System.Drawing.Point(171, 168);
            this.gaugeTemperature.Name = "gaugeTemperature";
            this.gaugeTemperature.Size = new System.Drawing.Size(293, 56);
            this.gaugeTemperature.TabIndex = 75;
            this.gaugeTemperature.Text = "gaugeTemperature";
            // 
            // knobPWM
            // 
            this.knobPWM.Location = new System.Drawing.Point(467, 168);
            this.knobPWM.MinValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.knobPWM.Name = "knobPWM";
            this.knobPWM.Size = new System.Drawing.Size(183, 183);
            this.knobPWM.TabIndex = 76;
            this.knobPWM.Text = "knobPWM";
            this.knobPWM.CursorChanged += new System.EventHandler(this.knobPWM_CursorChanged);
            this.knobPWM.Click += new System.EventHandler(this.knobPWM_Click);
            // 
            // gaugeHeartBeat
            // 
            gaugeCircularScale3.MaxPin.Name = "MaxPin";
            gaugeCircularScale3.MinPin.Name = "MinPin";
            gaugeCircularScale3.Name = "Scale1";
            gaugePointer6.CapFillColor.BorderColor = System.Drawing.Color.DimGray;
            gaugePointer6.CapFillColor.BorderWidth = 1;
            gaugePointer6.CapFillColor.Color1 = System.Drawing.Color.WhiteSmoke;
            gaugePointer6.CapFillColor.Color2 = System.Drawing.Color.DimGray;
            gaugePointer6.FillColor.BorderColor = System.Drawing.Color.DimGray;
            gaugePointer6.FillColor.BorderWidth = 1;
            gaugePointer6.FillColor.Color1 = System.Drawing.Color.WhiteSmoke;
            gaugePointer6.FillColor.Color2 = System.Drawing.Color.Red;
            gaugePointer6.Length = 0.358F;
            gaugePointer6.Name = "Pointer1";
            gaugePointer6.Style = DevComponents.Instrumentation.PointerStyle.Needle;
            gaugeCircularScale3.Pointers.AddRange(new DevComponents.Instrumentation.GaugePointer[] {
            gaugePointer6});
            gaugeRange3.FillColor.BorderColor = System.Drawing.Color.DimGray;
            gaugeRange3.FillColor.BorderWidth = 1;
            gaugeRange3.FillColor.Color1 = System.Drawing.Color.Lime;
            gaugeRange3.FillColor.Color2 = System.Drawing.Color.Red;
            gaugeRange3.Name = "Range1";
            gaugeRange3.ScaleOffset = 0.28F;
            gaugeRange3.StartValue = 70D;
            gaugeCircularScale3.Ranges.AddRange(new DevComponents.Instrumentation.GaugeRange[] {
            gaugeRange3});
            gaugeSection6.FillColor.Color1 = System.Drawing.Color.CornflowerBlue;
            gaugeSection6.FillColor.Color2 = System.Drawing.Color.Purple;
            gaugeSection6.Name = "Section1";
            gaugeCircularScale3.Sections.AddRange(new DevComponents.Instrumentation.GaugeSection[] {
            gaugeSection6});
            this.gaugeHeartBeat.CircularScales.AddRange(new DevComponents.Instrumentation.GaugeCircularScale[] {
            gaugeCircularScale3});
            gradientFillColor11.Color1 = System.Drawing.Color.Gainsboro;
            gradientFillColor11.Color2 = System.Drawing.Color.DarkGray;
            this.gaugeHeartBeat.Frame.BackColor = gradientFillColor11;
            gradientFillColor12.BorderColor = System.Drawing.Color.Gainsboro;
            gradientFillColor12.BorderWidth = 1;
            gradientFillColor12.Color1 = System.Drawing.Color.White;
            gradientFillColor12.Color2 = System.Drawing.Color.DimGray;
            this.gaugeHeartBeat.Frame.FrameColor = gradientFillColor12;
            this.gaugeHeartBeat.Frame.Style = DevComponents.Instrumentation.GaugeFrameStyle.Circular;
            this.gaugeHeartBeat.Location = new System.Drawing.Point(208, 233);
            this.gaugeHeartBeat.Name = "gaugeHeartBeat";
            this.gaugeHeartBeat.Size = new System.Drawing.Size(206, 156);
            this.gaugeHeartBeat.TabIndex = 77;
            this.gaugeHeartBeat.Text = "gaugeHeartBeat";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(873, 421);
            this.Controls.Add(this.gaugeHeartBeat);
            this.Controls.Add(this.knobPWM);
            this.Controls.Add(this.gaugeTemperature);
            this.Controls.Add(this.btnSend);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtShow2);
            this.Controls.Add(this.txtShow);
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
        private System.Windows.Forms.TextBox txtShow;
        private System.Windows.Forms.ComboBox HostCbb;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Timer tmrUpdateUI;
        private System.Windows.Forms.TextBox txtShow2;
        private System.Windows.Forms.Button btn_publish;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnSend;
        private System.Windows.Forms.TextBox txtTemperature;
        private System.Windows.Forms.Label label7;
        private DevComponents.Instrumentation.GaugeControl gaugeTemperature;
        private DevComponents.Instrumentation.KnobControl knobPWM;
        private DevComponents.Instrumentation.GaugeControl gaugeHeartBeat;
    }
}

