using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using GraphUtility;
using System.Threading;

namespace Spectral_Response_AQ
{
    public partial class ManualControlForm : Form
    {

        public MChromatorAbs activeMC;
        public lockInAmp activeLIA;
        
        public QErig manualQE;
        private Graph quickScanGraph = new Graph();

        private CheckBox[] statusByteCheckBoxArr = new CheckBox[8];

        public ManualControlForm()
        {
            InitializeComponent();
            plotTestFunction();
            setUpStatusBoxArray();
        }

        private void plotTestFunction()
        {
            double X,Y;
            quickScanGraph.GridLines=true;

            for(X=12.99;X>-2.01;X=X-0.01)
            {
                Y=1.575 * X + 2.3 * Math.Sin(X * 13.2) - 2.1;
                if (Y<0)
                {
                    quickScanGraph.AddPoint(9,X,Y);
                }
                else
                {
                    quickScanGraph.AddPoint(1,X,Y+1);
                }
            }
            quickScanGraph.SetupAxes(false,false);
            quickScanGraph.Render(ref plotBox);
 
        }

        /// <summary>
        /// Refresh the monochromator information in the text boxes
        /// </summary>
        public void refreshMCStatusTextBox()
        {
            activeMCTextBox.Text = activeMC.deviceName;
            currentDialTextBox.Text = System.Convert.ToString(activeMC.currentMCDial);
            currentWaveTextBox.Text = System.Convert.ToString(activeMC.currentWavelength);
            currentFilterTextBox.Text = System.Convert.ToString(activeMC.currentFilterDial);
        }

        public void LoadQErigInstance(ref QErig passQErigInst)
        {
            manualQE = passQErigInst;
        }

        public MChromatorAbs[] mcInst;
        public lockInAmp[] LIAInst;
        
        public void loadDeviceInst(ref MChromatorAbs[] mcInst,ref lockInAmp[] LIAInst)
        {
            this.mcInst = mcInst;
            this.LIAInst = LIAInst;
            
            //set default active monotchormator to LIAinst[2];
            int activeMCIndex = 2;
            activeMC = mcInst[activeMCIndex];
            RefreshMCBox();
            MCBox.SelectedIndex = activeMCIndex;
            refreshGroupBoxes();
            refreshMCStatusTextBox();
        }

        private void setUpStatusBoxArray()
        {
            statusByteCheckBoxArr[0] = bit0CheckBox;
            statusByteCheckBoxArr[1] = bit1CheckBox;
            statusByteCheckBoxArr[2] = bit2CheckBox;
            statusByteCheckBoxArr[3] = bit3CheckBox;
            statusByteCheckBoxArr[4] = bit4CheckBox;
            statusByteCheckBoxArr[5] = bit5CheckBox;
            statusByteCheckBoxArr[6] = bit6CheckBox;
            statusByteCheckBoxArr[7] = bit7CheckBox;
        }

        private void btnCalGrating_Click(object sender, EventArgs e)
        {
            try
            {
                activeMC.currentMCDial = System.Convert.ToDouble(currentReading.Text);
            }
            catch (FormatException)
            {
                MessageBox.Show("The number in the text box is invalid");
            }
            refreshMCStatusTextBox();
            Debug.Write("The current dial in QErig class is:");
            Debug.WriteLine(activeMC.currentMCDial);
            currentReading.Clear();
            if (MoveTo600AfterCaliCheckBox.Checked)
            {
                activeMC.MoveMCAndFilter(600);
            }
        }

        private void btnCalFilter_Click(object sender, EventArgs e)
        {
            try
            {
                int filterDial = activeMC.filterPositions[setFilterForCal.SelectedIndex];
                activeMC.currentFilterDial = filterDial;
                refreshMCStatusTextBox();
                setFilterForCal.SelectedIndex = -1;
            }
            catch (IndexOutOfRangeException)
            {
                MessageBox.Show("Please select a filter");
            }
            
        }

        private void goFilter_Click(object sender, EventArgs e)
        {
            int targetFilterDial = activeMC.filterPositions[setTargetFilter.SelectedIndex];
            activeMC.MoveMCFilterDial(targetFilterDial);
            refreshMCStatusTextBox();
        }

        private void goWave_Click(object sender, EventArgs e)
        {
            double targetWave = System.Convert.ToDouble(setMCWave.Text);
            if (autoSelectFilterCheckBox.Checked)
            {
                activeMC.MoveMCAndFilter(targetWave);
            }
            else
            {
                activeMC.MoveMCWL(targetWave);
                
            }
         
            refreshMCStatusTextBox();
            refreshLightAndSourceBox();
        }

        private void GoDial_Click(object sender, EventArgs e)
        {
            activeMC.MoveMCWLDial(System.Convert.ToDouble(setMCDial.Text));
            refreshMCStatusTextBox();
        }

