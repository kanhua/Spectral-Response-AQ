namespace Spectral_Response_AQ
{
    partial class startUpSettingForm
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
            this.initInstCheckBox = new System.Windows.Forms.CheckBox();
            this.OKbutton = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.NoXeRadioButton = new System.Windows.Forms.RadioButton();
            this.XeNoSwitchRadioButton = new System.Windows.Forms.RadioButton();
            this.XeSwitchRadioButton = new System.Windows.Forms.RadioButton();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // initInstCheckBox
            // 
            this.initInstCheckBox.AutoSize = true;
            this.initInstCheckBox.Checked = true;
            this.initInstCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.initInstCheckBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.initInstCheckBox.Location = new System.Drawing.Point(12, 25);
            this.initInstCheckBox.Name = "initInstCheckBox";
            this.initInstCheckBox.Size = new System.Drawing.Size(183, 22);
            this.initInstCheckBox.TabIndex = 0;
            this.initInstCheckBox.Text = "Initialise the instruments";
            this.initInstCheckBox.UseVisualStyleBackColor = true;
            // 
            // OKbutton
            // 
            this.OKbutton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.OKbutton.Location = new System.Drawing.Point(190, 186);
            this.OKbutton.Name = "OKbutton";
            this.OKbutton.Size = new System.Drawing.Size(75, 23);
            this.OKbutton.TabIndex = 2;
            this.OKbutton.Text = "OK";
            this.OKbutton.UseVisualStyleBackColor = true;
            this.OKbutton.Click += new System.EventHandler(this.OKbutton_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.NoXeRadioButton);
            this.groupBox1.Controls.Add(this.XeNoSwitchRadioButton);
            this.groupBox1.Controls.Add(this.XeSwitchRadioButton);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(12, 53);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(402, 111);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Xe lamp options";
            // 
            // NoXeRadioButton
            // 
            this.NoXeRadioButton.AutoSize = true;
            this.NoXeRadioButton.Checked = true;
            this.NoXeRadioButton.Location = new System.Drawing.Point(7, 82);
            this.NoXeRadioButton.Name = "NoXeRadioButton";
            this.NoXeRadioButton.Size = new System.Drawing.Size(109, 22);
            this.NoXeRadioButton.TabIndex = 2;
            this.NoXeRadioButton.TabStop = true;
            this.NoXeRadioButton.Text = "No Xe Lamp";
            this.NoXeRadioButton.UseVisualStyleBackColor = true;
            // 
            // XeNoSwitchRadioButton
            // 
            this.XeNoSwitchRadioButton.AutoSize = true;
            this.XeNoSwitchRadioButton.Location = new System.Drawing.Point(7, 53);
            this.XeNoSwitchRadioButton.Name = "XeNoSwitchRadioButton";
            this.XeNoSwitchRadioButton.Size = new System.Drawing.Size(326, 22);
            this.XeNoSwitchRadioButton.TabIndex = 1;
            this.XeNoSwitchRadioButton.Text = "Enable the Xe lamp, use it for all the spectrum";
            this.XeNoSwitchRadioButton.UseVisualStyleBackColor = true;
            // 
            // XeSwitchRadioButton
            // 
            this.XeSwitchRadioButton.AutoSize = true;
            this.XeSwitchRadioButton.Location = new System.Drawing.Point(7, 20);
            this.XeSwitchRadioButton.Name = "XeSwitchRadioButton";
            this.XeSwitchRadioButton.Size = new System.Drawing.Size(377, 22);
            this.XeSwitchRadioButton.TabIndex = 0;
            this.XeSwitchRadioButton.Text = "Enable the Xe lamp, switch to halogen lamp at 550nm";
            this.XeSwitchRadioButton.UseVisualStyleBackColor = true;
            // 
            // startUpSettingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(449, 221);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.OKbutton);
            this.Controls.Add(this.initInstCheckBox);
            this.Name = "startUpSettingForm";
            this.Text = "Start up setting";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox initInstCheckBox;
        private System.Windows.Forms.Button OKbutton;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton XeNoSwitchRadioButton;
        private System.Windows.Forms.RadioButton XeSwitchRadioButton;
        private System.Windows.Forms.RadioButton NoXeRadioButton;
    }
}