using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using NationalInstruments.VisaNS;
using System.Threading;


namespace Spectral_Response_AQ
{
    internal enum LIAInputMode { VoltageA, VoltageB, DiffAB, CurrentB, LowNoiseCurrentB };
    public class lockInAmp:deviceAbs
    {
        
        public enum LIAModel { SG7230, SG7265 }
        private double currentReading = -1;
        public LIAModel currentLIAModel=LIAModel.SG7230;
        public bool enableAutoRange=false;
        public double timeConstant = 2e-1;

        private double defaultDelayRatio = 3;
        private double defaultFixedDelay = 200;

        public double delayRatio = 3;
        public double fixedDelay = 200;
        
        /// <summary>
        /// Read data value back from the lock-in amplifier
        /// </summary>
        /// <returns>If result=="10000", 
        /// that means the lock-in amplifier is not either 7230 or 7265</returns>
        public string ReadDataFromLockIn(bool wait)
        {
            string temp;
            string result="10000";
            
            if (sessionCommType != commType.none)
            {
                if (enableAutoRange == true)
                {
                    doAutoRange();
                }
                if (wait == true)
                {
                    Thread.Sleep(totalDelay());
                }
                deviceSession.Write("MAG. \n");
                temp = deviceSession.ReadString();
                string[] resultStr = temp.Split(new char[] { '\n', '\0' });
                result=resultStr[0];
            }
            else
            {
                if (currentLIAModel == LIAModel.SG7230)
                {
                    result = "1e-9";
                }
                else if (currentLIAModel == LIAModel.SG7265)
                {
                    result = "1e-8";
                }
            }

            //write the lock-in reading into this.currentReading
            currentReading = Convert.ToDouble(result);

            return result;
        }

        public void setOffsetToZero()
        {
            deviceSession.Write("HOF 0\n");
            deviceSession.Write("YOF 0\n");
        }

        public string ReadXYFromLockIn(bool wait,ref double outputX,ref double outputY)
        {
            string temp;
            string result = "10000";

            if (sessionCommType != commType.none)
            {
                if (wait == true)
                {
                    Thread.Sleep(totalDelay());
                }
                deviceSession.Write("XY. \n");
                temp = deviceSession.ReadString();
                string[] resultStr = temp.Split(new char[] { '\n', '\0' ,','});
                result = resultStr[0];
                outputX = Convert.ToDouble(resultStr[0]);
                outputY = Convert.ToDouble(resultStr[1]);
            }
            else
            {
                if (currentLIAModel == LIAModel.SG7230)
                {
                    result = "3e-9";
                    outputX = 3e-9;
                }
                else if (currentLIAModel == LIAModel.SG7265)
                {
                    result = "3e-8";
                    outputY = 3e-8;
                }
            }

            //write the lock-in reading into this.currentReading
            currentReading = Convert.ToDouble(result);

            return result;

        }

        public string ReadPhaseFromLockIn(bool wait, ref double outputPhase)
        {
            string temp;
            string result = "10000";

            if (sessionCommType != commType.none)
            {
                if (wait == true)
                {
                    Thread.Sleep(totalDelay());
                }
                deviceSession.Write("PHA. \n");
                temp = deviceSession.ReadString();
                string[] resultStr = temp.Split(new char[] { '\n', '\0' });
                result = resultStr[0];
                outputPhase = Convert.ToDouble(resultStr[0]);
                
            }
            else
            {
                if (currentLIAModel == LIAModel.SG7230)
                {
                    result = "6e-9";
                    outputPhase = 6e-9;
                }
                else if (currentLIAModel == LIAModel.SG7265)
                {
                    result = "6e-8";
                    outputPhase = 6e-8;
                }
            }

            //write the lock-in reading into this.currentReading
            currentReading = Convert.ToDouble(result);

            return result;
        }

        public void setDelayToDefault()
        {
            this.delayRatio =this.defaultDelayRatio;
            this.fixedDelay = this.defaultFixedDelay;
        }

        public void setLockInToDefault()
        {
            //Set the time constant to 200ms
            sendSingleCommand("TC 13");

            //Set reference channel
            sendSingleCommand("IE 1");

            //Set all DAC channels to user-difined mode
            for (int i = 0; i < 4; i++)
            {
                setDACMode(i);
            }
        }