        private void btnScanTest_Click(object sender, EventArgs e)
        {
            quickScanGraph.DeleteAllSeries();
            double startWavelength = System.Convert.ToDouble(tbxStartWavelength.Text);
            double endWavelength = System.Convert.ToDouble(tbxEndWavelength.Text);
            double step = System.Convert.ToDouble(tbxScanStep.Text);
            double currentWavelength = startWavelength;
            while (currentWavelength < endWavelength)
            {

                if (autoSelectFilterInScanCheckBox.Checked)
                {
                    activeMC.MoveMCAndFilter(currentWavelength);
                }
                else
                {
                    activeMC.MoveMCWL(currentWavelength);
                }
                currentWavelength += step;
                double lockInReading = System.Convert.ToDouble(LIAInst[0].ReadDataFromLockIn(true));
                Thread.Sleep(1000);
                quickScanGraph.AddPoint(1, currentWavelength, lockInReading);
                quickScanGraph.SetupAxes(false, false);
                quickScanGraph.Render(ref plotBox);
            }
        }

        private void btnLockInTestStart_Click(object sender, EventArgs e)
        {
            quickScanGraph.DeleteAllSeries();
            string outputStr = "";
            for (int i = 0; i < 10; i++)
            {
                outputStr=activeLIA.ReadDataFromLockIn(true);
                quickScanGraph.AddPoint(1, i, System.Convert.ToDouble(outputStr));
                Debug.WriteLine(outputStr);
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            currentLIAReadingBox.Text = activeLIA.ReadDataFromLockIn(true);
            
        }


        private void MCBox_Click(object sender, EventArgs e)
        {
            RefreshMCBox();
        }

        private void RefreshMCBox()
        {
            MCBox.Items.Clear();
            foreach (MChromatorAbs mc in mcInst)
            {
                MCBox.Items.Add(mc.deviceName);
            }
        }

        private void refreshLightAndSourceBox()
        {
            setLightSourceComboBox.SelectedIndex = activeMC.getCurrentSAM();
            setGratingComboBox.Items.Clear();
            foreach (string str in activeMC.gratingName)
            {
                setGratingComboBox.Items.Add(str);
            }
            int selectedGrating=0;
            activeMC.getCurrentGrating(ref selectedGrating);
            setGratingComboBox.SelectedIndex = selectedGrating - 1;
           

        }

        private void setActiveButton_Click(object sender, EventArgs e)
        {
            int selIdx = MCBox.SelectedIndex;
            setActiveMC(selIdx);
            refreshGroupBoxes();  
        }

        private void refreshGroupBoxes()
        {
            if (activeMC is BenDLLMChromator)
            {
                calibrateGroupBox.Visible = false;
                lightAndGratingGroupBox.Visible = true;
                refreshLightAndSourceBox();
            }
            else if (activeMC is GPIBMotorMChromator)
            {
                calibrateGroupBox.Visible = true;
                lightAndGratingGroupBox.Visible = false;
            }  
        }

        /// <summary>
        /// Set active monochromator
        /// </summary>
        /// <param name="index"></param>
        private void setActiveMC(int index)
        {
            activeMC = mcInst[index];
            refreshMCStatusTextBox();
            
        }

        private string reverseAddZeros(string binaryStr)
        {
            string newBinaryStr;

            char[] tempChar = (char[])binaryStr.Reverse().ToArray();
            newBinaryStr = new string(tempChar);
            int expectedBinaryStrLen = 8;
            for (int i = 0; i < expectedBinaryStrLen-(tempChar.GetUpperBound(0)+1); i++)
            {
                newBinaryStr = string.Concat(newBinaryStr, "0");
            }
            return newBinaryStr;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            short statusByte=LIAInst[0].ReadLIAStatusByte() ;
            //testInteger.Text = Convert.ToString(statusByte);

            int testInt = statusByte;
            statusByteTextBox.Text = reverseAddZeros(Convert.ToString((byte)testInt, 2));
            char[] statusByteCharArr = statusByteTextBox.Text.ToArray();
            int k = 0;
            foreach (char s in statusByteCharArr)
            {
                if (s == '0')
                {
                    statusByteCheckBoxArr[k].Checked = false;
                }
                else if (s == '1')
                {
                    statusByteCheckBoxArr[k].Checked = true;
                }
                k = k + 1;
            }

        }

        public void setMCTabActive()
        {
            tabControl1.SelectedTab = tabPage1;
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void setLightSourceButton_Click(object sender, EventArgs e)
        {
            activeMC.setCurrentSAM(setLightSourceComboBox.SelectedIndex);
            refreshLightAndSourceBox();
        }

        private void setGratingButton_Click(object sender, EventArgs e)
        {
            activeMC.setCurrentGrating(setGratingComboBox.SelectedIndex+1);
        }

        private void parkMChromatorButton_Click(object sender, EventArgs e)
        {
            activeMC.parkMonochromator();
        }

       

        

    }
}
