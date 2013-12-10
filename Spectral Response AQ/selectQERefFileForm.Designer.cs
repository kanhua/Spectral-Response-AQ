namespace Spectral_Response_AQ
{
    partial class selectQERefFileForm
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
            this.DUTFileTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.range1REFFileTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.detector1SettingBox = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.selectDUTButton = new System.Windows.Forms.Button();
            this.selectREFFile1 = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.convertButton = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.switchWavelengthTextBox = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.detector2SettingBox = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.range2REFFileTextBox = new System.Windows.Forms.TextBox();
            this.selectREFFile2 = new System.Windows.Forms.Button();
            this.enableCombineCheckBox = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // DUTFileTextBox
            // 
            this.DUTFileTextBox.Location = new System.Drawing.Point(25, 39);
            this.DUTFileTextBox.Name = "DUTFileTextBox";
            this.DUTFileTextBox.Size = new System.Drawing.Size(390, 20);
            this.DUTFileTextBox.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(25, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(181, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Photocurrent file of device under test";
            // 
            // range1REFFileTextBox
            // 
            this.range1REFFileTextBox.Location = new System.Drawing.Point(22, 98);
            this.range1REFFileTextBox.Name = "range1REFFileTextBox";
            this.range1REFFileTextBox.Size = new System.Drawing.Size(390, 20);
            this.range1REFFileTextBox.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(25, 79);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(195, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Photocurrent file of reference detector 1";
            // 
            // detector1SettingBox
            // 
            this.detector1SettingBox.FormattingEnabled = true;
            this.detector1SettingBox.Items.AddRange(new object[] {
            "Si detector (818-UV)",
            "Ge detector (818-IR-L)"});
            this.detector1SettingBox.Location = new System.Drawing.Point(22, 148);
            this.detector1SettingBox.Name = "detector1SettingBox";
            this.detector1SettingBox.Size = new System.Drawing.Size(134, 21);
            this.detector1SettingBox.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(25, 132);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(108, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Reference detector 1";
            // 
            // selectDUTButton
            // 
            this.selectDUTButton.Location = new System.Drawing.Point(423, 39);
            this.selectDUTButton.Name = "selectDUTButton";
            this.selectDUTButton.Size = new System.Drawing.Size(75, 23);
            this.selectDUTButton.TabIndex = 6;
            this.selectDUTButton.Text = "Select File";
            this.selectDUTButton.UseVisualStyleBackColor = true;
            this.selectDUTButton.Click += new System.EventHandler(this.selectDUTButton_Click);
            // 
            // selectREFFile1
            // 
            this.selectREFFile1.Location = new System.Drawing.Point(422, 94);
            this.selectREFFile1.Name = "selectREFFile1";
            this.selectREFFile1.Size = new System.Drawing.Size(75, 23);
            this.selectREFFile1.TabIndex = 7;
            this.selectREFFile1.Text = "Select File";
            this.selectREFFile1.UseVisualStyleBackColor = true;
            this.selectREFFile1.Click += new System.EventHandler(this.selectREFFile_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // convertButton
            // 
            this.convertButton.Location = new System.Drawing.Point(559, 331);
            this.convertButton.Name = "convertButton";
            this.convertButton.Size = new System.Drawing.Size(107, 45);
            this.convertButton.TabIndex = 8;
            this.convertButton.Text = "Convert";
            this.convertButton.UseVisualStyleBackColor = true;
            this.convertButton.Click += new System.EventHandler(this.convertButton_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(25, 245);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(116, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "switchover wavelength";
            // 
            // switchWavelengthTextBox
            // 
            this.switchWavelengthTextBox.Enabled = false;
            this.switchWavelengthTextBox.Location = new System.Drawing.Point(22, 261);
            this.switchWavelengthTextBox.Name = "switchWavelengthTextBox";
            this.switchWavelengthTextBox.Size = new System.Drawing.Size(89, 20);
            this.switchWavelengthTextBox.TabIndex = 11;
            this.switchWavelengthTextBox.Text = "1000";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(25, 347);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(108, 13);
            this.label5.TabIndex = 15;
            this.label5.Text = "Reference detector 2";
            // 
            // detector2SettingBox
            // 
            this.detector2SettingBox.Enabled = false;
            this.detector2SettingBox.FormattingEnabled = true;
            this.detector2SettingBox.Items.AddRange(new object[] {
            "Si detector (818-UV)",
            "Ge detector (818-IR-L)"});
            this.detector2SettingBox.Location = new System.Drawing.Point(22, 363);
            this.detector2SettingBox.Name = "detector2SettingBox";
            this.detector2SettingBox.Size = new System.Drawing.Size(134, 21);
            this.detector2SettingBox.TabIndex = 14;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(25, 297);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(195, 13);
            this.label6.TabIndex = 13;
            this.label6.Text = "Photocurrent file of reference detector 2";
            // 
            // range2REFFileTextBox
            // 
            this.range2REFFileTextBox.Enabled = false;
            this.range2REFFileTextBox.Location = new System.Drawing.Point(22, 313);
            this.range2REFFileTextBox.Name = "range2REFFileTextBox";
            this.range2REFFileTextBox.Size = new System.Drawing.Size(390, 20);
            this.range2REFFileTextBox.TabIndex = 12;
            // 
            // selectREFFile2
            // 
            this.selectREFFile2.Location = new System.Drawing.Point(423, 310);
            this.selectREFFile2.Name = "selectREFFile2";
            this.selectREFFile2.Size = new System.Drawing.Size(75, 23);
            this.selectREFFile2.TabIndex = 16;
            this.selectREFFile2.Text = "Select File";
            this.selectREFFile2.UseVisualStyleBackColor = true;
            this.selectREFFile2.Click += new System.EventHandler(this.selectREFFile2_Click);
            // 
            // enableCombineCheckBox
            // 
            this.enableCombineCheckBox.AutoSize = true;
            this.enableCombineCheckBox.Location = new System.Drawing.Point(22, 213);
            this.enableCombineCheckBox.Name = "enableCombineCheckBox";
            this.enableCombineCheckBox.Size = new System.Drawing.Size(164, 17);
            this.enableCombineCheckBox.TabIndex = 17;
            this.enableCombineCheckBox.Text = "Combined with another range";
            this.enableCombineCheckBox.UseVisualStyleBackColor = true;
            this.enableCombineCheckBox.CheckedChanged += new System.EventHandler(this.enableCombineCheckBox_CheckedChanged);
            // 
            // selectQERefFileForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(708, 431);
            this.Controls.Add(this.enableCombineCheckBox);
            this.Controls.Add(this.selectREFFile2);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.detector2SettingBox);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.range2REFFileTextBox);
            this.Controls.Add(this.switchWavelengthTextBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.convertButton);
            this.Controls.Add(this.selectREFFile1);
            this.Controls.Add(this.selectDUTButton);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.detector1SettingBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.range1REFFileTextBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.DUTFileTextBox);
            this.Name = "selectQERefFileForm";
            this.Text = "Select a DUT and REF files";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox DUTFileTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox range1REFFileTextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox detector1SettingBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button selectDUTButton;
        private System.Windows.Forms.Button selectREFFile1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button convertButton;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox switchWavelengthTextBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox detector2SettingBox;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox range2REFFileTextBox;
        private System.Windows.Forms.Button selectREFFile2;
        private System.Windows.Forms.CheckBox enableCombineCheckBox;
    }
}