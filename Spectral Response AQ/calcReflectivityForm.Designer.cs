namespace Spectral_Response_AQ
{
    partial class calcReflectivityForm
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
            this.referenceTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.mirrorRefTextBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.selectDUTButton = new System.Windows.Forms.Button();
            this.selectReferenceButton = new System.Windows.Forms.Button();
            this.selectMirrorRefButton = new System.Windows.Forms.Button();
            this.convertButton = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.switchWavelengthTextBox = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // DUTFileTextBox
            // 
            this.DUTFileTextBox.Location = new System.Drawing.Point(118, 30);
            this.DUTFileTextBox.Name = "DUTFileTextBox";
            this.DUTFileTextBox.Size = new System.Drawing.Size(351, 20);
            this.DUTFileTextBox.TabIndex = 0;
            // 
            // referenceTextBox
            // 
            this.referenceTextBox.Location = new System.Drawing.Point(118, 81);
            this.referenceTextBox.Name = "referenceTextBox";
            this.referenceTextBox.Size = new System.Drawing.Size(351, 20);
            this.referenceTextBox.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(91, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "DUT Reflectance";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 87);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(89, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Mirror reflectance";
            // 
            // mirrorRefTextBox
            // 
            this.mirrorRefTextBox.Location = new System.Drawing.Point(118, 178);
            this.mirrorRefTextBox.Name = "mirrorRefTextBox";
            this.mirrorRefTextBox.Size = new System.Drawing.Size(351, 20);
            this.mirrorRefTextBox.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(15, 181);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(83, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Mirror reflectivity";
            // 
            // selectDUTButton
            // 
            this.selectDUTButton.Location = new System.Drawing.Point(493, 27);
            this.selectDUTButton.Name = "selectDUTButton";
            this.selectDUTButton.Size = new System.Drawing.Size(75, 23);
            this.selectDUTButton.TabIndex = 6;
            this.selectDUTButton.Text = "Select File";
            this.selectDUTButton.UseVisualStyleBackColor = true;
            this.selectDUTButton.Click += new System.EventHandler(this.selectDUTButton_Click);
            // 
            // selectReferenceButton
            // 
            this.selectReferenceButton.Location = new System.Drawing.Point(493, 81);
            this.selectReferenceButton.Name = "selectReferenceButton";
            this.selectReferenceButton.Size = new System.Drawing.Size(75, 23);
            this.selectReferenceButton.TabIndex = 7;
            this.selectReferenceButton.Text = "Select File";
            this.selectReferenceButton.UseVisualStyleBackColor = true;
            this.selectReferenceButton.Click += new System.EventHandler(this.selectReferenceButton_Click);
            // 
            // selectMirrorRefButton
            // 
            this.selectMirrorRefButton.Location = new System.Drawing.Point(493, 174);
            this.selectMirrorRefButton.Name = "selectMirrorRefButton";
            this.selectMirrorRefButton.Size = new System.Drawing.Size(75, 23);
            this.selectMirrorRefButton.TabIndex = 8;
            this.selectMirrorRefButton.Text = "Select File";
            this.selectMirrorRefButton.UseVisualStyleBackColor = true;
            this.selectMirrorRefButton.Click += new System.EventHandler(this.selectMirrorRefButton_Click);
            // 
            // convertButton
            // 
            this.convertButton.Location = new System.Drawing.Point(505, 207);
            this.convertButton.Name = "convertButton";
            this.convertButton.Size = new System.Drawing.Size(112, 48);
            this.convertButton.TabIndex = 9;
            this.convertButton.Text = "Convert";
            this.convertButton.UseVisualStyleBackColor = true;
            this.convertButton.Click += new System.EventHandler(this.convertButton_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // switchWavelengthTextBox
            // 
            this.switchWavelengthTextBox.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.switchWavelengthTextBox.Location = new System.Drawing.Point(137, 134);
            this.switchWavelengthTextBox.Name = "switchWavelengthTextBox";
            this.switchWavelengthTextBox.Size = new System.Drawing.Size(64, 20);
            this.switchWavelengthTextBox.TabIndex = 12;
            this.switchWavelengthTextBox.Text = "800";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(15, 137);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(116, 13);
            this.label5.TabIndex = 13;
            this.label5.Text = "switchover wavelength";
            // 
            // calcReflectivityForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(629, 267);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.switchWavelengthTextBox);
            this.Controls.Add(this.convertButton);
            this.Controls.Add(this.selectMirrorRefButton);
            this.Controls.Add(this.selectReferenceButton);
            this.Controls.Add(this.selectDUTButton);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.mirrorRefTextBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.referenceTextBox);
            this.Controls.Add(this.DUTFileTextBox);
            this.Name = "calcReflectivityForm";
            this.Text = "Reflectivity Calculation";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox DUTFileTextBox;
        private System.Windows.Forms.TextBox referenceTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox mirrorRefTextBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button selectDUTButton;
        private System.Windows.Forms.Button selectReferenceButton;
        private System.Windows.Forms.Button selectMirrorRefButton;
        private System.Windows.Forms.Button convertButton;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.TextBox switchWavelengthTextBox;
        private System.Windows.Forms.Label label5;
    }
}