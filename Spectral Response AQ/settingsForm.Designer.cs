namespace Spectral_Response_AQ
{
    partial class settingsForm
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
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.label1 = new System.Windows.Forms.Label();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.saveLIASettingButton = new System.Windows.Forms.Button();
            this.saveSettingButton = new System.Windows.Forms.Button();
            this.deviceMessageBox = new System.Windows.Forms.TextBox();
            this.initButton = new System.Windows.Forms.Button();
            this.refreshButton = new System.Windows.Forms.Button();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.refLockInAmpTextBox = new System.Windows.Forms.TextBox();
            this.MainLIATextBox = new System.Windows.Forms.TextBox();
            this.NIRMCTextBox = new System.Windows.Forms.TextBox();
            this.VisMCTextBox = new System.Windows.Forms.TextBox();
            this.assignRefLockInAmpButton = new System.Windows.Forms.Button();
            this.assignMainLockInAmpButton = new System.Windows.Forms.Button();
            this.assignNIRMCButton = new System.Windows.Forms.Button();
            this.assignVISMCButton = new System.Windows.Forms.Button();
            this.VISASessionListBox = new System.Windows.Forms.ListBox();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.tabControl1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(497, 464);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(489, 438);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "GBIP setting";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.label1);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(489, 438);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Monochromators";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(234, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Dial-Wavelength parameters of monochromators";
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.saveLIASettingButton);
            this.tabPage3.Controls.Add(this.saveSettingButton);
            this.tabPage3.Controls.Add(this.deviceMessageBox);
            this.tabPage3.Controls.Add(this.initButton);
            this.tabPage3.Controls.Add(this.refreshButton);
            this.tabPage3.Controls.Add(this.checkBox1);
            this.tabPage3.Controls.Add(this.label6);
            this.tabPage3.Controls.Add(this.label5);
            this.tabPage3.Controls.Add(this.label4);
            this.tabPage3.Controls.Add(this.label3);
            this.tabPage3.Controls.Add(this.refLockInAmpTextBox);
            this.tabPage3.Controls.Add(this.MainLIATextBox);
            this.tabPage3.Controls.Add(this.NIRMCTextBox);
            this.tabPage3.Controls.Add(this.VisMCTextBox);
            this.tabPage3.Controls.Add(this.assignRefLockInAmpButton);
            this.tabPage3.Controls.Add(this.assignMainLockInAmpButton);
            this.tabPage3.Controls.Add(this.assignNIRMCButton);
            this.tabPage3.Controls.Add(this.assignVISMCButton);
            this.tabPage3.Controls.Add(this.VISASessionListBox);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(489, 438);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "VISA Setting";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // saveLIASettingButton
            // 
            this.saveLIASettingButton.Location = new System.Drawing.Point(364, 390);
            this.saveLIASettingButton.Name = "saveLIASettingButton";
            this.saveLIASettingButton.Size = new System.Drawing.Size(104, 42);
            this.saveLIASettingButton.TabIndex = 17;
            this.saveLIASettingButton.Text = "Save LIA setting to file";
            this.saveLIASettingButton.UseVisualStyleBackColor = true;
            this.saveLIASettingButton.Click += new System.EventHandler(this.saveLIASettingButton_Click);
            // 
            // saveSettingButton
            // 
            this.saveSettingButton.Location = new System.Drawing.Point(238, 390);
            this.saveSettingButton.Name = "saveSettingButton";
            this.saveSettingButton.Size = new System.Drawing.Size(107, 42);
            this.saveSettingButton.TabIndex = 1;
            this.saveSettingButton.Text = "Save MC setting to file";
            this.saveSettingButton.UseVisualStyleBackColor = true;
            this.saveSettingButton.Click += new System.EventHandler(this.saveSettingButton_Click);
            // 
            // deviceMessageBox
            // 
            this.deviceMessageBox.Location = new System.Drawing.Point(7, 320);
            this.deviceMessageBox.Multiline = true;
            this.deviceMessageBox.Name = "deviceMessageBox";
            this.deviceMessageBox.Size = new System.Drawing.Size(461, 57);
            this.deviceMessageBox.TabIndex = 16;
            // 
            // initButton
            // 
            this.initButton.Location = new System.Drawing.Point(333, 266);
            this.initButton.Name = "initButton";
            this.initButton.Size = new System.Drawing.Size(135, 35);
            this.initButton.TabIndex = 15;
            this.initButton.Text = "Initialize";
            this.initButton.UseVisualStyleBackColor = true;
            this.initButton.Click += new System.EventHandler(this.initButton_Click);
            // 
            // refreshButton
            // 
            this.refreshButton.Location = new System.Drawing.Point(143, 266);
            this.refreshButton.Name = "refreshButton";
            this.refreshButton.Size = new System.Drawing.Size(89, 29);
            this.refreshButton.TabIndex = 14;
            this.refreshButton.Text = "Refresh";
            this.refreshButton.UseVisualStyleBackColor = true;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(330, 232);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(149, 17);
            this.checkBox1.TabIndex = 13;
            this.checkBox1.Text = "Enable reference detector";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(330, 190);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(138, 13);
            this.label6.TabIndex = 12;
            this.label6.Text = "Reference Lock-In Amplifier";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(330, 129);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(110, 13);
            this.label5.TabIndex = 11;
            this.label5.Text = "Main Lock-in Amplifier";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(330, 67);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(106, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "NIR  Monochromator";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(330, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(114, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "Visible Monochromator";
            // 
            // refLockInAmpTextBox
            // 
            this.refLockInAmpTextBox.Location = new System.Drawing.Point(330, 206);
            this.refLockInAmpTextBox.Name = "refLockInAmpTextBox";
            this.refLockInAmpTextBox.Size = new System.Drawing.Size(138, 20);
            this.refLockInAmpTextBox.TabIndex = 8;
            // 
            // MainLIATextBox
            // 
            this.MainLIATextBox.Location = new System.Drawing.Point(330, 145);
            this.MainLIATextBox.Name = "MainLIATextBox";
            this.MainLIATextBox.Size = new System.Drawing.Size(138, 20);
            this.MainLIATextBox.TabIndex = 7;
            // 
            // NIRMCTextBox
            // 
            this.NIRMCTextBox.Location = new System.Drawing.Point(330, 82);
            this.NIRMCTextBox.Name = "NIRMCTextBox";
            this.NIRMCTextBox.Size = new System.Drawing.Size(138, 20);
            this.NIRMCTextBox.TabIndex = 6;
            // 
            // VisMCTextBox
            // 
            this.VisMCTextBox.Location = new System.Drawing.Point(330, 25);
            this.VisMCTextBox.Name = "VisMCTextBox";
            this.VisMCTextBox.Size = new System.Drawing.Size(138, 20);
            this.VisMCTextBox.TabIndex = 5;
            // 
            // assignRefLockInAmpButton
            // 
            this.assignRefLockInAmpButton.Location = new System.Drawing.Point(239, 204);
            this.assignRefLockInAmpButton.Name = "assignRefLockInAmpButton";
            this.assignRefLockInAmpButton.Size = new System.Drawing.Size(75, 23);
            this.assignRefLockInAmpButton.TabIndex = 4;
            this.assignRefLockInAmpButton.Text = "-->";
            this.assignRefLockInAmpButton.UseVisualStyleBackColor = true;
            this.assignRefLockInAmpButton.Click += new System.EventHandler(this.assignRefLockInAmpButton_Click);
            // 
            // assignMainLockInAmpButton
            // 
            this.assignMainLockInAmpButton.Location = new System.Drawing.Point(239, 143);
            this.assignMainLockInAmpButton.Name = "assignMainLockInAmpButton";
            this.assignMainLockInAmpButton.Size = new System.Drawing.Size(75, 23);
            this.assignMainLockInAmpButton.TabIndex = 3;
            this.assignMainLockInAmpButton.Text = "-->";
            this.assignMainLockInAmpButton.UseVisualStyleBackColor = true;
            this.assignMainLockInAmpButton.Click += new System.EventHandler(this.assignMainLockInAmpButton_Click);
            // 
            // assignNIRMCButton
            // 
            this.assignNIRMCButton.Location = new System.Drawing.Point(239, 82);
            this.assignNIRMCButton.Name = "assignNIRMCButton";
            this.assignNIRMCButton.Size = new System.Drawing.Size(75, 23);
            this.assignNIRMCButton.TabIndex = 2;
            this.assignNIRMCButton.Text = "-->";
            this.assignNIRMCButton.UseVisualStyleBackColor = true;
            this.assignNIRMCButton.Click += new System.EventHandler(this.assignNIRMCButton_Click);
            // 
            // assignVISMCButton
            // 
            this.assignVISMCButton.Location = new System.Drawing.Point(238, 23);
            this.assignVISMCButton.Name = "assignVISMCButton";
            this.assignVISMCButton.Size = new System.Drawing.Size(75, 23);
            this.assignVISMCButton.TabIndex = 1;
            this.assignVISMCButton.Text = "-->";
            this.assignVISMCButton.UseVisualStyleBackColor = true;
            this.assignVISMCButton.Click += new System.EventHandler(this.assignVISMCButton_Click);
            // 
            // VISASessionListBox
            // 
            this.VISASessionListBox.FormattingEnabled = true;
            this.VISASessionListBox.Location = new System.Drawing.Point(6, 6);
            this.VISASessionListBox.Name = "VISASessionListBox";
            this.VISASessionListBox.Size = new System.Drawing.Size(226, 238);
            this.VISASessionListBox.TabIndex = 0;
            // 
            // settingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(521, 532);
            this.Controls.Add(this.tabControl1);
            this.Name = "settingsForm";
            this.Text = "Equipments settings";
            this.Load += new System.EventHandler(this.settingsForm_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox refLockInAmpTextBox;
        private System.Windows.Forms.TextBox MainLIATextBox;
        private System.Windows.Forms.TextBox NIRMCTextBox;
        private System.Windows.Forms.TextBox VisMCTextBox;
        private System.Windows.Forms.Button assignRefLockInAmpButton;
        private System.Windows.Forms.Button assignMainLockInAmpButton;
        private System.Windows.Forms.Button assignNIRMCButton;
        private System.Windows.Forms.Button assignVISMCButton;
        private System.Windows.Forms.ListBox VISASessionListBox;
        private System.Windows.Forms.Button refreshButton;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.Button initButton;
        private System.Windows.Forms.TextBox deviceMessageBox;
        private System.Windows.Forms.Button saveSettingButton;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.Button saveLIASettingButton;

    }
}