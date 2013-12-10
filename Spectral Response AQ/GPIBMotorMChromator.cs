using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using NationalInstruments.VisaNS;
using System.Threading;

namespace Spectral_Response_AQ
{
   
    public class GPIBMotorMChromator:MChromatorAbs
    {

        private bool virtualMachineMode=false;
        
        /// <summary>
        /// Estimated moving time of the monochromator
        /// </summary>
        public int timePerDial;


        public double dialMoveStepCorrection = 20;


        public filterBound[] fBounds=new filterBound[6];

        private double parkWavelength = 600;
        
        public GPIBMotorMChromator()
        {
            setFilterRange();
            currentWavelength = 0;
            lightSourceState = 0;
            gratingState = 0;
        }

        private void setFilterRange()
        {
            fBounds[0]=new filterBound(); //empty filter
            fBounds[1] = new filterBound(400, 700);
            fBounds[2] = new filterBound(700, 1200);
            fBounds[3] = new filterBound();
            fBounds[4]= new filterBound();
            fBounds[5]=new filterBound();
        }

        public override double currentWavelength
        {
            get
            {
                return dtow(currentMCDial);
            }
        }
        
        /// <summary>
        /// Generate a command for the monochromator
        /// </summary>
        /// <param name="direction">'I'=increment, 'D'=decrement</param>
        /// <param name="step">steps needed to be moved forward or backward</param>
        /// <param name="speed">speed: 'C'=400, 'D'=200, 'E'=100, 'F'=40, 'G'=20, 'J'=10</param>
        /// <returns></returns>
        private string GenMCCommand(char direction, double step, char speed)
        {
            string command;
            string stepcorrection;
            step = Math.Floor(step);

            //The following statements produce a 4 digit step number.
            if (step < 10)
            {
                stepcorrection = "000" + Convert.ToString(step);
            }
            else if (step < 100)
            {
                stepcorrection = "00" + Convert.ToString(step);
            }
            else if (step < 1000)
            {
                stepcorrection = "0" + Convert.ToString(step);
            }
            else
            {
                stepcorrection = Convert.ToString(step);
            }

            command = Convert.ToString(direction) + stepcorrection +
                      Convert.ToString(speed) + "\n";
            Debug.WriteLine(command);
            return command;

        }

        //Converting a wavelength to a dial reading

        /// <summary>
        /// Converting wavelenght to dial reading
        /// </summary>
        /// <param name="wave">wavelength in nm</param>
        /// <returns></returns>
        private double wtod(double wave)
        {
            double mcDial;
            mcDial = wave * gratingSlope + gratingOffset;
            
            return mcDial;
        }

        private double dtow(double dial)
        {
            double wave;
            wave = (dial - gratingOffset) / gratingSlope;

            return wave;
        }

        /// <summary>
        /// Move the grating dial of the monochromator
        /// </summary>
        /// <param name="currentReading">Current dial reading of the monochromator</param>
        /// <param name="targetReading">The dial that needs to be moved to</param>
        /// <returns></returns>
        private void MoveMCWLDial(double currentReading, double targetReading)
        {
            string command = "";
            if (currentReading < targetReading)
            {
                command = GenMCCommand('I',
                    (targetReading - currentReading) * dialMoveStepCorrection, 'W');
            }
            else if (currentReading > targetReading)
            {
                command = GenMCCommand('D',
                    (currentReading - targetReading) * dialMoveStepCorrection, 'W');
            }
            if (virtualMachineMode == false)
            {
                if (sessionCommType == commType.VISA)
                {
                    deviceSession.Write(command);
                }
                else if (sessionCommType == commType.GBIP)
                {
                    //monochromatorGBIP.Write(command);
                }
            }
            else
            {
                Debug.Write("Send the command:");
                Debug.Write(command);
                Debug.WriteLine("to the monochromator");
            }

        }

        public override void MoveMCWLDial(double targeReading)
        {
            MoveMCDialDistance(targeReading - currentMCDial);
        }

        public override void parkMonochromator()
        {
            MoveMCAndFilter(parkWavelength);
        }
        //public void MoveMCWLDial(double targetReading)
        //{
        //    string command = "";
        //    if (currentMCDial < targetReading)
        //    {
        //        command = GenMCCommand('I',
        //            (targetReading - currentMCDial) * dialMoveStepCorrection, 'W');
        //    }
        //    else if (currentMCDial > targetReading)
        //    {
        //        command = GenMCCommand('D',
        //            (currentMCDial - targetReading) * dialMoveStepCorrection, 'W');
        //    }

        //    if (virtualMachineMode == false)
        //    {
        //        if (sessionCommType == commType.VISA)
        //        {
        //            deviceSession.Write(command);
        //        }
        //        else if (sessionCommType == commType.GBIP)
        //        {
        //            //monochromatorGBIP.Write(command);
        //        }
        //        int timePerCount = 200; // the time needed for moving one count in the monochromator
        //        Thread.Sleep(timePerCount * Convert.ToUInt16(Math.Floor(Math.Abs(currentMCDial - targetReading))));
        //        currentMCDial = targetReading;
        //    }
        //    else
        //    {
        //        Debug.Write("Send the command:");
        //        Debug.Write(command);
        //        Debug.WriteLine("to the monochromator");
        //    }
        //}

  

