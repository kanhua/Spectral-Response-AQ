using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace Spectral_Response_AQ
{
    public partial class recipeScanForm : quickScanForm
    {
        string recipePath = @"C:\QERecipes\";
        public recipeScanForm()
        {
            InitializeComponent();
            QERecipe qer = new QERecipe(@"C:\Users\kl07\Dropbox\Documents in Dropbox\PhD online\C# Projects\Spectral Response AQ\Spectral Response AQ\3JTop.txt");
            this.fillParameters(qer);
            loadRecipe();
        }

        public void loadRecipe()
        {
            var recipeFiles=Directory.EnumerateFiles(recipePath);

            foreach (string recipeFile in recipeFiles)
            {
                recipeComboBox.Items.Add(recipeFile);
            }
        }

        private void recipeComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            QERecipe qer = new QERecipe((string)recipeComboBox.SelectedItem);
            
            this.fillParameters(qer);

        }
    }
}
