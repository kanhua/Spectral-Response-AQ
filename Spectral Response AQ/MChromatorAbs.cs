using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Spectral_Response_AQ
{
    public abstract class MChromatorAbs:deviceAbs
    {

        public double gratingOffset = -7.2842;
        public double gratingSlope = 0.6733;

        public double currentMCDial = 399;

        public virtual int lightSourceState
        {
            get;
            set;
        }
        public virtual int gratingState
        {
            get;
            set;
        }
        public virtual double currentWavelength
        {
            get;
            set;
        }

        public double currentFilterDial = 0;

        public int[] filterPositions = new int[6] { 0, 33, 67, 100, 134, 167 };

        public string[] gratingName=new string[1] {"not assigned yet"};

        public abstract void MoveMCWL(double targeWavelength);

        public abstract void MoveMCAndFilter(double targetWavelength);

        public abstract void MoveMCFilterDial(double targetReading);
        
        public abstract void MoveMCWLDial(double dial);

        public abstract int getCurrentSAM();

        public abstract void setCurrentSAM(int samState);

        public abstract void setCurrentGrating(int gratingState);

        public abstract void getCurrentGrating(ref int gratingState);

        public abstract void parkMonochromator();

    }
}
