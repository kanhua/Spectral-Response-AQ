namespace Spectral_Response_AQ
{
    partial class mainForm
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.measurementToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.quickScanToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.recipeScanToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.analysisToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.readEQEFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewReferenceFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.photocurrentToQECorrectionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.reflectivityCorrectionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.optionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.manualControlToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.vISAConsoleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.equipmentSettingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.scanSettingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.measurementToolStripMenuItem,
            this.analysisToolStripMenuItem,
            this.optionsToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(981, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // measurementToolStripMenuItem
            // 
            this.measurementToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.quickScanToolStripMenuItem,
            this.recipeScanToolStripMenuItem});
            this.measurementToolStripMenuItem.Name = "measurementToolStripMenuItem";
            this.measurementToolStripMenuItem.Size = new System.Drawing.Size(92, 20);
            this.measurementToolStripMenuItem.Text = "Measurement";
            // 
            // quickScanToolStripMenuItem
            // 
            this.quickScanToolStripMenuItem.Name = "quickScanToolStripMenuItem";
            this.quickScanToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.quickScanToolStripMenuItem.Text = "Quick Scan";
            this.quickScanToolStripMenuItem.Click += new System.EventHandler(this.quickScanToolStripMenuItem_Click);
            // 
            // recipeScanToolStripMenuItem
            // 
            this.recipeScanToolStripMenuItem.Name = "recipeScanToolStripMenuItem";
            this.recipeScanToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.recipeScanToolStripMenuItem.Text = "Recipe Scan";
            this.recipeScanToolStripMenuItem.Click += new System.EventHandler(this.recipeScanToolStripMenuItem_Click);
            // 
            // analysisToolStripMenuItem
            // 
            this.analysisToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.readEQEFileToolStripMenuItem,
            this.viewReferenceFileToolStripMenuItem,
            this.photocurrentToQECorrectionToolStripMenuItem,
            this.reflectivityCorrectionToolStripMenuItem});
            this.analysisToolStripMenuItem.Name = "analysisToolStripMenuItem";
            this.analysisToolStripMenuItem.Size = new System.Drawing.Size(62, 20);
            this.analysisToolStripMenuItem.Text = "Analysis";
            // 
            // readEQEFileToolStripMenuItem
            // 
            this.readEQEFileToolStripMenuItem.Name = "readEQEFileToolStripMenuItem";
            this.readEQEFileToolStripMenuItem.Size = new System.Drawing.Size(233, 22);
            this.readEQEFileToolStripMenuItem.Text = "EQE viewer";
            this.readEQEFileToolStripMenuItem.Click += new System.EventHandler(this.readEQEFileToolStripMenuItem_Click);
            // 
            // viewReferenceFileToolStripMenuItem
            // 
            this.viewReferenceFileToolStripMenuItem.Enabled = false;
            this.viewReferenceFileToolStripMenuItem.Name = "viewReferenceFileToolStripMenuItem";
            this.viewReferenceFileToolStripMenuItem.Size = new System.Drawing.Size(233, 22);
            this.viewReferenceFileToolStripMenuItem.Text = "View reference file";
            this.viewReferenceFileToolStripMenuItem.Click += new System.EventHandler(this.viewReferenceFileToolStripMenuItem_Click);
            // 
            // photocurrentToQECorrectionToolStripMenuItem
            // 
            this.photocurrentToQECorrectionToolStripMenuItem.Name = "photocurrentToQECorrectionToolStripMenuItem";
            this.photocurrentToQECorrectionToolStripMenuItem.Size = new System.Drawing.Size(233, 22);
            this.photocurrentToQECorrectionToolStripMenuItem.Text = "Photocurrent to QE correction";
            this.photocurrentToQECorrectionToolStripMenuItem.Click += new System.EventHandler(this.photocurrentToQECorrectionToolStripMenuItem_Click);
            // 
            // reflectivityCorrectionToolStripMenuItem
            // 
            this.reflectivityCorrectionToolStripMenuItem.Name = "reflectivityCorrectionToolStripMenuItem";
            this.reflectivityCorrectionToolStripMenuItem.Size = new System.Drawing.Size(233, 22);
            this.reflectivityCorrectionToolStripMenuItem.Text = "Reflectivity correction";
            this.reflectivityCorrectionToolStripMenuItem.Click += new System.EventHandler(this.reflectivityCorrectionToolStripMenuItem_Click);
            // 
            // optionsToolStripMenuItem
            // 
            this.optionsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.manualControlToolStripMenuItem,
            this.vISAConsoleToolStripMenuItem,
            this.equipmentSettingToolStripMenuItem,
            this.scanSettingToolStripMenuItem});
            this.optionsToolStripMenuItem.Name = "optionsToolStripMenuItem";
            this.optionsToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.optionsToolStripMenuItem.Text = "Options";
            // 
            // manualControlToolStripMenuItem
            // 
            this.manualControlToolStripMenuItem.Name = "manualControlToolStripMenuItem";
            this.manualControlToolStripMenuItem.Size = new System.Drawing.Size(172, 22);
            this.manualControlToolStripMenuItem.Text = "Manual Control";
            this.manualControlToolStripMenuItem.Click += new System.EventHandler(this.manualControlToolStripMenuItem_Click);
            // 
            // vISAConsoleToolStripMenuItem
            // 
            this.vISAConsoleToolStripMenuItem.Name = "vISAConsoleToolStripMenuItem";
            this.vISAConsoleToolStripMenuItem.Size = new System.Drawing.Size(172, 22);
            this.vISAConsoleToolStripMenuItem.Text = "VISA console";
            this.vISAConsoleToolStripMenuItem.Click += new System.EventHandler(this.vISAConsoleToolStripMenuItem_Click);
            // 
            // equipmentSettingToolStripMenuItem
            // 
            this.equipmentSettingToolStripMenuItem.Name = "equipmentSettingToolStripMenuItem";
            this.equipmentSettingToolStripMenuItem.Size = new System.Drawing.Size(172, 22);
            this.equipmentSettingToolStripMenuItem.Text = "Equipment Setting";
            this.equipmentSettingToolStripMenuItem.Click += new System.EventHandler(this.equipmentSettingToolStripMenuItem_Click);
            // 
            // scanSettingToolStripMenuItem
            // 
            this.scanSettingToolStripMenuItem.Name = "scanSettingToolStripMenuItem";
            this.scanSettingToolStripMenuItem.Size = new System.Drawing.Size(172, 22);
            this.scanSettingToolStripMenuItem.Text = "Scan Setting";
            this.scanSettingToolStripMenuItem.Click += new System.EventHandler(this.scanSettingToolStripMenuItem_Click);
            // 
            // mainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(981, 766);
            this.Controls.Add(this.menuStrip1);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "mainForm";
            this.Text = "Spectral Response Utility";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem optionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem manualControlToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem vISAConsoleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem equipmentSettingToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem measurementToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem quickScanToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem analysisToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem readEQEFileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem viewReferenceFileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem photocurrentToQECorrectionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem recipeScanToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem reflectivityCorrectionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem scanSettingToolStripMenuItem;
    }
}

