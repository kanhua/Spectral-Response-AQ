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
    public partial class startUpSettingForm : Form
    {
        public bool initEquipments = false;
        public int enableXeLamp = 0;
        
        public startUpSettingForm()
        {
            InitializeComponent();
        }

        public void outputStatus(ref bool initEquipments, ref int enableXeLamp )
        {
            initEquipments=this.initEquipments;
            
            
            enableXeLamp = this.enableXeLamp;
           
        }

        private void OKbutton_Click(object sender, EventArgs e)
        {
            initEquipments = initInstCheckBox.Checked;
            if (XeSwitchRadioButton.Checked)
            {
                enableXeLamp = 1;
            }
            else if (XeNoSwitchRadioButton.Checked)
            {
                enableXeLamp = 2;
            }
            else if (NoXeRadioButton.Checked)
            {
                enableXeLamp = 0;
            }
        }

       

    }
}
