namespace BuildESP8266Flash
{
    partial class BuildESP8266Flash
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.pathText1 = new System.Windows.Forms.TextBox();
            this.hexText1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.selectButton1 = new System.Windows.Forms.Button();
            this.selectButton2 = new System.Windows.Forms.Button();
            this.hexText2 = new System.Windows.Forms.TextBox();
            this.pathText2 = new System.Windows.Forms.TextBox();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.selectButton3 = new System.Windows.Forms.Button();
            this.hexText3 = new System.Windows.Forms.TextBox();
            this.pathText3 = new System.Windows.Forms.TextBox();
            this.checkBox3 = new System.Windows.Forms.CheckBox();
            this.selectButton4 = new System.Windows.Forms.Button();
            this.hexText4 = new System.Windows.Forms.TextBox();
            this.pathText4 = new System.Windows.Forms.TextBox();
            this.checkBox4 = new System.Windows.Forms.CheckBox();
            this.selectButton5 = new System.Windows.Forms.Button();
            this.hexText5 = new System.Windows.Forms.TextBox();
            this.pathText5 = new System.Windows.Forms.TextBox();
            this.checkBox5 = new System.Windows.Forms.CheckBox();
            this.selectButton6 = new System.Windows.Forms.Button();
            this.hexText6 = new System.Windows.Forms.TextBox();
            this.pathText6 = new System.Windows.Forms.TextBox();
            this.checkBox6 = new System.Windows.Forms.CheckBox();
            this.label4 = new System.Windows.Forms.Label();
            this.fileSizeHexText = new System.Windows.Forms.TextBox();
            this.createButton = new System.Windows.Forms.Button();
            this.fillByteHexText = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.savePathText = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.saveButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Checked = true;
            this.checkBox1.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox1.Location = new System.Drawing.Point(15, 36);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(15, 14);
            this.checkBox1.TabIndex = 0;
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // pathText1
            // 
            this.pathText1.Location = new System.Drawing.Point(53, 33);
            this.pathText1.Name = "pathText1";
            this.pathText1.Size = new System.Drawing.Size(314, 20);
            this.pathText1.TabIndex = 1;
            this.pathText1.Text = "boot_v1.1.bin";
            // 
            // hexText1
            // 
            this.hexText1.Location = new System.Drawing.Point(414, 33);
            this.hexText1.Name = "hexText1";
            this.hexText1.Size = new System.Drawing.Size(101, 20);
            this.hexText1.TabIndex = 2;
            this.hexText1.Text = "0x00000";
            this.hexText1.Leave += new System.EventHandler(this.hexText1_Leave);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(26, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Use";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(50, 12);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(54, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "File Name";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(432, 12);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(63, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Offset (Hex)";
            // 
            // selectButton1
            // 
            this.selectButton1.Location = new System.Drawing.Point(376, 32);
            this.selectButton1.Name = "selectButton1";
            this.selectButton1.Size = new System.Drawing.Size(26, 23);
            this.selectButton1.TabIndex = 6;
            this.selectButton1.Text = "...";
            this.selectButton1.UseVisualStyleBackColor = true;
            this.selectButton1.Click += new System.EventHandler(this.selectButton1_Click);
            // 
            // selectButton2
            // 
            this.selectButton2.Location = new System.Drawing.Point(376, 58);
            this.selectButton2.Name = "selectButton2";
            this.selectButton2.Size = new System.Drawing.Size(26, 23);
            this.selectButton2.TabIndex = 10;
            this.selectButton2.Text = "...";
            this.selectButton2.UseVisualStyleBackColor = true;
            this.selectButton2.Click += new System.EventHandler(this.selectButton2_Click);
            // 
            // hexText2
            // 
            this.hexText2.Location = new System.Drawing.Point(414, 59);
            this.hexText2.Name = "hexText2";
            this.hexText2.Size = new System.Drawing.Size(101, 20);
            this.hexText2.TabIndex = 9;
            this.hexText2.Text = "0x01000";
            this.hexText2.Leave += new System.EventHandler(this.hexText2_Leave);
            // 
            // pathText2
            // 
            this.pathText2.Location = new System.Drawing.Point(53, 59);
            this.pathText2.Name = "pathText2";
            this.pathText2.Size = new System.Drawing.Size(314, 20);
            this.pathText2.TabIndex = 8;
            this.pathText2.Text = "user1.bin";
            // 
            // checkBox2
            // 
            this.checkBox2.AutoSize = true;
            this.checkBox2.Checked = true;
            this.checkBox2.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox2.Location = new System.Drawing.Point(15, 62);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(15, 14);
            this.checkBox2.TabIndex = 7;
            this.checkBox2.UseVisualStyleBackColor = true;
            // 
            // selectButton3
            // 
            this.selectButton3.Location = new System.Drawing.Point(376, 84);
            this.selectButton3.Name = "selectButton3";
            this.selectButton3.Size = new System.Drawing.Size(26, 23);
            this.selectButton3.TabIndex = 14;
            this.selectButton3.Text = "...";
            this.selectButton3.UseVisualStyleBackColor = true;
            this.selectButton3.Click += new System.EventHandler(this.selectButton3_Click);
            // 
            // hexText3
            // 
            this.hexText3.Location = new System.Drawing.Point(414, 85);
            this.hexText3.Name = "hexText3";
            this.hexText3.Size = new System.Drawing.Size(101, 20);
            this.hexText3.TabIndex = 13;
            this.hexText3.Text = "0x7C000";
            this.hexText3.Leave += new System.EventHandler(this.hexText3_Leave);
            // 
            // pathText3
            // 
            this.pathText3.Location = new System.Drawing.Point(53, 85);
            this.pathText3.Name = "pathText3";
            this.pathText3.Size = new System.Drawing.Size(314, 20);
            this.pathText3.TabIndex = 12;
            this.pathText3.Text = "esp_init_data_default.bin";
            // 
            // checkBox3
            // 
            this.checkBox3.AutoSize = true;
            this.checkBox3.Checked = true;
            this.checkBox3.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox3.Location = new System.Drawing.Point(15, 88);
            this.checkBox3.Name = "checkBox3";
            this.checkBox3.Size = new System.Drawing.Size(15, 14);
            this.checkBox3.TabIndex = 11;
            this.checkBox3.UseVisualStyleBackColor = true;
            // 
            // selectButton4
            // 
            this.selectButton4.Location = new System.Drawing.Point(376, 110);
            this.selectButton4.Name = "selectButton4";
            this.selectButton4.Size = new System.Drawing.Size(26, 23);
            this.selectButton4.TabIndex = 18;
            this.selectButton4.Text = "...";
            this.selectButton4.UseVisualStyleBackColor = true;
            this.selectButton4.Click += new System.EventHandler(this.selectButton4_Click);
            // 
            // hexText4
            // 
            this.hexText4.Location = new System.Drawing.Point(414, 111);
            this.hexText4.Name = "hexText4";
            this.hexText4.Size = new System.Drawing.Size(101, 20);
            this.hexText4.TabIndex = 17;
            this.hexText4.Text = "0x7E000";
            this.hexText4.Leave += new System.EventHandler(this.hexText4_Leave);
            // 
            // pathText4
            // 
            this.pathText4.Location = new System.Drawing.Point(53, 111);
            this.pathText4.Name = "pathText4";
            this.pathText4.Size = new System.Drawing.Size(314, 20);
            this.pathText4.TabIndex = 16;
            this.pathText4.Text = "blank.bin";
            // 
            // checkBox4
            // 
            this.checkBox4.AutoSize = true;
            this.checkBox4.Checked = true;
            this.checkBox4.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox4.Location = new System.Drawing.Point(15, 114);
            this.checkBox4.Name = "checkBox4";
            this.checkBox4.Size = new System.Drawing.Size(15, 14);
            this.checkBox4.TabIndex = 15;
            this.checkBox4.UseVisualStyleBackColor = true;
            // 
            // selectButton5
            // 
            this.selectButton5.Location = new System.Drawing.Point(376, 136);
            this.selectButton5.Name = "selectButton5";
            this.selectButton5.Size = new System.Drawing.Size(26, 23);
            this.selectButton5.TabIndex = 22;
            this.selectButton5.Text = "...";
            this.selectButton5.UseVisualStyleBackColor = true;
            this.selectButton5.Click += new System.EventHandler(this.selectButton5_Click);
            // 
            // hexText5
            // 
            this.hexText5.Location = new System.Drawing.Point(414, 137);
            this.hexText5.Name = "hexText5";
            this.hexText5.Size = new System.Drawing.Size(101, 20);
            this.hexText5.TabIndex = 21;
            this.hexText5.Leave += new System.EventHandler(this.hexText5_Leave);
            // 
            // pathText5
            // 
            this.pathText5.Location = new System.Drawing.Point(53, 137);
            this.pathText5.Name = "pathText5";
            this.pathText5.Size = new System.Drawing.Size(314, 20);
            this.pathText5.TabIndex = 20;
            // 
            // checkBox5
            // 
            this.checkBox5.AutoSize = true;
            this.checkBox5.Location = new System.Drawing.Point(15, 140);
            this.checkBox5.Name = "checkBox5";
            this.checkBox5.Size = new System.Drawing.Size(15, 14);
            this.checkBox5.TabIndex = 19;
            this.checkBox5.UseVisualStyleBackColor = true;
            // 
            // selectButton6
            // 
            this.selectButton6.Location = new System.Drawing.Point(376, 162);
            this.selectButton6.Name = "selectButton6";
            this.selectButton6.Size = new System.Drawing.Size(26, 23);
            this.selectButton6.TabIndex = 26;
            this.selectButton6.Text = "...";
            this.selectButton6.UseVisualStyleBackColor = true;
            this.selectButton6.Click += new System.EventHandler(this.selectButton6_Click);
            // 
            // hexText6
            // 
            this.hexText6.Location = new System.Drawing.Point(414, 163);
            this.hexText6.Name = "hexText6";
            this.hexText6.Size = new System.Drawing.Size(101, 20);
            this.hexText6.TabIndex = 25;
            this.hexText6.Leave += new System.EventHandler(this.hexText6_Leave);
            // 
            // pathText6
            // 
            this.pathText6.Location = new System.Drawing.Point(53, 163);
            this.pathText6.Name = "pathText6";
            this.pathText6.Size = new System.Drawing.Size(314, 20);
            this.pathText6.TabIndex = 24;
            // 
            // checkBox6
            // 
            this.checkBox6.AutoSize = true;
            this.checkBox6.Location = new System.Drawing.Point(15, 166);
            this.checkBox6.Name = "checkBox6";
            this.checkBox6.Size = new System.Drawing.Size(15, 14);
            this.checkBox6.TabIndex = 23;
            this.checkBox6.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(56, 229);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(97, 13);
            this.label4.TabIndex = 27;
            this.label4.Text = "Final File Size (hex)";
            // 
            // fileSizeHexText
            // 
            this.fileSizeHexText.Location = new System.Drawing.Point(159, 226);
            this.fileSizeHexText.Name = "fileSizeHexText";
            this.fileSizeHexText.Size = new System.Drawing.Size(101, 20);
            this.fileSizeHexText.TabIndex = 28;
            this.fileSizeHexText.Text = "0x7EFFF";
            this.fileSizeHexText.Leave += new System.EventHandler(this.fileSizeHexText_Leave);
            // 
            // createButton
            // 
            this.createButton.Location = new System.Drawing.Point(353, 231);
            this.createButton.Name = "createButton";
            this.createButton.Size = new System.Drawing.Size(75, 23);
            this.createButton.TabIndex = 29;
            this.createButton.Text = "Create";
            this.createButton.UseVisualStyleBackColor = true;
            this.createButton.Click += new System.EventHandler(this.createButton_Click);
            // 
            // fillByteHexText
            // 
            this.fillByteHexText.Location = new System.Drawing.Point(159, 250);
            this.fillByteHexText.Name = "fillByteHexText";
            this.fillByteHexText.Size = new System.Drawing.Size(101, 20);
            this.fillByteHexText.TabIndex = 31;
            this.fillByteHexText.Text = "0xF";
            this.fillByteHexText.Leave += new System.EventHandler(this.fillByteHexText_Leave);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(56, 253);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(69, 13);
            this.label5.TabIndex = 30;
            this.label5.Text = "Fill Byte (hex)";
            // 
            // savePathText
            // 
            this.savePathText.Location = new System.Drawing.Point(53, 203);
            this.savePathText.Name = "savePathText";
            this.savePathText.Size = new System.Drawing.Size(314, 20);
            this.savePathText.TabIndex = 32;
            this.savePathText.Text = "mergedFirmware.bin";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(55, 188);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(82, 13);
            this.label6.TabIndex = 33;
            this.label6.Text = "Save File Name";
            // 
            // saveButton
            // 
            this.saveButton.Location = new System.Drawing.Point(376, 200);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(26, 23);
            this.saveButton.TabIndex = 34;
            this.saveButton.Text = "...";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // BuildESP8266Flash
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(530, 280);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.savePathText);
            this.Controls.Add(this.fillByteHexText);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.createButton);
            this.Controls.Add(this.fileSizeHexText);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.selectButton6);
            this.Controls.Add(this.hexText6);
            this.Controls.Add(this.pathText6);
            this.Controls.Add(this.checkBox6);
            this.Controls.Add(this.selectButton5);
            this.Controls.Add(this.hexText5);
            this.Controls.Add(this.pathText5);
            this.Controls.Add(this.checkBox5);
            this.Controls.Add(this.selectButton4);
            this.Controls.Add(this.hexText4);
            this.Controls.Add(this.pathText4);
            this.Controls.Add(this.checkBox4);
            this.Controls.Add(this.selectButton3);
            this.Controls.Add(this.hexText3);
            this.Controls.Add(this.pathText3);
            this.Controls.Add(this.checkBox3);
            this.Controls.Add(this.selectButton2);
            this.Controls.Add(this.hexText2);
            this.Controls.Add(this.pathText2);
            this.Controls.Add(this.checkBox2);
            this.Controls.Add(this.selectButton1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.hexText1);
            this.Controls.Add(this.pathText1);
            this.Controls.Add(this.checkBox1);
            this.Name = "BuildESP8266Flash";
            this.Text = "BuildESP8266Flash";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.TextBox pathText1;
        private System.Windows.Forms.TextBox hexText1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button selectButton1;
        private System.Windows.Forms.Button selectButton2;
        private System.Windows.Forms.TextBox hexText2;
        private System.Windows.Forms.TextBox pathText2;
        private System.Windows.Forms.CheckBox checkBox2;
        private System.Windows.Forms.Button selectButton3;
        private System.Windows.Forms.TextBox hexText3;
        private System.Windows.Forms.TextBox pathText3;
        private System.Windows.Forms.CheckBox checkBox3;
        private System.Windows.Forms.Button selectButton4;
        private System.Windows.Forms.TextBox hexText4;
        private System.Windows.Forms.TextBox pathText4;
        private System.Windows.Forms.CheckBox checkBox4;
        private System.Windows.Forms.Button selectButton5;
        private System.Windows.Forms.TextBox hexText5;
        private System.Windows.Forms.TextBox pathText5;
        private System.Windows.Forms.CheckBox checkBox5;
        private System.Windows.Forms.Button selectButton6;
        private System.Windows.Forms.TextBox hexText6;
        private System.Windows.Forms.TextBox pathText6;
        private System.Windows.Forms.CheckBox checkBox6;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox fileSizeHexText;
        private System.Windows.Forms.Button createButton;
        private System.Windows.Forms.TextBox fillByteHexText;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox savePathText;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button saveButton;
    }
}