        public bool isDelayAtDefault()
        {
            if (this.delayRatio == this.defaultDelayRatio ||
                this.fixedDelay == this.defaultFixedDelay)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Read status byte from the lock-in amplifier.
        /// </summary>
        /// <returns>Return the read status byte. 
        /// StatusTypeFlags is enum type dervied from short integer</returns>
        public short ReadLIAStatusByte()
        {
            short statusByte = -1;
            string statusByteStr = "-1";
            try
            {
                if (sessionCommType==commType.GBIP)
                {
                    statusByte = (short)deviceSession.ReadStatusByte();
                }
                else if (sessionCommType == commType.VISA)
                {
                    deviceSession.Write("ST\n");
                    statusByteStr = trimString(
                        deviceSession.ReadString());
                    statusByte = Convert.ToInt16(statusByteStr);
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
            }
            return statusByte;
        }
        private Int32 totalDelay()
        {
            //GetTimeConstant(LockIn) * TCDelay + FixedDelay
           
   
            Int32 totalDelay = Convert.ToInt32(timeConstant*1e3 * delayRatio + fixedDelay);
            return totalDelay;
        }

        private void doAutoRange()
        {
            if (sessionCommType == commType.VISA && currentLIAModel==LIAModel.SG7230)
            {
                deviceSession.Write("MAG\n");
                string temp = deviceSession.ReadString();
                string[] resultStr = temp.Split(new char[] { '\n', '\0' });
                string result = resultStr[0];
                double reading = Convert.ToInt16(result);
                double fullScale = 10000;
                double ratio = reading / fullScale;
                if (ratio > 0.9 || ratio < 0.3)
                {
                    sendSingleCommand("AS");
                    //Add a time delay after perfoming autorange
                    Thread.Sleep(totalDelay());
                }
                
            }
            else if (sessionCommType == commType.VISA && currentLIAModel == LIAModel.SG7265)
            {
                deviceSession.Write("MAG\n");
                string temp = deviceSession.ReadString();
                string[] resultStr = temp.Split(new char[] { '\n', '\0' });
                string result = resultStr[0];
                double reading = Convert.ToInt16(result);
                double fullScale = 10000;
                double ratio = reading / fullScale;
                if (ratio > 0.9 || ratio < 0.3)
                {
                    deviceSession.Write("MAG\n");
                    waitCommandComplete();
                }


                Thread.Sleep(totalDelay());
            }
        }

        /// <summary>
        /// Reads the status byte, until the first bit of the status byte becomes 1. 
        /// This is only for GBIP based commnuication such as signal recovery 7265
        /// </summary>
        private void waitCommandComplete()
        {
            int sByte = 0;
            do
            {
                sByte = ReadLIAStatusByte();
            } while (sByte % 2 == 0);
        }

        private void doAutoPhase()
        {
                sendSingleCommand("IE");
        }

        /// <summary>
        /// Set signal input channel
        /// </summary>
        /// <param name="input">0: voltage, channel A
        /// 1: current, channel B, 2:low noise current mode</param>
        public void setSignalInputChannel(int input)
        {
            if (input == 0)
            {
                sendSingleCommand("IMODE 0");
                sendSingleCommand("VMODE 1");
            }
            else if (input == 1)
            {
                //IMODE takes precedence over VMODE
                sendSingleCommand("IMODE 1"); 
            }
            else if (input == 2)
            {
                sendSingleCommand("IMODE 2");
            }

        }

        private void sendSingleCommand(string command)
        {
            if (sessionCommType != commType.none)
            {
                deviceSession.Write(command+"\n");
               
                if (currentLIAModel == LIAModel.SG7230)
                {
                    //Read string from the lock-in amplifier, 
                    //which is essentially used as a probe to determine when this operation is ended.
                    try
                    {
                        deviceSession.ReadString();
                    }
                    catch (VisaException ve)
                    {
                        System.Windows.Forms.MessageBox.Show("visa exception " + ve.ErrorCode.ToString() + 
                            "when performing " + command);
                    }
                    
                }
                else if (currentLIAModel == LIAModel.SG7265)
                {
                    waitCommandComplete();
                }
                
            }
            
        }

        public double readTimeConstant()
        {
            string temp;
            string result = "10000";

            if (sessionCommType != commType.none)
            {
                deviceSession.Write("TC. \n");
                Thread.Sleep(100);
                temp = deviceSession.ReadString();
                string[] resultStr = temp.Split(new char[] { '\n', '\0' });
                result = resultStr[0];
            }
            else
            {
                if (currentLIAModel == LIAModel.SG7230)
                {
                    result = "2e-1";
                }
                else if (currentLIAModel == LIAModel.SG7265)
                {
                    result = "2e-1";
                }
            }

            //write the lock-in reading into this.currentReading
            this.timeConstant = Convert.ToDouble(result);

            return this.timeConstant;
        }




        public string readIPAddress()
        {
            string IPAdd;
            if (currentLIAModel == LIAModel.SG7230)
            {
                deviceSession.Write("IPADDR\n");
                IPAdd = deviceSession.ReadString();
            }
            else
            {
                IPAdd = "No IP address available";
            }
            
            return IPAdd;
        }

        private string trimString(string readString)
        {
           string[] resultStr=readString.Split(new char[]{'\n','\0'});
           return resultStr[0];
        }

        /// <summary>
        /// Specify the DAC channel
        /// </summary>
        /// <param name="channel">The number of the channel</param>
        /// <param name="mode">The mode of the channel. see P.6-21 in the manual. 
        /// Usually we set it to "6", as a user defined channel</param>
        public void setDACMode(int channel, int mode=6)
        {
            sendSingleCommand("CH " + Convert.ToString(channel) + " " + Convert.ToString(mode));
        }

        /// <summary>
        /// Set the output voltage of DAC channels
        /// </summary>
        /// <param name="channel"></param>
        /// <param name="voltage"></param>
        public void setDACVoltage(int channel, double voltage)
        {
            if (voltage <= 10 && voltage >= -10)
            {
                string command = "DAC. " + Convert.ToString(channel) + " " + Convert.ToString(voltage);
                sendSingleCommand(command);
            }
        }

    }
}
