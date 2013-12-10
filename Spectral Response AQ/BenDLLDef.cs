namespace Spectral_Response_AQ
{
    public partial class BenDLLMChromator
    {
        //#-----------------------------------------------------------------------------
        //# Bentham Instruments Spectroradiometer Control DLL
        //# Error code definition file
        //#-----------------------------------------------------------------------------

        const int BI_OK = 0;
        const int BI_error = -1;
        const int BI_invalid_token = -2;
        const int BI_invalid_component = -3;
        const int BI_invalid_attribute = -4;

        const int BI_no_error = 0;

        const int BI_PMC_timeout = 1;
        const int BI_MSC_timeout = 2;
        const int BI_MSD_timeout = 3;
        const int BI_MAC_timeout = 4;
        const int BI_MAC_invalid_cmd = 5;

        const int BI_225_dead = 10;
        const int BI_265_dead = 11;
        const int BI_267_dead = 12;
        const int BI_277_dead = 13;

        const int BI_262_dead = 14;

        const int BI_ADC_read_error = 20;
        const int BI_ADC_invalid_reading = 21;

        const int BI_AMP_invalid_channel = 30;
        const int BI_AMP_invalid_wavelength = 31;
        const int BI_SAM_invalid_wavelength = 32;
        const int BI_turret_invalid_wavelength = 33;
        const int BI_turret_incorrect_pos = 34;
        const int BI_MVSS_invalid_width = 35;

        const int BI_undefined_error = 100;

        //-----------------------------------------------------------------------------
        // Monochromator attributes
        //-----------------------------------------------------------------------------
        const int MonochromatorScanDirection = 10;
        const int MonochromatorCurrentWL = 11;
        const int MonochromatorCurrentDialReading = 12;
        const int MonochromatorParkDialReading = 13;
        const int MonochromatorCurrentGrating = 14;
        const int MonochromatorPark = 15;
        const int MonochromatorSelfPark = 16;
        const int MonochromatorModeSwitchNum = 17;
        const int MonochromatorModeSwitchState = 18;
        const int MonochromatorCanModeSwitch = 19;

        const int Gratingd = 20;
        const int GratingZ = 21;
        const int GratingA = 22;
        const int GratingWLMin = 23;
        const int GratingWLMax = 24;
        const int GratingX2 = 25;
        const int GratingX1 = 26;
        const int GratingX = 27;

        const int ChangerZ = 50;

        //-----------------------------------------------------------------------------
        // Filter wheel attributes
        //-----------------------------------------------------------------------------
        const int FWheelFilter = 100;
        const int FWheelPositions = 101;
        const int FWheelCurrentPosition = 102;

        //-----------------------------------------------------------------------------
        // TLS attributes
        //-----------------------------------------------------------------------------
        const int TLSCurrentPosition = 150;
        const int TLSWL = 151;
        const int TLSPOS = 152;
        const int TLSSelectWavelength = 153;
        const int TLSPositionsCommand = 154;

        //-----------------------------------------------------------------------------
        // SAM attributes
        //-----------------------------------------------------------------------------
        const int SAMInitialState = 300;
        const int SAMSwitchWL = 301;
        const int SAMState = 302;
        const int SAMCurrentState = 303;
        const int SAMDeflectName = 304;
        const int SAMNoDeflectName = 305;

        //-----------------------------------------------------------------------------
        // Stepper SAM attributes
        //-----------------------------------------------------------------------------
          const int SSEnergisedSteps  = 320;
          const int SSRelaxedSteps    = 321;
          const int SSMaxSteps        = 322;
          const int SSSpeed           = 323;
          const int SSMoveCurrent     = 324;
          const int SSIdleCurrent     = 325;

    }
}