namespace Spectral_Response_AQ
{
    partial class scanSettingForm
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.extraDelayTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tcMultiplierTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.arbDelayTextBox = new System.Windows.Forms.TextBox();
            this.manualMode2RadioButton = new System.Windows.Forms.RadioButton();
            this.manualMode1RadioButton = new System.Windows.Forms.RadioButton();
            this.defaultRadioButton = new System.Windows.Forms.RadioButton();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.OKButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(7, 8);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(397, 492);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.groupBox1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(389, 466);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Delay";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.extraDelayTextBox);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.tcMultiplierTextBox);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.arbDelayTextBox);
            this.groupBox1.Controls.Add(this.manualMode2RadioButton);
            this.groupBox1.Controls.Add(this.manualMode1RadioButton);
            this.groupBox1.Controls.Add(this.defaultRadioButton);
            this.groupBox1.Location = new System.Drawing.Point(6, 22);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(377, 178);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Lock-in amplifier delay";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(266, 74);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(20, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "ms";
            // 
            // extraDelayTextBox
            // 
            this.extraDelayTextBox.Location = new System.Drawing.Point(214, 70);
            this.extraDelayTextBox.Name = "extraDelayTextBox";
            this.extraDelayTextBox.Size = new System.Drawing.Size(46, 20);
            this.extraDelayTextBox.TabIndex = 7;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(113, 74);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(94, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "X time constants +";
            // 
            // tcMultiplierTextBox
            // 
            this.tcMultiplierTextBox.Location = new System.Drawing.Point(67, 71);
            this.tcMultiplierTextBox.Name = "tcMultiplierTextBox";
            this.tcMultiplierTextBox.Size = new System.Drawing.Size(40, 20);
            this.tcMultiplierTextBox.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(129, 127);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(203, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "ms after a step change of monochromator";
            // 
            // arbDelayTextBox
            // 
            this.arbDelayTextBox.Location = new System.Drawing.Point(67, 122);
            this.arbDelayTextBox.Name = "arbDelayTextBox";
            this.arbDelayTextBox.Size = new System.Drawing.Size(56, 20);
            this.arbDelayTextBox.TabIndex = 3;
            // 
            // manualMode2RadioButton
            // 
            this.manualMode2RadioButton.AutoSize = true;
            this.manualMode2RadioButton.Enabled = false;
            this.manualMode2RadioButton.Location = new System.Drawing.Point(15, 123);
            this.manualMode2RadioButton.Name = "manualMode2RadioButton";
            this.manualMode2RadioButton.Size = new System.Drawing.Size(52, 17);
            this.manualMode2RadioButton.TabIndex = 2;
            this.manualMode2RadioButton.TabStop = true;
            this.manualMode2RadioButton.Text = "Delay";
            this.manualMode2RadioButton.UseVisualStyleBackColor = true;
            // 
            // manualMode1RadioButton
            // 
            this.manualMode1RadioButton.AutoSize = true;
            this.manualMode1RadioButton.Location = new System.Drawing.Point(15, 72);
            this.manualMode1RadioButton.Name = "manualMode1RadioButton";
            this.manualMode1RadioButton.Size = new System.Drawing.Size(52, 17);
            this.manualMode1RadioButton.TabIndex = 1;
            this.manualMode1RadioButton.TabStop = true;
            this.manualMode1RadioButton.Text = "Delay";
            this.manualMode1RadioButton.UseVisualStyleBackColor = true;
            // 
            // defaultRadioButton
            // 
            this.defaultRadioButton.AutoSize = true;
            this.defaultRadioButton.Location = new System.Drawing.Point(15, 19);
            this.defaultRadioButton.Name = "defaultRadioButton";
            this.defaultRadioButton.Size = new System.Drawing.Size(95, 17);
            this.defaultRadioButton.TabIndex = 0;
            this.defaultRadioButton.TabStop = true;
            this.defaultRadioButton.Text = "Default Setting";
            this.defaultRadioButton.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(389, 466);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "tabPage2";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // OKButton
            // 
            this.OKButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.OKButton.Location = new System.Drawing.Point(244, 508);
            this.OKButton.Name = "OKButton";
            this.OKButton.Size = new System.Drawing.Size(75, 23);
            this.OKButton.TabIndex = 1;
            this.OKButton.Text = "OK";
            this.OKButton.UseVisualStyleBackColor = true;
            this.OKButton.Click += new System.EventHandler(this.OKButton_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelButton.Location = new System.Drawing.Point(325, 508);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 2;
            this.cancelButton.Text = "cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            // 
            // scanSettingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(416, 543);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.OKButton);
            this.Controls.Add(this.tabControl1);
            this.Name = "scanSettingForm";
            this.Text = "Scan Setting";
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton manualMode2RadioButton;
        private System.Windows.Forms.RadioButton manualMode1RadioButton;
        private System.Windows.Forms.RadioButton defaultRadioButton;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox arbDelayTextBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox extraDelayTextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tcMultiplierTextBox;
        private System.Windows.Forms.Button OKButton;
        private System.Windows.Forms.Button cancelButton;
    }
}