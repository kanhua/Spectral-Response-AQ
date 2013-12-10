namespace Spectral_Response_AQ
{
    partial class quickScanForm
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.stepTextBox = new System.Windows.Forms.TextBox();
            this.endWaveTextBox = new System.Windows.Forms.TextBox();
            this.startWaveTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dutLIAChannelComboBox = new System.Windows.Forms.ComboBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.mChromatorComboBox = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.deviceBiasTextBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.startMeasurementButton = new System.Windows.Forms.Button();
            this.filePathTextBox = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.selectPathButton = new System.Windows.Forms.Button();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.applyBiasSettingButton = new System.Windows.Forms.Button();
            this.lightBias3TextBox = new System.Windows.Forms.TextBox();
            this.lightBias2TextBox = new System.Windows.Forms.TextBox();
            this.lightBias1TextBox = new System.Windows.Forms.TextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label15 = new System.Windows.Forms.Label();
            this.refLIAChannelComboBox = new System.Windows.Forms.ComboBox();
            this.enableRefLIACheckBox = new System.Windows.Forms.CheckBox();
            this.autoRangeCheckbox = new System.Windows.Forms.CheckBox();
            this.throughDevBox = new System.Windows.Forms.CheckBox();
            this.label10 = new System.Windows.Forms.Label();
            this.calibrateButton = new System.Windows.Forms.Button();
            this.stopButton = new System.Windows.Forms.Button();
            this.lightAndGratingGroupBox = new System.Windows.Forms.GroupBox();
            this.label14 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.gratingComboBox = new System.Windows.Forms.ComboBox();
            this.lightSourceComboBox = new System.Windows.Forms.ComboBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.lightAndGratingGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.stepTextBox);
            this.groupBox1.Controls.Add(this.endWaveTextBox);
            this.groupBox1.Controls.Add(this.startWaveTextBox);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(13, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(253, 118);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Scan Wavelegnth";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(26, 88);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(27, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "step";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 63);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(83, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "end wavelength";
            // 
            // stepTextBox
            // 
            this.stepTextBox.Location = new System.Drawing.Point(97, 82);
            this.stepTextBox.Name = "stepTextBox";
            this.stepTextBox.Size = new System.Drawing.Size(100, 20);
            this.stepTextBox.TabIndex = 3;
            // 
            // endWaveTextBox
            // 
            this.endWaveTextBox.Location = new System.Drawing.Point(97, 56);
            this.endWaveTextBox.Name = "endWaveTextBox";
            this.endWaveTextBox.Size = new System.Drawing.Size(100, 20);
            this.endWaveTextBox.TabIndex = 2;
            // 
            // startWaveTextBox
            // 
            this.startWaveTextBox.Location = new System.Drawing.Point(97, 30);
            this.startWaveTextBox.Name = "startWaveTextBox";
            this.startWaveTextBox.Size = new System.Drawing.Size(100, 20);
            this.startWaveTextBox.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(85, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "start wavelength";
            // 
            // dutLIAChannelComboBox
            // 
            this.dutLIAChannelComboBox.FormattingEnabled = true;
            this.dutLIAChannelComboBox.Items.AddRange(new object[] {
            "ChA-Voltage",
            "ChB-Current(Reference)",
            "ChB-Low noise mode"});
            this.dutLIAChannelComboBox.Location = new System.Drawing.Point(111, 24);
            this.dutLIAChannelComboBox.Name = "dutLIAChannelComboBox";
            this.dutLIAChannelComboBox.Size = new System.Drawing.Size(132, 21);
            this.dutLIAChannelComboBox.TabIndex = 4;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(15, 27);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(90, 13);
            this.label12.TabIndex = 33;
            this.label12.Text = "DUT LIA channel";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(11, 499);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(51, 13);
            this.label11.TabIndex = 32;
            this.label11.Text = "Comment";
            // 
            // textBox5
            // 
            this.textBox5.Location = new System.Drawing.Point(12, 515);
            this.textBox5.Multiline = true;
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new System.Drawing.Size(254, 68);
            this.textBox5.TabIndex = 31;
            // 
            // mChromatorComboBox
            // 
            this.mChromatorComboBox.FormattingEnabled = true;
            this.mChromatorComboBox.Location = new System.Drawing.Point(99, 197);
            this.mChromatorComboBox.Name = "mChromatorComboBox";
            this.mChromatorComboBox.Size = new System.Drawing.Size(132, 21);
            this.mChromatorComboBox.TabIndex = 5;
            this.mChromatorComboBox.SelectedIndexChanged += new System.EventHandler(this.mChromatorComboBox_SelectedIndexChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(10, 198);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(81, 13);
            this.label9.TabIndex = 27;
            this.label9.Text = "Monochromator";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(20, 99);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(57, 13);
            this.label7.TabIndex = 25;
            this.label7.Text = "light bias 3";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(20, 77);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(57, 13);
            this.label6.TabIndex = 24;
            this.label6.Text = "light bias 2";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(20, 54);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(57, 13);
            this.label5.TabIndex = 23;
            this.label5.Text = "light bias 1";
            // 
            // deviceBiasTextBox
            // 
            this.deviceBiasTextBox.Location = new System.Drawing.Point(87, 30);
            this.deviceBiasTextBox.Name = "deviceBiasTextBox";
            this.deviceBiasTextBox.Size = new System.Drawing.Size(36, 20);
            this.deviceBiasTextBox.TabIndex = 6;
            this.deviceBiasTextBox.Text = "0";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(20, 33);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(61, 13);
            this.label4.TabIndex = 21;
            this.label4.Text = "device bias";
            // 
            // startMeasurementButton
            // 
            this.startMeasurementButton.Location = new System.Drawing.Point(544, 531);
            this.startMeasurementButton.Name = "startMeasurementButton";
            this.startMeasurementButton.Size = new System.Drawing.Size(108, 52);
            this.startMeasurementButton.TabIndex = 35;
            this.startMeasurementButton.Text = "Start Measurement";
            this.startMeasurementButton.UseVisualStyleBackColor = true;
            this.startMeasurementButton.Click += new System.EventHandler(this.startMeasurementButton_Click);
            // 
            // filePathTextBox
            // 
            this.filePathTextBox.Location = new System.Drawing.Point(329, 417);
            this.filePathTextBox.Multiline = true;
            this.filePathTextBox.Name = "filePathTextBox";
            this.filePathTextBox.ReadOnly = true;
            this.filePathTextBox.Size = new System.Drawing.Size(324, 58);
            this.filePathTextBox.TabIndex = 36;
            this.filePathTextBox.Text = "save file";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(326, 393);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(84, 13);
            this.label13.TabIndex = 37;
            this.label13.Text = "File Saving Path";
            // 
            // selectPathButton
            // 
            this.selectPathButton.Location = new System.Drawing.Point(544, 481);
            this.selectPathButton.Name = "selectPathButton";
            this.selectPathButton.Size = new System.Drawing.Size(109, 31);
            this.selectPathButton.TabIndex = 38;
            this.selectPathButton.Text = "Set File Path";
            this.selectPathButton.UseVisualStyleBackColor = true;
            this.selectPathButton.Click += new System.EventHandler(this.selectPathButton_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.applyBiasSettingButton);
            this.groupBox2.Controls.Add(this.lightBias3TextBox);
            this.groupBox2.Controls.Add(this.lightBias2TextBox);
            this.groupBox2.Controls.Add(this.lightBias1TextBox);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.deviceBiasTextBox);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Location = new System.Drawing.Point(15, 366);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(251, 130);
            this.groupBox2.TabIndex = 39;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Bias Setting";
            // 
            // applyBiasSettingButton
            // 
            this.applyBiasSettingButton.Location = new System.Drawing.Point(154, 77);
            this.applyBiasSettingButton.Name = "applyBiasSettingButton";
            this.applyBiasSettingButton.Size = new System.Drawing.Size(75, 42);
            this.applyBiasSettingButton.TabIndex = 29;
            this.applyBiasSettingButton.Text = "Apply Bias Setting";
            this.applyBiasSettingButton.UseVisualStyleBackColor = true;
            this.applyBiasSettingButton.Click += new System.EventHandler(this.applyBiasSettingButton_Click);
            // 
            // lightBias3TextBox
            // 
            this.lightBias3TextBox.Location = new System.Drawing.Point(87, 99);
            this.lightBias3TextBox.Name = "lightBias3TextBox";
            this.lightBias3TextBox.Size = new System.Drawing.Size(36, 20);
            this.lightBias3TextBox.TabIndex = 9;
            this.lightBias3TextBox.Text = "0";
            // 
            // lightBias2TextBox
            // 
            this.lightBias2TextBox.Location = new System.Drawing.Point(87, 77);
            this.lightBias2TextBox.Name = "lightBias2TextBox";
            this.lightBias2TextBox.Size = new System.Drawing.Size(36, 20);
            this.lightBias2TextBox.TabIndex = 8;
            this.lightBias2TextBox.Text = "0";
            // 
            // lightBias1TextBox
            // 
            this.lightBias1TextBox.Location = new System.Drawing.Point(87, 54);
            this.lightBias1TextBox.Name = "lightBias1TextBox";
            this.lightBias1TextBox.Size = new System.Drawing.Size(36, 20);
            this.lightBias1TextBox.TabIndex = 7;
            this.lightBias1TextBox.Text = "0";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label15);
            this.groupBox3.Controls.Add(this.refLIAChannelComboBox);
            this.groupBox3.Controls.Add(this.enableRefLIACheckBox);
            this.groupBox3.Controls.Add(this.autoRangeCheckbox);
            this.groupBox3.Controls.Add(this.throughDevBox);
            this.groupBox3.Controls.Add(this.label10);
            this.groupBox3.Controls.Add(this.label12);
            this.groupBox3.Controls.Add(this.dutLIAChannelComboBox);
            this.groupBox3.Controls.Add(this.mChromatorComboBox);
            this.groupBox3.Controls.Add(this.label9);
            this.groupBox3.Location = new System.Drawing.Point(13, 136);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(253, 224);
            this.groupBox3.TabIndex = 40;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Lock in amplifier and grating";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(12, 146);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(84, 13);
            this.label15.TabIndex = 40;
            this.label15.Text = "Ref LIA channel";
            // 
            // refLIAChannelComboBox
            // 
            this.refLIAChannelComboBox.FormattingEnabled = true;
            this.refLIAChannelComboBox.Items.AddRange(new object[] {
            "ChA-Voltage",
            "ChB-Current(Reference)",
            "ChB-Low noise mode"});
            this.refLIAChannelComboBox.Location = new System.Drawing.Point(108, 139);
            this.refLIAChannelComboBox.Name = "refLIAChannelComboBox";
            this.refLIAChannelComboBox.Size = new System.Drawing.Size(132, 21);
            this.refLIAChannelComboBox.TabIndex = 39;
            // 
            // enableRefLIACheckBox
            // 
            this.enableRefLIACheckBox.AutoSize = true;
            this.enableRefLIACheckBox.Location = new System.Drawing.Point(15, 97);
            this.enableRefLIACheckBox.Name = "enableRefLIACheckBox";
            this.enableRefLIACheckBox.Size = new System.Drawing.Size(98, 17);
            this.enableRefLIACheckBox.TabIndex = 38;
            this.enableRefLIACheckBox.Text = "Enable Ref LIA";
            this.enableRefLIACheckBox.UseVisualStyleBackColor = true;
            // 
            // autoRangeCheckbox
            // 
            this.autoRangeCheckbox.AutoSize = true;
            this.autoRangeCheckbox.Location = new System.Drawing.Point(15, 74);
            this.autoRangeCheckbox.Name = "autoRangeCheckbox";
            this.autoRangeCheckbox.Size = new System.Drawing.Size(113, 17);
            this.autoRangeCheckbox.TabIndex = 37;
            this.autoRangeCheckbox.Text = "Enable auto range";
            this.autoRangeCheckbox.UseVisualStyleBackColor = true;
            // 
            // throughDevBox
            // 
            this.throughDevBox.AutoSize = true;
            this.throughDevBox.Location = new System.Drawing.Point(15, 51);
            this.throughDevBox.Name = "throughDevBox";
            this.throughDevBox.Size = new System.Drawing.Size(143, 17);
            this.throughDevBox.TabIndex = 36;
            this.throughDevBox.Text = "Through device bias box";
            this.throughDevBox.UseVisualStyleBackColor = true;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(12, 168);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(207, 13);
            this.label10.TabIndex = 35;
            this.label10.Text = "Choose Ch.B if it\'s reference channel scan";
            // 
            // calibrateButton
            // 
            this.calibrateButton.Location = new System.Drawing.Point(321, 534);
            this.calibrateButton.Name = "calibrateButton";
            this.calibrateButton.Size = new System.Drawing.Size(75, 47);
            this.calibrateButton.TabIndex = 41;
            this.calibrateButton.Text = "Calibrate...";
            this.calibrateButton.UseVisualStyleBackColor = true;
            this.calibrateButton.Click += new System.EventHandler(this.calibrateButton_Click);
            // 
            // stopButton
            // 
            this.stopButton.Location = new System.Drawing.Point(414, 531);
            this.stopButton.Name = "stopButton";
            this.stopButton.Size = new System.Drawing.Size(110, 52);
            this.stopButton.TabIndex = 42;
            this.stopButton.Text = "Stop Measurement";
            this.stopButton.UseVisualStyleBackColor = true;
            this.stopButton.Click += new System.EventHandler(this.stopButton_Click);
            // 
            // lightAndGratingGroupBox
            // 
            this.lightAndGratingGroupBox.Controls.Add(this.label14);
            this.lightAndGratingGroupBox.Controls.Add(this.label8);
            this.lightAndGratingGroupBox.Controls.Add(this.gratingComboBox);
            this.lightAndGratingGroupBox.Controls.Add(this.lightSourceComboBox);
            this.lightAndGratingGroupBox.Location = new System.Drawing.Point(300, 23);
            this.lightAndGratingGroupBox.Name = "lightAndGratingGroupBox";
            this.lightAndGratingGroupBox.Size = new System.Drawing.Size(306, 107);
            this.lightAndGratingGroupBox.TabIndex = 43;
            this.lightAndGratingGroupBox.TabStop = false;
            this.lightAndGratingGroupBox.Text = "Light source and grating(TMc300 only)";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(29, 69);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(41, 13);
            this.label14.TabIndex = 3;
            this.label14.Text = "Grating";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(26, 29);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(67, 13);
            this.label8.TabIndex = 2;
            this.label8.Text = "Light Source";
            // 
            // gratingComboBox
            // 
            this.gratingComboBox.FormattingEnabled = true;
            this.gratingComboBox.Items.AddRange(new object[] {
            "1",
            "2",
            "3"});
            this.gratingComboBox.Location = new System.Drawing.Point(120, 69);
            this.gratingComboBox.Name = "gratingComboBox";
            this.gratingComboBox.Size = new System.Drawing.Size(160, 21);
            this.gratingComboBox.TabIndex = 1;
            // 
            // lightSourceComboBox
            // 
            this.lightSourceComboBox.FormattingEnabled = true;
            this.lightSourceComboBox.Items.AddRange(new object[] {
            "Halogen",
            "Xe"});
            this.lightSourceComboBox.Location = new System.Drawing.Point(120, 22);
            this.lightSourceComboBox.Name = "lightSourceComboBox";
            this.lightSourceComboBox.Size = new System.Drawing.Size(160, 21);
            this.lightSourceComboBox.TabIndex = 0;
            // 
            // quickScanForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(677, 594);
            this.Controls.Add(this.lightAndGratingGroupBox);
            this.Controls.Add(this.stopButton);
            this.Controls.Add(this.calibrateButton);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.selectPathButton);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.filePathTextBox);
            this.Controls.Add(this.startMeasurementButton);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.textBox5);
            this.Controls.Add(this.groupBox1);
            this.Name = "quickScanForm";
            this.Text = "Quick Scan Form";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.lightAndGratingGroupBox.ResumeLayout(false);
            this.lightAndGratingGroupBox.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox stepTextBox;
        private System.Windows.Forms.TextBox endWaveTextBox;
        private System.Windows.Forms.TextBox startWaveTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox dutLIAChannelComboBox;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox textBox5;
        private System.Windows.Forms.ComboBox mChromatorComboBox;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox deviceBiasTextBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button startMeasurementButton;
        private System.Windows.Forms.TextBox filePathTextBox;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Button selectPathButton;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox lightBias3TextBox;
        private System.Windows.Forms.TextBox lightBias2TextBox;
        private System.Windows.Forms.TextBox lightBias1TextBox;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button calibrateButton;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button applyBiasSettingButton;
        private System.Windows.Forms.Button stopButton;
        private System.Windows.Forms.CheckBox throughDevBox;
        private System.Windows.Forms.CheckBox autoRangeCheckbox;
        private System.Windows.Forms.GroupBox lightAndGratingGroupBox;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox gratingComboBox;
        private System.Windows.Forms.ComboBox lightSourceComboBox;
        private System.Windows.Forms.CheckBox enableRefLIACheckBox;
        private System.Windows.Forms.ComboBox refLIAChannelComboBox;
        private System.Windows.Forms.Label label15;
    }
}