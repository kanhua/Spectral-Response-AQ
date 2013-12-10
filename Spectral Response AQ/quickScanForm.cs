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
    public delegate void MeasurmentFinishEventHandler(EventArgs e);
    public delegate void MeasruementStartEventhandler(EventArgs e);
    
    public partial class quickScanForm : Form
    {
        private QErig QErigInst;


        // the file object that the data writes to
        System.IO.StreamWriter MetaEQEOutputFile;

        ManualControlForm mc1;

        public event MeasurmentFinishEventHandler measurementFinished;
        public event MeasruementStartEventhandler measurementStarted;

        private void popMessageWindow(object sender, EventArgs e)
        {
            string wave = Convert.ToString(QErigInst.currentWavelength);
            MessageBox.Show("lock-in amp got data at "+wave);
        }

        private void writeData(object sender, EventArgs e)
        {
            if (MetaEQEOutputFile != null)
            {
                MetaEQEOutputFile.Write(QErigInst.currentWavelength);
                MetaEQEOutputFile.Write(",");
                MetaEQEOutputFile.WriteLine(QErigInst.currentDUTLockInReading);
            }
        }
        
        public quickScanForm()
        {
            InitializeComponent();
            stopButton.Enabled = false;
            
        }

        public void loadQErigInst(ref QErig QErigInst,ref ManualControlForm mcForm)
        {
            this.QErigInst = QErigInst;
            mc1 = mcForm;
            initGratingComboBoxSelections();
            mChromatorComboBox.SelectedIndex = 2;
            lightAndGratingGroupBox.Visible = false;
        }

        private void initGratingComboBoxSelections()
        {
            mChromatorComboBox.Items.Clear();
            foreach(MChromatorAbs mc in QErigInst.mcInst)
            {
                mChromatorComboBox.Items.Add(mc.deviceName);
            }
        }

        private void selectPathButton_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                filePathTextBox.Text = saveFileDialog1.FileName;
            }
        }

        private bool checkEnteredParameters()
        {
            try
            {
                double startWave = Convert.ToDouble(startWaveTextBox.Text);
                double endWave = Convert.ToDouble(endWaveTextBox.Text);
                double stepWave = Convert.ToDouble(stepTextBox.Text);
                return true;
            }
            catch (FormatException)
            {
                MessageBox.Show("Please enter valid wavelengths");
                return false;
            }
            
        }
        private void startMeasurementButton_Click(object sender, EventArgs e)
        {
            setBias();
            //Check the entered paramteres
            if (checkEnteredParameters() == false)
            {
                return;
            }
            
            //Deal with the file saving path
            if (filePathTextBox.Text == "save file")
            {
                string message = "You haven't assign a proper path for saving the file. Want to continue?";
                string caption = "Alert";
                MessageBoxButtons  buttons = MessageBoxButtons.YesNo;
                DialogResult mBoxResult = MessageBox.Show(message, caption, buttons);
                if (mBoxResult == DialogResult.No)
                {
                    return;
                }
            }
            
            //add ".csv" at the end of the file if nothing is added.
            string fileSavingPath = filePathTextBox.Text;
            string ext = System.IO.Path.GetExtension(fileSavingPath);
            if (ext == "")
            {
                ext = ".csv";
                fileSavingPath = fileSavingPath + ext;
            }

            //Change the accessbility of the controls on the form
            stopButton.Enabled = true;
            startMeasurementButton.Enabled = false;
            selectPathButton.Enabled = false;
            calibrateButton.Enabled = false;


           // try
           // {
                double startWave = Convert.ToDouble(startWaveTextBox.Text);
                double endWave = Convert.ToDouble(endWaveTextBox.Text);
                double stepWave = Convert.ToDouble(stepTextBox.Text);

                setBias();
                measurementStarted(EventArgs.Empty);

                //select the grating
                QErigInst.activeMC = QErigInst.mcInst[mChromatorComboBox.SelectedIndex];
                //select whether auto range is on
                QErigInst.dutLIA.enableAutoRange = autoRangeCheckbox.Checked;
                //select whether referece lock-in amplifier is activated
                QErigInst.activateREFLIA = enableRefLIACheckBox.Checked;
                if (!enableRefLIACheckBox.Checked)
                {
                    refLIAChannelComboBox.SelectedIndex = 0;
                }

                //select the light source and grating
                if (QErigInst.activeMC is BenDLLMChromator)
                {
                    //set light source
                    int samIdx = lightSourceComboBox.SelectedIndex;
                    QErigInst.activeMC.setCurrentSAM(samIdx);

                    //set grating
                    int gratingIdx = gratingComboBox.SelectedIndex + 1;
                    QErigInst.activeMC.setCurrentGrating(gratingIdx);
                }

                //start the scan
                QErigInst.quickScan(startWave, endWave, stepWave, dutLIAChannelComboBox.SelectedIndex,
                    refLIAChannelComboBox.SelectedIndex,
                    throughDevBox.Checked, true);

                HeaderInfo qeheader = new HeaderInfo();

                //Generate header info from QErig class
                singleHeader[] QESettingHeader = QErigInst.generateQESettingHeader();

                //add QE setting header in qeHeader class
                qeheader.addHeaderLine(QESettingHeader);

                DataProcessing.QEDataWriter QEFileWriter =
                    new DataProcessing.QEDataWriter(qeheader.generateHeaderStrings());
                QEFileWriter.addColumn("Wavelength (nm)", QErigInst.wavelength);
                QEFileWriter.addColumn("Photocurrent (A)", QErigInst.dutPhotocurrent);
                QEFileWriter.addColumn("Ref Photocurrent (A)", QErigInst.refPhotocurrent);
                QEFileWriter.addColumn("Light Source", QErigInst.currentSAM);
                QEFileWriter.addColumn("Grating", QErigInst.currentGrating);
                QEFileWriter.addColumn("X", QErigInst.dutOutputX);
                QEFileWriter.addColumn("Y", QErigInst.dutOutputX);
                QEFileWriter.addColumn("Phase", QErigInst.dutOutputPhase);
                QEFileWriter.writeDataAndHeaderIntoFile(fileSavingPath);

                measurementFinished(EventArgs.Empty);
                this.Dispose();
           // }
           // catch (Exception)
           // {

//            }
            
        }

        private void calibrateButton_Click(object sender, EventArgs e)
        {
            mc1.setMCTabActive();
            mc1.refreshMCStatusTextBox();
            mc1.Show();
        }


        private void setBias()
        {
            double bias=0;
            double presetBias = 0;
            try
            {
                QErigInst.setDeviceBias(Convert.ToDouble(deviceBiasTextBox.Text));
            }
            catch(FormatException)
            {
                MessageBox.Show("Please entre a valid device bias value");
                QErigInst.setDeviceBias(0);
            }
            
            try
            {
                bias = Convert.ToDouble(lightBias1TextBox.Text);
                QErigInst.setLightBias(0,ref bias);
                lightBias1TextBox.Text = Convert.ToString(bias);
                
            }
            catch (FormatException)
            {
                MessageBox.Show("Please entre a valid light bias-1 value");
                QErigInst.setLightBias(0,ref presetBias);
            }

            try
            {
                bias = Convert.ToDouble(lightBias2TextBox.Text);
                QErigInst.setLightBias(1, ref bias);
                lightBias2TextBox.Text = Convert.ToString(bias);
            }
            catch (FormatException)
            {
                MessageBox.Show("Please entre a valid device bias-2 value");
                QErigInst.setLightBias(1, ref presetBias);
            }

            try
            {
                bias = Convert.ToDouble(lightBias3TextBox.Text);
                QErigInst.setLightBias(2, ref bias);
                lightBias3TextBox.Text = Convert.ToString(bias);
            }
            catch (FormatException)
            {
                MessageBox.Show("Please entre a valid device bias-3 value");
                QErigInst.setLightBias(2, ref presetBias);
            }
            
        }
        
        
        private void applyBiasSettingButton_Click(object sender, EventArgs e)
        {
            setBias();
        }

        private void stopButton_Click(object sender, EventArgs e)
        {
            QErigInst.measurementContinue = false;
        }

        private void mChromatorComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            int selectedIdx = mChromatorComboBox.SelectedIndex;
            if (QErigInst.mcInst[selectedIdx] is BenDLLMChromator)
            {
                {
                    lightAndGratingGroupBox.Visible = true;
                    lightSourceComboBox.SelectedIndex = QErigInst.mcInst[selectedIdx].getCurrentSAM();
                    gratingComboBox.Items.Clear();
                    foreach (string str in QErigInst.mcInst[selectedIdx].gratingName)
                    {
                        gratingComboBox.Items.Add(str);
                    }
                    int selectedGrating = 0;
                    QErigInst.mcInst[selectedIdx].getCurrentGrating(ref selectedGrating);
                    gratingComboBox.SelectedIndex = selectedGrating - 1;

                }
            }
            else
            {
                lightAndGratingGroupBox.Visible = false;
            }
        }

        protected void fillParameters(double startWavelength, double endWavelength, double step)
        {
            startWaveTextBox.Text = Convert.ToString(startWavelength);
            endWaveTextBox.Text = Convert.ToString(endWavelength);
            stepTextBox.Text = Convert.ToString(step);
        }
        protected void fillParameters(QERecipe qer)
        {
            this.startWaveTextBox.Text = Convert.ToString(qer.startWavelength);
            this.endWaveTextBox.Text = Convert.ToString(qer.endWavelength);
            this.stepTextBox.Text =Convert.ToString(qer.step);

            this.dutLIAChannelComboBox.SelectedIndex = qer.LIAChannel;
            this.throughDevBox.Checked = qer.biasBox;

            this.deviceBiasTextBox.Text = Convert.ToString(qer.deviceBias);
            this.lightBias1TextBox.Text = Convert.ToString(qer.lightBias[0]);
            this.lightBias2TextBox.Text = Convert.ToString(qer.lightBias[1]);
            this.lightBias3TextBox.Text = Convert.ToString(qer.lightBias[2]);
        }
       
       
    }
}
