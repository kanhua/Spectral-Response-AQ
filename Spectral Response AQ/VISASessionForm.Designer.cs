namespace Spectral_Response_AQ
{
    partial class VISASessionForm
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

                if (mbSession != null)
                {
                    mbSession.Dispose();
                }
                if (components != null)
                {
                    components.Dispose();
                }
                
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
            this.sessionListBox = new System.Windows.Forms.ComboBox();
            this.initButton = new System.Windows.Forms.Button();
            this.refreshListButton = new System.Windows.Forms.Button();
            this.writeBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.writeButton = new System.Windows.Forms.Button();
            this.readButton = new System.Windows.Forms.Button();
            this.readBox = new System.Windows.Forms.TextBox();
            this.closeButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // sessionListBox
            // 
            this.sessionListBox.FormattingEnabled = true;
            this.sessionListBox.Location = new System.Drawing.Point(12, 15);
            this.sessionListBox.Name = "sessionListBox";
            this.sessionListBox.Size = new System.Drawing.Size(216, 21);
            this.sessionListBox.TabIndex = 0;
            // 
            // initButton
            // 
            this.initButton.Location = new System.Drawing.Point(349, 15);
            this.initButton.Name = "initButton";
            this.initButton.Size = new System.Drawing.Size(101, 25);
            this.initButton.TabIndex = 1;
            this.initButton.Text = "Initialize Session";
            this.initButton.UseVisualStyleBackColor = true;
            this.initButton.Click += new System.EventHandler(this.initButton_Click);
            // 
            // refreshListButton
            // 
            this.refreshListButton.Location = new System.Drawing.Point(252, 15);
            this.refreshListButton.Name = "refreshListButton";
            this.refreshListButton.Size = new System.Drawing.Size(91, 25);
            this.refreshListButton.TabIndex = 2;
            this.refreshListButton.Text = "Refresh List";
            this.refreshListButton.UseVisualStyleBackColor = true;
            this.refreshListButton.Click += new System.EventHandler(this.refreshListButton_Click);
            // 
            // writeBox
            // 
            this.writeBox.Location = new System.Drawing.Point(69, 70);
            this.writeBox.Name = "writeBox";
            this.writeBox.Size = new System.Drawing.Size(159, 20);
            this.writeBox.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 73);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(54, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Command";
            // 
            // writeButton
            // 
            this.writeButton.Location = new System.Drawing.Point(252, 67);
            this.writeButton.Name = "writeButton";
            this.writeButton.Size = new System.Drawing.Size(75, 23);
            this.writeButton.TabIndex = 5;
            this.writeButton.Text = "Write";
            this.writeButton.UseVisualStyleBackColor = true;
            this.writeButton.Click += new System.EventHandler(this.writeButton_Click);
            // 
            // readButton
            // 
            this.readButton.Location = new System.Drawing.Point(349, 67);
            this.readButton.Name = "readButton";
            this.readButton.Size = new System.Drawing.Size(75, 23);
            this.readButton.TabIndex = 6;
            this.readButton.Text = "Read";
            this.readButton.UseVisualStyleBackColor = true;
            this.readButton.Click += new System.EventHandler(this.readButton_Click);
            // 
            // readBox
            // 
            this.readBox.Location = new System.Drawing.Point(23, 124);
            this.readBox.Multiline = true;
            this.readBox.Name = "readBox";
            this.readBox.Size = new System.Drawing.Size(577, 326);
            this.readBox.TabIndex = 7;
            // 
            // closeButton
            // 
            this.closeButton.Location = new System.Drawing.Point(456, 15);
            this.closeButton.Name = "closeButton";
            this.closeButton.Size = new System.Drawing.Size(75, 25);
            this.closeButton.TabIndex = 8;
            this.closeButton.Text = "Close";
            this.closeButton.UseVisualStyleBackColor = true;
            this.closeButton.Click += new System.EventHandler(this.closeButton_Click);
            // 
            // VISASessionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(645, 476);
            this.Controls.Add(this.closeButton);
            this.Controls.Add(this.readBox);
            this.Controls.Add(this.readButton);
            this.Controls.Add(this.writeButton);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.writeBox);
            this.Controls.Add(this.refreshListButton);
            this.Controls.Add(this.initButton);
            this.Controls.Add(this.sessionListBox);
            this.Name = "VISASessionForm";
            this.Text = "NI VISA console";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox sessionListBox;
        private System.Windows.Forms.Button initButton;
        private System.Windows.Forms.Button refreshListButton;
        private System.Windows.Forms.TextBox writeBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button writeButton;
        private System.Windows.Forms.Button readButton;
        private System.Windows.Forms.TextBox readBox;
        private System.Windows.Forms.Button closeButton;
    }
}