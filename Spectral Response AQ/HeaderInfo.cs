using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Spectral_Response_AQ
{
    public class HeaderInfo
    {
        singleHeader[] fileHeader = new singleHeader[0];

        public HeaderInfo()
        {
            generateBasicInfo();
        }
        
        public void generateBasicInfo()
        {
            singleHeader[] basicInfo = new singleHeader[5];
            
            //File Type
            basicInfo[0].fillContent("File Type", "CSV001");

            //Experiment Type
            basicInfo[1].fillContent("Experiment", "Spectral Response");
            
            
            //Software version
            
            try
            {
                System.Reflection.Assembly assem = System.Reflection.Assembly.GetExecutingAssembly();
                System.Reflection.AssemblyName assemName = assem.GetName();
                Version ver = assemName.Version;

                System.Deployment.Application.ApplicationDeployment ad =
                    System.Deployment.Application.ApplicationDeployment.CurrentDeployment;
                Version pubVer = ad.CurrentVersion;
                basicInfo[2].fillContent("Software Version", pubVer.ToString());
            }
            catch (Exception)
            {
                
                basicInfo[2].fillContent("Software Version", "Software version unavailable");
            }

            //Date
            DateTime currentTime = DateTime.Now;
            basicInfo[3].fillContent("Time", currentTime.ToString());
            
            //Experiement ID
            basicInfo[4].fillContent("Experiment ID", System.Environment.MachineName);

            fileHeader = basicInfo;
        }

        
        public void addHeaderLine(string tag, string content)
        {
            Array.Resize(ref fileHeader, fileHeader.Length + 1);
            fileHeader[fileHeader.GetUpperBound(0)].tag = tag;
            fileHeader[fileHeader.GetUpperBound(0)].content = content;
        }

        internal void addHeaderLine(singleHeader[] headers)
        {
            foreach (singleHeader item in headers)
            {
                addHeaderLine(item.tag, item.content);
            }
        }

        public string[] generateHeaderStrings()
        {
            string[] tempStr = new string[fileHeader.Length];
            for (int i = 0; i < fileHeader.Length; i++)
            {
                tempStr[i] = fileHeader[i].tag + "," + fileHeader[i].content;
            }
            return tempStr;
        }
    }
    internal struct singleHeader
    {
        internal string tag;
        internal string content;

        internal void fillContent(string tag,string content)
        {
            this.tag=tag;
            this.content=content;
        }
    }
}
