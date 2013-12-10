using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Spectral_Response_AQ
{
    public partial class scanSettingForm : Form
    {
        private QErig QErigInst;
        
        public scanSettingForm()
        {
            InitializeComponent();
            defaultRadioButton.Checked = true;
        }
        public void loadQErigInst(ref QErig QErigInst)
        {
            this.QErigInst = QErigInst;
        }

        public void setupForm()
        {
            try
            {
                if (this.QErigInst.dutLIA.isDelayAtDefault() == true)
                {
                    defaultRadioButton.Checked = true;
                    tcMultiplierTextBox.Text = Convert.ToString(this.QErigInst.dutLIA.delayRatio);
                    extraDelayTextBox.Text = Convert.ToString(this.QErigInst.dutLIA.fixedDelay);
                }
                else
                {
                    manualMode1RadioButton.Checked = true;
                    tcMultiplierTextBox.Text = Convert.ToString(this.QErigInst.dutLIA.delayRatio);
                    extraDelayTextBox.Text = Convert.ToString(this.QErigInst.dutLIA.fixedDelay);
                }
            }
            catch (NullReferenceException)
            {
                MessageBox.Show("QE rig instance not loaded.");
            }
        }

        private void OKButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (manualMode1RadioButton.Checked == true)
                {
                    QErigInst.dutLIA.delayRatio = Convert.ToDouble(tcMultiplierTextBox.Text);
                    QErigInst.dutLIA.fixedDelay = Convert.ToDouble(extraDelayTextBox.Text);
                }
            }
            catch (FormatException)
            {
                MessageBox.Show("Please Enter a valid number in the text boxes");
                this.DialogResult = DialogResult.None;
            }
        }

    }
}