        public void MoveMCDialDistance(double dialDifference)
        {
            string command = "";
            double downOffset=20;
            double leftDialDifference = 0;
            double movedDialDifference = 0;

            int timePerCount = 200; // the time needed for moving one count in the monochromator
            if (dialDifference>downOffset)
            {
                timePerCount = 50;
                command = GenMCCommand('I',
                    (dialDifference-downOffset)* dialMoveStepCorrection, 'R');
                leftDialDifference = downOffset;
                movedDialDifference = dialDifference - downOffset;
            }
            else if(dialDifference<=downOffset && dialDifference>=0)
            {
                timePerCount = 200;
                command = GenMCCommand('I',
                    (dialDifference) * dialMoveStepCorrection, 'W');
                leftDialDifference = 0;
                movedDialDifference = dialDifference;
            }
            else if (dialDifference<0 && dialDifference<-downOffset)
            {
                timePerCount = 50;
                command = GenMCCommand('D',
                    (-(dialDifference)+downOffset) * dialMoveStepCorrection, 'R');
                leftDialDifference = downOffset;
                movedDialDifference = dialDifference - downOffset;
            }
            else if (dialDifference<0 && dialDifference > -downOffset)
            {
                timePerCount = 200;
                command = GenMCCommand('D',
                   (-dialDifference) * dialMoveStepCorrection, 'W');
                leftDialDifference = 0;
                movedDialDifference = dialDifference;
            }

            if (virtualMachineMode == false)
            {
                if (sessionCommType == commType.VISA)
                {
                    deviceSession.Write(command);
                }
                else if (sessionCommType == commType.GBIP)
                {
                    //monochromatorGBIP.Write(command);
                }
               
                Thread.Sleep(timePerCount * Convert.ToUInt16(Math.Floor(Math.Abs(dialDifference))));
                currentMCDial = currentMCDial + movedDialDifference;
                if (leftDialDifference != 0)
                {
                    MoveMCDialDistance(leftDialDifference);
                }
                

            }
            else
            {
                Debug.Write("Send the command:");
                Debug.Write(command);
                Debug.WriteLine("to the monochromator");
            }
        }

        public override void MoveMCWL(double targetWavelength)
        {
            double targetDial = wtod(targetWavelength);
            MoveMCWLDial(targetDial);
        }

        private void MoveMCFilterDial(double currentReading, double targetReading)
        {
            string command = "";
            if (currentReading < targetReading)
            {
                command = GenMCCommand('D',
                    (targetReading - currentReading) , 'T');
            }
            else if (currentReading > targetReading)
            {
                command = GenMCCommand('I',
                    (targetReading - currentReading) , 'T');
            }

            if (sessionCommType == commType.VISA)
            {
                deviceSession.Write(command);
                currentFilterDial = targetReading;
            }
            else if (sessionCommType == commType.GBIP)
            {
                //monochromatorGBIP.Write(command);
                currentFilterDial = targetReading;
            }
        }

        public override void MoveMCFilterDial(double targetReading)
        {
            string command = "";
            if (currentFilterDial < targetReading)
            {
                command = GenMCCommand('D',
                    (targetReading - currentFilterDial) , 'T');
            }
            else if (currentFilterDial > targetReading)
            {
                command = GenMCCommand('I',
                    (currentFilterDial - targetReading) , 'T');
            }
            if (sessionCommType == commType.VISA)
            {
                deviceSession.Write(command);
                currentFilterDial = targetReading;
            }
            else if (sessionCommType == commType.GBIP)
            {
                //monochromatorGBIP.Write(command);
                currentFilterDial = targetReading;
            }
        }

 
        public override void MoveMCAndFilter(double targetWavelength)
        {
            int targetFilter = -1; //set initial value to be negative
            for (int i = 0; i <= fBounds.GetUpperBound(0); i++)
            {
                if (fBounds[i].checkBetween(targetWavelength))
                {
                    targetFilter = i;
                }
            }

            try
            {
                MoveMCFilterDial(filterPositions[targetFilter]);
                Thread.Sleep(2000);
                MoveMCWL(targetWavelength);

                currentFilterDial = filterPositions[targetFilter];
                currentMCDial = wtod(targetWavelength);
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
            }
        }

        public override int getCurrentSAM()
        {
            return 0;
        }

        public override void setCurrentSAM(int samState)
        {
            return;
        }

        public override void getCurrentGrating(ref int gratingState)
        {
            return;
        }

        public override void setCurrentGrating(int gratingState)
        {
            return;
        }
    
    }


    public class filterBound
    {
        public int upperBound;
        public int lowerBound;

        public filterBound(int lower, int upper)
        {
            setBound(lower, upper);
        }
        public filterBound()
        {
            setBound(-1, -1);
        }


        public void setBound(int lower,int upper)
        {
            upperBound = upper;
            lowerBound = lower;
        }

        public bool checkBetween(double wavelength)
        {
            bool result;
            if ((wavelength <= this.upperBound) && (wavelength >= this.lowerBound))
            {
                result = true;
            }
            else
            {
                result = false;
            }
            return result;
        }

    }
}
