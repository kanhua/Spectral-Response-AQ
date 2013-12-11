using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;
using System.IO;
using System.Diagnostics;

namespace Spectral_Response_AQ
{
    public partial class BenDLLMChromator:MChromatorAbs
    {

        [DllImport("benhw32_cdecl.dll", CallingConvention = CallingConvention.Cdecl)]
        static extern public int BI_build_system_model(StringBuilder configInput, StringBuilder error);

        [DllImport("benhw32_cdecl.dll", CallingConvention = CallingConvention.Cdecl)]
        static extern public int BI_load_setup(StringBuilder configInput);

        [DllImport("benhw32_cdecl.dll", CallingConvention = CallingConvention.Cdecl)]
        static extern public int BI_initialise();

        [DllImport("benhw32_cdecl.dll", CallingConvention = CallingConvention.Cdecl)]
        static extern public int BI_park();

        [DllImport("benhw32_cdecl.dll", CallingConvention = CallingConvention.Cdecl)]
        static extern public int BI_get(StringBuilder id, int token, int index, ref double value);

        [DllImport("benhw32_cdecl.dll", CallingConvention = CallingConvention.Cdecl)]
        static extern public int BI_set(StringBuilder id, int token, int index, double value);

        [DllImport("benhw32_cdecl.dll", CallingConvention = CallingConvention.Cdecl)]
        static extern public int BI_select_wavelength(double wavelength, ref long delay);


        //StreamWriter statusLog = new StreamWriter("statuslog.log");

        private StringBuilder sam = new StringBuilder("sam", 10);

        private StringBuilder mChromator = new StringBuilder("mchromator", 20);

        public BenDLLMChromator()
        {
            //initVISASession();
            currentWavelength = getCurrentWavelength();
            deviceName = "TMc300 MChromator";

            //set grating name;
            gratingName = new string[2] { "1200L/mm(250-1101nm)", "600L/mm(800-2501nm)" };
        }

        /// <summary>
        /// Initialise the monochromator.
        /// </summary>
        /// <param name="developmentMode"></param>
        public override void initVISASession(bool developmentMode=false,int arg1=0)
        {
            int enableXe = arg1;
            StringBuilder error = new StringBuilder("", 100);
            //string input_file = @"C:\Program Files\Bentham\SDK\Configuration Files\system0.cfg";
            StringBuilder systemConfigFile = new
                StringBuilder(@"system.cfg", 100);

            StringBuilder systemSimModeConfigFile = new
                StringBuilder(@"system0.cfg", 20);




            //Load System Model
            int result = BI_build_system_model(systemConfigFile, error);

            if (result == BI_OK)
            {
                Debug.Write("initialized OK\n");
            }
            else
            {
                result = BI_build_system_model(systemSimModeConfigFile, error);
                if (result != BI_OK)
                {
                    Debug.Write(error.ToString());
                    throw new Exception("read system.cfg error");
                }
            }

            //Load set up
            
            
            StringBuilder systemAtrFile = new StringBuilder("system.atr", 100);
            StringBuilder systemAtrwithXeFile = new StringBuilder("system_enableXe.atr", 100);
            StringBuilder systemAtrwithXeAllRangeFile = new StringBuilder("system_enableXeForAllRange.atr", 100);
            
            if (enableXe==1)
            {
                result = BI_load_setup(systemAtrwithXeFile);
            }
            else if(enableXe==2)
            {
                result = BI_load_setup(systemAtrwithXeAllRangeFile);
            }
            else
            {
                result = BI_load_setup(systemAtrFile);
            }
            
            

            if (result == 0)
            {
                Debug.Write("Load Setup OK");
            }
            else
            {
                Debug.Write("Load Setup failed with error code: " + Convert.ToString(result));
            }

            //Init the system
            result = BI_initialise();
            if (result == 0)
            {
                Debug.Write("Initialization OK");
            }
            else
            {
                Debug.Write("Initialization failed with error code: " + Convert.ToString(result));
            }

            //Park monochromator
            parkMonochromator();

            //test region: test SAMSwitchState
            //setSwitchingSAMState(1);
           // setSwitchingSAMStateWL(500);
        }

        public override void parkMonochromator()
        {
            int result = BI_park();
            if (result == 0)
            {
                Debug.Write("Monochromator parked\n");
            }
            else
            {
                Debug.Write("Initialization failed with error code: " + Convert.ToString(result));
            }

        }

        public virtual double getCurrentWavelength()
        {
            double wavelength = 100;
            int result = BI_get(mChromator, 11, 0, ref wavelength);
            if (result == 0)
            {
                Debug.Write("get wavelength OK\n");
            }
            else
            {
                Debug.Write("get wavelength failed\n");
            }
            return wavelength;
        }

        public override void MoveMCAndFilter(double setWavelength)
        {
            long delay = 0;
            int result = BI_select_wavelength(setWavelength, ref delay);
            if (result == BI_OK)
            {
                System.Threading.Thread.Sleep(Convert.ToInt16(delay));
                Debug.Write("Wavelength set!!\n");
                currentWavelength = setWavelength;
            }
            else
            {
                Debug.Write("see wavelength failed\n");
            }
        }

        public override void MoveMCWL(double targetWavelength)
        {
            int result = BI_set(mChromator, MonochromatorCurrentWL, 0, targetWavelength);
            if (result == BI_OK)
            {
                Debug.Write("Wavelength set!!\n");
                //currentWavelengthTextBox.Text = Convert.ToString(setWavelength);
                currentWavelength = targetWavelength;
            }
            else
            {
                Debug.Write("see wavelength failed\n");
            }
        }

        public override void MoveMCWLDial(double dial)
        {
            throw new NotImplementedException();
        }

        public override void MoveMCFilterDial(double targetReading)
        {
            throw new NotImplementedException();
        }

        public override int getCurrentSAM()
        {
            double samState=-1;
            int result = BI_get(sam, SAMCurrentState, 0, ref samState);
            
            return Convert.ToInt16(samState);
        }

        public override void setCurrentSAM(int samState)
        {
            int result=BI_set(sam,SAMCurrentState,0,Convert.ToDouble(samState));
        }


        public override void getCurrentGrating(ref int gratingState)
        {
            double gState = 0;
            int result = BI_get(mChromator, MonochromatorCurrentGrating, 0, ref gState);
            if (result == BI_OK)
            {
                gratingState = Convert.ToInt16(gState);
            }
            else
            {
                throw new System.Exception("get current grating error");
            }
        }

        public override void setCurrentGrating(int gratingState)
        {
            double gState = 0;
            int result = BI_set(mChromator, MonochromatorCurrentGrating, 0, Convert.ToDouble(gratingState));
            if (result == BI_OK)
            {
                gratingState = Convert.ToInt16(gState);
            }
            else
            {
                throw new System.Exception("set current grating error");
            }
        }

        public void setSwitchingSAMState(double switchingSAMState)
        {
            BI_set(mChromator, SAMState, 0, switchingSAMState);
        }

        public void setSwitchingSAMStateWL(double switchingWavelength)
        {
            BI_set(mChromator, SAMSwitchWL, 0, switchingWavelength);
        }
       

        public override int lightSourceState
        {
            get
            {
                return getCurrentSAM();
            }
            set
            {
                setCurrentSAM(value);
            }
        }

        public override int gratingState
        {
            get
            {
                int st=0;
                getCurrentGrating(ref st);
                return st;
            }
            set
            {
                setCurrentGrating(value);
            }
        }
    }
}
