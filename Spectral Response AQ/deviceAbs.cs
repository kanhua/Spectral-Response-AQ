using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NationalInstruments.VisaNS;
using System.Diagnostics;

namespace Spectral_Response_AQ
{
    public abstract class deviceAbs
    {
        protected enum commType { GBIP, VISA, none };
        protected commType sessionCommType=commType.none;

        protected MessageBasedSession deviceSession;
        public string VISAResourceName;

        public bool deviceEnabled = false;
        public bool sessionInitialised = false;

        public string deviceName = "";

        /// <summary>
        /// Initialize the VISA communication
        /// </summary>
        /// <param name="resourceName">VISA resource name</param>
        public virtual void initVISASession(string resourceName,bool developmentMode=false)
        {
            if (developmentMode == false)
            {
                try
                {
                    VISAResourceName = resourceName;
                    deviceSession = (MessageBasedSession)ResourceManager.GetLocalManager().Open(resourceName);
                    sessionCommType = commType.VISA;
                    sessionInitialised = true;
                }
                catch (InvalidCastException)
                {
                    Debug.WriteLine("Resource selected must be a message-based session");
                    sessionInitialised = false;
                    sessionCommType = commType.none;
                }
                catch (Exception exp)
                {
                    Debug.WriteLine(exp.Message);
                    System.Windows.Forms.MessageBox.Show(VISAResourceName + " initialization fails");
                    System.Windows.Forms.MessageBox.Show(exp.Message);
                    sessionInitialised = false;
                    sessionCommType = commType.none;
                }
                finally
                {
                    //Cursor.Current = Cursors.Default;
                }
            }
            else
            {
                sessionInitialised = false;
                sessionCommType = commType.none;
            }

        }

        public virtual void initVISASession(bool developmentMode = false,int arg1=0)
        {
            initVISASession(this.VISAResourceName,developmentMode);
        }

        public virtual void disableVISASession()
        {
            sessionInitialised = false;
            sessionCommType = commType.none;
        }

        public virtual void disposeVISASession()
        {
            try
            {
                if (deviceSession != null)
                {
                    deviceSession.Dispose();
                    sessionCommType = commType.none;
                    sessionInitialised = false;
                    VISAResourceName = "";
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
            }
        }
        

    }
}
