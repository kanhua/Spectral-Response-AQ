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
    public partial class mainForm : Form
    {
        /// <summary>
        /// Total number of monochomators
        /// </summary>
        static int MCNum = 3;

        /// <summary>
        /// Total number of lock-in amplifiers
        /// </summary>
        static int lockInAmpNum = 1;
        
        public QErig mainQErigInst = new QErig();

        private MChromatorAbs[] mcInst = new MChromatorAbs[MCNum];

        private lockInAmp[] LIAInst = new lockInAmp[lockInAmpNum];

        ManualControlForm mc1 = new ManualControlForm();

        private plotForm activePlotForm;

        scanSettingForm ssf = new scanSettingForm();
        
        public mainForm()
        {
            InitializeComponent();
            loadSettingFromFile();

            //BenDLLMChromator bc=new BenDLLMChromator();
            
            //Write a sample monochromator xml file
            //System.Xml.Serialization.XmlSerializer xs = new System.Xml.Serialization.XmlSerializer(typeof(BenDLLMChromator));
            //System.IO.TextWriter xw = new System.IO.StreamWriter("testmcfile.xml");
            //xs.Serialize(xw, bc);
            //xw.Close();
            bool developmentMode = false;
            //var result = MessageBox.Show("running in debug mode?(debug mode will disable all the instruments", "debug mode",
            //                     MessageBoxButtons.YesNo,
            //                     MessageBoxIcon.Question);
            
            //if (result == DialogResult.Yes)
            //{
            //    developmentMode = true;
            //}

            startUpSettingForm st1 = new startUpSettingForm();

            bool initEquip = false;
            int initXeLamp = 0;
            if (st1.ShowDialog() == DialogResult.OK)
            {
                st1.outputStatus(ref initEquip, ref initXeLamp);
            }

            st1.Close();
            developmentMode = !initEquip;

            //initialize VISA sessions
            foreach (MChromatorAbs mc in mcInst)
            {
                mc.initVISASession(developmentMode,initXeLamp);
            }


            foreach (lockInAmp lia in LIAInst)
            {
                lia.initVISASession(developmentMode);

                if (lia.sessionInitialised)
                {
                    try
                    {
                        lia.setLockInToDefault();
                    }
                    catch (NationalInstruments.VisaNS.VisaException)
                    {
                        lia.disableVISASession();

                    }
                }
            }

            mainQErigInst.loadDeviceInst(ref mcInst, ref LIAInst);

            
            mc1.MdiParent = this;
            mc1.LoadQErigInstance(ref mainQErigInst);
            mc1.loadDeviceInst(ref mcInst, ref LIAInst);

            mainQErigInst.LIAReadFinish += new ReadLIAEventHandler(plotData);

            //Serialization
            //System.Xml.Serialization.XmlSerializer s = new System.Xml.Serialization.XmlSerializer(typeof(GPIBMotorMChromator[]));
            //System.IO.TextWriter w = new System.IO.StreamWriter("test.xml");
            //s.Serialize(w, mcInst);
            //w.Close();

        }

        private void manualControlToolStripMenuItem_Click(object sender, EventArgs e)
        {
            mc1.refreshMCStatusTextBox();
            mc1.Show();
        }

        private void plotData(object sender, EventArgs e)
        {
            activePlotForm.addPoint(1, mainQErigInst.currentWavelength, mainQErigInst.currentDUTLockInReading);
            activePlotForm.addPoint(2, mainQErigInst.currentWavelength, mainQErigInst.currentREFLockInReading);
        }

        private void vISAConsoleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            VISASessionForm visafm1 = new VISASessionForm();
            visafm1.Show();
        }

        private void equipmentSettingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            settingsForm sForm1 = new settingsForm();
            sForm1.MdiParent = this;  
            sForm1.loadDeviceInst(ref mcInst, ref LIAInst);
            sForm1.Show();
        }

        private void loadSettingFromFile()
        {
            try
            {
                //Deserialization
                //Read device obejct information from the files
                GPIBMotorMChromator[] GMChromator = new GPIBMotorMChromator[2];
                
                System.Xml.Serialization.XmlSerializer s = new System.Xml.Serialization.XmlSerializer(typeof(GPIBMotorMChromator[]));
                System.IO.TextReader r = new System.IO.StreamReader("defaultMCSetting.xml");
                GMChromator = (GPIBMotorMChromator[])s.Deserialize(r);
                r.Close();

                mcInst[0] = GMChromator[0];
                mcInst[1] = GMChromator[1];
                mcInst[2] = new BenDLLMChromator();

                s = new System.Xml.Serialization.XmlSerializer(typeof(lockInAmp[]));
                r = new System.IO.StreamReader("defaultLIASetting.xml");
                LIAInst = (lockInAmp[])s.Deserialize(r);
                r.Close();
            }
            catch (System.IO.FileNotFoundException e)
            {
                MessageBox.Show(e.FileName + " not found.");
            }
            catch (Exception)
            {
                MessageBox.Show("Initilize the object fails");
            }
        }

        private void quickScanToolStripMenuItem_Click(object sender, EventArgs e)
        {
            quickScanForm qsForm1 = new quickScanForm();
            plotForm pForm1 = new plotForm();
            qsForm1.loadQErigInst(ref mainQErigInst,ref mc1);
            qsForm1.MdiParent = this;
            pForm1.MdiParent = this;
            qsForm1.measurementStarted+=new MeasruementStartEventhandler(showPlotWindow);

            activePlotForm = pForm1;

            qsForm1.measurementFinished += new MeasurmentFinishEventHandler(changePlotWindowProperties);
            qsForm1.Show();
        }

        private void showPlotWindow(EventArgs e)
        {
            activePlotForm.ControlBox = false;
            activePlotForm.setXYAxesTitle("wavelength (nm)", "photocurrent (A)");
            activePlotForm.Show();
        }

        private void changePlotWindowProperties(EventArgs e)
        {
            activePlotForm.ControlBox = true;
        }


            

        private void readEQEFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            plotForm pForm = new plotForm();
           
            pForm.Show();
            
          
        }

        private void viewReferenceFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DataProcessing.DataReader testdreader = new DataProcessing.DataReader();
            DataProcessing.XYDataArray xydata1 =
                new DataProcessing.XYDataArray(ref testdreader.dataArray1, ref testdreader.dataArray2);
            xydata1.showData();
        }

        private void photocurrentToQECorrectionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            selectQERefFileForm fileForm = new selectQERefFileForm();
            fileForm.MdiParent = this;
            fileForm.Show();
        }

        private void scanSettingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            //ssf.MdiParent = this;
            ssf.loadQErigInst(ref mainQErigInst);
            ssf.setupForm();
            ssf.ShowDialog();
        }

        private void reflectivityCorrectionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            calcReflectivityForm fileForm=new calcReflectivityForm();
            fileForm.MdiParent=this;
            fileForm.Show();
        }

        private void recipeScanToolStripMenuItem_Click(object sender, EventArgs e)
        {

            recipeScanForm rsForm1 = new recipeScanForm();
            plotForm pForm1 = new plotForm();
            rsForm1.loadQErigInst(ref mainQErigInst, ref mc1);
            rsForm1.MdiParent = this;
            pForm1.MdiParent = this;
            rsForm1.measurementStarted += new MeasruementStartEventhandler(showPlotWindow);

            activePlotForm = pForm1;

            rsForm1.measurementFinished += new MeasurmentFinishEventHandler(changePlotWindowProperties);
            rsForm1.Show();

        }

        

    }
}
