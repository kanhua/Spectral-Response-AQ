using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using NationalInstruments.VisaNS;

namespace Spectral_Response_AQ
{
    public partial class settingsForm : Form
    {
        //Set up an control array for assinging VISA sessions
        Button[] AssignButtonArr = new Button[4];
        TextBox[] VISASessionTextBoxArr = new TextBox[4];

        public MChromatorAbs[] mcInst;
        public lockInAmp[] LIAInst;


        public settingsForm()
        {
            InitializeComponent();

 
            AssignButtonArr[0] = assignVISMCButton;
            AssignButtonArr[1] = assignNIRMCButton;
            AssignButtonArr[2] = assignMainLockInAmpButton;
            AssignButtonArr[3] = assignRefLockInAmpButton;

            VISASessionTextBoxArr[0] = VisMCTextBox;
            VISASessionTextBoxArr[1] = NIRMCTextBox;
            VISASessionTextBoxArr[2] = MainLIATextBox;
            VISASessionTextBoxArr[3] = refLockInAmpTextBox;

        }

        private void RefreshVISAResources()
        {
            string[] resources = ResourceManager.GetLocalManager().FindResources("?*");
            foreach (string s in resources)
            {
                VISASessionListBox.Items.Add(s);
            }
            VisMCTextBox.Text = mcInst[0].VISAResourceName;
            NIRMCTextBox.Text = mcInst[1].VISAResourceName;
            MainLIATextBox.Text = LIAInst[0].VISAResourceName;
        }

        private void settingsForm_Load(object sender, EventArgs e)
        {
            RefreshVISAResources();
        }

        private void assignVISASessionTextBox(int idx)
        {
            VISASessionTextBoxArr[idx].Text = VISASessionListBox.Text;
        }

        private void assignVISMCButton_Click(object sender, EventArgs e)
        {
            assignVISASessionTextBox(0);
        }

        private void assignNIRMCButton_Click(object sender, EventArgs e)
        {
            assignVISASessionTextBox(1);
        }

        private void assignMainLockInAmpButton_Click(object sender, EventArgs e)
        {
            assignVISASessionTextBox(2);
        }

        private void assignRefLockInAmpButton_Click(object sender, EventArgs e)
        {
            assignVISASessionTextBox(3);
        }

        public void loadDeviceInst(ref MChromatorAbs[] mcInst, ref lockInAmp[] LIAInst)
        {
            this.mcInst = mcInst;
            this.LIAInst = LIAInst;
        }

        private void initButton_Click(object sender, EventArgs e)
        {
            try
            {
                mcInst[0] = new GPIBMotorMChromator();
                mcInst[0].initVISASession(VisMCTextBox.Text);
                mcInst[0].deviceName = "VISmono";
                mcInst[1] = new GPIBMotorMChromator();
                mcInst[1].initVISASession(NIRMCTextBox.Text);
                mcInst[1].deviceName = "NIRmono";
                LIAInst[0] = new lockInAmp();
                LIAInst[0].initVISASession(MainLIATextBox.Text);
            }
            catch (System.ArgumentException)
            {
                deviceMessageBox.Text = "failed";
            }
            
        }

        private void saveSettingButton_Click(object sender, EventArgs e)
        {
            string saveFileName = "";
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                saveFileName = saveFileDialog1.FileName;
                
                //Serialization
                System.Xml.Serialization.XmlSerializer s = new System.Xml.Serialization.XmlSerializer(typeof(GPIBMotorMChromator[]));
                System.IO.TextWriter w = new System.IO.StreamWriter(saveFileName);
                s.Serialize(w, mcInst);
                w.Close();
            }

        }

        private void saveLIASettingButton_Click(object sender, EventArgs e)
        {
            string saveFileName = "";
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                saveFileName = saveFileDialog1.FileName;

                //Serialization
                System.Xml.Serialization.XmlSerializer s = 
                    new System.Xml.Serialization.XmlSerializer(typeof(lockInAmp[]));
                System.IO.TextWriter w = new System.IO.StreamWriter(saveFileName);
                s.Serialize(w, LIAInst);
                w.Close();
            }
        }

        private void saveToDefault(object sender, EventArgs e)
        {
            using (System.IO.TextWriter w = new System.IO.StreamWriter("defaultLIASetting.xml"))
            {
                System.Xml.Serialization.XmlSerializer s =
                    new System.Xml.Serialization.XmlSerializer(typeof(lockInAmp[]));
                s.Serialize(w, LIAInst);

                w.Close();
            }
        }

 




    }
}
