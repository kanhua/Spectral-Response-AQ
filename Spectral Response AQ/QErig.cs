//Defining the libraries that are being used:
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using GraphUtility;

namespace Spectral_Response_AQ
{
    enum lockInAmpInputMode { voltageChannel, currentChannel };
    public delegate void ReadLIAEventHandler(object sender, EventArgs e);
    
    
    /// <summary>
    /// This class is an interface between LIA and monochromator objects.
    /// </summary>
    public class QErig
    {

        public MChromatorAbs[] mcInst;
        public lockInAmp[] LIAInst;

        private int defaultMChromatorIndex = 2;

        public MChromatorAbs activeMC;
        public lockInAmp dutLIA;
        public lockInAmp refLIA;

        /// <summary>
        /// The index in LIAInst array which is assigned to be DUT lock-in amplifier
        /// </summary>
        private int dutLIAIndex = 0;
        /// <summary>
        ///  The index in LIAInst array which is assigned to be reference lock-in amplifier
        /// </summary>
        private int refLIAIndex = 1;

        public bool activateREFLIA = true;

        private lockInAmpInputMode inputMode;

        private bool throughDevBox = false;

        private Graph quickScanGraph = new Graph();

        public double[] wavelength ;
        public double[] dutPhotocurrent ;
        public double[] refPhotocurrent ;
        public double[] currentSAM;
        public double[] currentGrating;
        public double[] dutOutputX;
        public double[] dutOutputY;
        public double[] dutOutputPhase;

        /// <summary>
        /// An object that specifies the value of device bais channel
        /// </summary>
        private DACChannelIdentifier deviceBiasDAC;
        /// <summary>
        /// An object that specifies tha vlues of light bias channels
        /// </summary>
        private DACChannelIdentifier[] lightBiasDAC;

        private double deviceBiasVoltage = 0;
        private double[] lightBiasVoltage = new double[]{0,0,0};

        /// <summary>
        /// The load resistor value in the device bias box
        /// </summary>
        private double loadResistor = 10000;

        /// <summary>
        /// The upper limit of the light bias voltage
        /// </summary>
        private double lightBiasCompliance = 2.2;

        public void loadDeviceInst(ref MChromatorAbs[] mcInst, ref lockInAmp[] LIAInst)
        {
            this.mcInst = mcInst;
            this.LIAInst = LIAInst;
            activeMC = mcInst[defaultMChromatorIndex];
            
            try
            {
                dutLIA = LIAInst[dutLIAIndex];
            }
            catch (IndexOutOfRangeException)
            {
                throw;
            }


            try
            {
                refLIA = LIAInst[refLIAIndex];
            }
            catch (IndexOutOfRangeException)
            {
                refLIA = new lockInAmp();
                throw;
            }
            
            
            specifyDACChannels();
        }

        private void specifyDACChannels()
        {
            deviceBiasDAC = new DACChannelIdentifier(0, 1);
            lightBiasDAC = new DACChannelIdentifier[3];
            lightBiasDAC[0] = new DACChannelIdentifier(0, 2);
            lightBiasDAC[1] = new DACChannelIdentifier(0, 3);
            lightBiasDAC[2] = new DACChannelIdentifier(0, 4);
        }

        public void setDeviceBias(double voltage)
        {
            LIAInst[deviceBiasDAC.LIANum].setDACVoltage(deviceBiasDAC.DACNum, voltage);
            deviceBiasVoltage = voltage;
        }

        public void setLightBias(int lightBiasChannel, ref double voltage)
        {
            if (voltage>=this.lightBiasCompliance)
            {
                voltage = this.lightBiasCompliance;
            }
            else if (voltage < 0)
            {
                voltage = -0.05;
            }
            LIAInst[lightBiasDAC[lightBiasChannel].LIANum].setDACVoltage(
                lightBiasDAC[lightBiasChannel].DACNum, voltage);
            lightBiasVoltage[lightBiasChannel] = voltage;
        }

