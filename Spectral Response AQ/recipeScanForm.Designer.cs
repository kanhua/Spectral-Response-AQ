namespace Spectral_Response_AQ
{
    partial class recipeScanForm
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
            this.recipeComboBox = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // recipeComboBox
            // 
            this.recipeComboBox.FormattingEnabled = true;
            this.recipeComboBox.Location = new System.Drawing.Point(317, 167);
            this.recipeComboBox.Name = "recipeComboBox";
            this.recipeComboBox.Size = new System.Drawing.Size(206, 21);
            this.recipeComboBox.TabIndex = 44;
            this.recipeComboBox.SelectedIndexChanged += new System.EventHandler(this.recipeComboBox_SelectedIndexChanged);
            // 
            // recipeScanForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(677, 594);
            this.Controls.Add(this.recipeComboBox);
            this.Name = "recipeScanForm";
            this.Text = "Recipe Scan";
            this.Controls.SetChildIndex(this.recipeComboBox, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox recipeComboBox;
    }
}