        private void addDataIntoMemory()
        {
            Array.Resize(ref wavelength, wavelength.Length + 1);
            wavelength[wavelength.GetUpperBound(0)] = currentWavelength;

            Array.Resize(ref dutPhotocurrent, dutPhotocurrent.Length + 1);            
            dutPhotocurrent[dutPhotocurrent.GetUpperBound(0)] = currentDUTLockInReading;

            Array.Resize(ref refPhotocurrent, refPhotocurrent.Length + 1);
            refPhotocurrent[refPhotocurrent.GetUpperBound(0)] = currentREFLockInReading;

            Array.Resize(ref currentSAM, currentSAM.Length + 1);
            currentSAM[currentSAM.GetUpperBound(0)] = Convert.ToDouble(activeMC.lightSourceState);

            Array.Resize(ref currentGrating, currentGrating.Length + 1);
            currentGrating[currentGrating.GetUpperBound(0)] = Convert.ToDouble(activeMC.gratingState);

            Array.Resize(ref dutOutputX, dutOutputX.Length + 1);
            dutOutputX[dutOutputX.GetUpperBound(0)] = Convert.ToDouble(currentDUTOuputX);

            Array.Resize(ref dutOutputY, dutOutputY.Length + 1);
            dutOutputY[dutOutputY.GetUpperBound(0)] = Convert.ToDouble(currentDUTOuputY);

            Array.Resize(ref dutOutputPhase, dutOutputPhase.Length + 1);
            dutOutputPhase[dutOutputPhase.GetUpperBound(0)] = Convert.ToDouble(currentDUTPhase);
            
        }

        public event ReadLIAEventHandler LIAReadFinish;
        public double currentWavelength=0;

        public bool measurementContinue = true;
        public double currentDUTLockInReading = 0;
        public double currentREFLockInReading = 0;
        public double currentDUTOuputX = 0;
        public double currentDUTOuputY = 0;
        public double currentDUTPhase=0;
        
        /// <summary>
        /// Perform quick scan
        /// </summary>
        /// /// <param name="startWavelength">start wavelength in nm</param>
        /// <param name="endWavelength">end wavelength in nm</param>
        /// <param name="step">scan step</param>
        /// <param name="throughBiasBox">true for measureing through device bias box, 
        /// false for measuring through current channel</param>
        /// <param name="autoSelectFilter">true if auto select filter</param>
        public void quickScan(double startWavelength, double endWavelength,
            double step, int dutLIAInputMode, int refLIAInputMode,bool throughDevBox ,bool autoSelectFilter = true)
        {
            
            if (wavelength == null)
            {
                wavelength = new double[0];
            }
            else
            {
                Array.Resize(ref wavelength, 0);
            }

            if (dutPhotocurrent == null)
            {
                dutPhotocurrent = new double[0];
            }
            else
            {
                Array.Resize(ref dutPhotocurrent, 0);
            }

            if (refPhotocurrent == null)
            {
                refPhotocurrent = new double[0];
            }
            else
            {
                Array.Resize(ref refPhotocurrent, 0);
            }

            if (currentSAM == null)
            {
                currentSAM = new double[0];
            }
            else
            {
                Array.Resize(ref currentSAM, 0);
            }

            if (currentGrating == null)
            {
                currentGrating = new double[0];
            }
            else
            {
                Array.Resize(ref currentGrating, 0);
            }

            if (dutOutputPhase == null)
            {
                dutOutputPhase = new double[0];
            }
            else
            {
                Array.Resize(ref dutOutputPhase, 0);
            }
            if (dutOutputX == null)
            {
                dutOutputX = new double[0];
            }
            else
            {
                Array.Resize(ref dutOutputX, 0);
            }
            if (dutOutputY == null)
            {
                dutOutputY = new double[0];
            }
            else
            {
                Array.Resize(ref dutOutputY, 0);
            }



            int numberOfReadingsToBeAveraged = 5;

            this.throughDevBox = throughDevBox;
            
            //Change the mode of lock-in amplifier based on input mode
            dutLIA.setSignalInputChannel(dutLIAInputMode);
            refLIA.setSignalInputChannel(refLIAInputMode);

            //Set offset of the input channels to zero
            dutLIA.setOffsetToZero();

            //Load time constant
            dutLIA.readTimeConstant();
            
            double currentWavelength = startWavelength;
            while (currentWavelength <= endWavelength)
            {
                Application.DoEvents();
                
                //exit this loop if the measurment termination flag is on
                if (measurementContinue == false)
                {
                     //Reset it to true, or the measurement won't start next time.
                    measurementContinue = true;
                    activeMC.parkMonochromator();
                    break;
                }

                if (autoSelectFilter)
                {
                    activeMC.MoveMCAndFilter(currentWavelength);
                }
                else
                {
                    activeMC.MoveMCWL(currentWavelength);
                }
                
                double dutLockInReading = System.Convert.ToDouble(dutLIA.ReadDataFromLockIn(true));
                double refLockInReding;
                if (activateREFLIA)
                {
                    refLockInReding = Convert.ToDouble(refLIA.ReadDataFromLockIn(true));
                }

                double dutTempReading=0;
                double refTempReading = 0;
                for (int i = 0; i < numberOfReadingsToBeAveraged; i++)
                {
                    dutTempReading += Convert.ToDouble(dutLIA.ReadDataFromLockIn(false));
                    if (activateREFLIA)
                    {
                        refTempReading += Convert.ToDouble(refLIA.ReadDataFromLockIn(false));
                    }
                    
                }
                dutLockInReading = dutTempReading / numberOfReadingsToBeAveraged;
                if (activateREFLIA)
                {
                    refTempReading = refTempReading / numberOfReadingsToBeAveraged;
                }
               
                inputMode = lockInAmpInputMode.currentChannel;

                //Decide how to deal with the read back data
                if (throughDevBox == true && dutLIAInputMode==0)
                {
                    //when using bias box
                    this.currentDUTLockInReading = dutLockInReading / loadResistor;
                }
                else
                {
                    //when measuring from current channel
                    this.currentDUTLockInReading = dutLockInReading;
                }



                this.currentREFLockInReading = refTempReading;

                this.currentWavelength = currentWavelength;

                dutLIA.ReadXYFromLockIn(false, ref this.currentDUTOuputX, ref this.currentDUTOuputY);

                dutLIA.ReadPhaseFromLockIn(false, ref this.currentDUTPhase);
                addDataIntoMemory();
                LIAReadFinish(this,EventArgs.Empty);
                
                currentWavelength += step;
            }

            activeMC.parkMonochromator();
        }


        internal singleHeader[] generateQESettingHeader()
        {
            singleHeader[] QESettingHeader = new singleHeader[8];
            QESettingHeader[0].fillContent("Load resistor", Convert.ToString(loadResistor));
            QESettingHeader[1].fillContent("Monochromator", activeMC.deviceName);

            string inputModeStr = "";
            if (throughDevBox == false)
            {
                inputModeStr = "Measure directly through channel B";
            }
            else
            {
                inputModeStr = "Measure through device bias box and voltage channel";
            }
            QESettingHeader[2].fillContent("Input Mode", inputModeStr);

            QESettingHeader[3].fillContent("device bias:", Convert.ToString(deviceBiasVoltage));
            QESettingHeader[4].fillContent("light bias 1:", Convert.ToString(lightBiasVoltage[0])+" V");
            QESettingHeader[5].fillContent("light bias 2:", Convert.ToString(lightBiasVoltage[1])+" V");
            QESettingHeader[6].fillContent("light bias 3:", Convert.ToString(lightBiasVoltage[2]) + " V");

            if (activeMC.deviceName.Contains("TMc300") == true)
            {
                int start = QESettingHeader.Length;
                Array.Resize(ref QESettingHeader, start + 4);
                QESettingHeader[start].fillContent("light state 0:", "Halogen");
                QESettingHeader[start+1].fillContent("light state 1:", "Xenon");
                QESettingHeader[start+2].fillContent("grating state 0:", "1200L/mm");
                QESettingHeader[start+3].fillContent("grating state 1:", "600L/mm");
            }

            else if (activeMC.deviceName.Contains("M300") == true)
            {
                int start = QESettingHeader.Length;
                Array.Resize(ref QESettingHeader, start + 2);
                QESettingHeader[start].fillContent("grating factor", Convert.ToString(activeMC.gratingSlope));
                QESettingHeader[start + 1].fillContent("grating slope", Convert.ToString(activeMC.gratingOffset));
            }
             
            return QESettingHeader;
        }
      
    }
    internal struct DACChannelIdentifier
    {
        internal int LIANum;
        internal int DACNum;
        internal DACChannelIdentifier(int lia, int dac)
        {
            this.LIANum = lia;
            this.DACNum = dac;
        }
    }
}
