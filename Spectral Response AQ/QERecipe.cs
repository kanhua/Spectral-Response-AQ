using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Diagnostics;

namespace Spectral_Response_AQ
{
    public class QERecipe
    {
        public double startWavelength=400;
        public double endWavelength=1000;
        public double step=1;

        public double deviceBias=0;
        public double[] lightBias=new double[3]{0,0,0};

        public int LIAChannel=0;
        public bool biasBox=false;


        public QERecipe(string fileName)
        {
            try
            {
                // Create an instance of StreamReader to read from a file. 
                // The using statement also closes the StreamReader. 
                using (StreamReader sr = new StreamReader(fileName))
                {
                    string line;
                    // Read and display lines from the file until the end of  
                    // the file is reached. 
                    while ((line = sr.ReadLine()) != null)
                    {
                        string[] cols = line.Split(new Char[] { ',' });
                        switch (cols[0])
                        {
                            case "startWavelength":
                                startWavelength = Convert.ToDouble(cols[1]);
                                break;
                            case "endWavelength":
                                endWavelength = Convert.ToDouble(cols[1]);
                                break;
                            case "step":
                                step = Convert.ToDouble(cols[1]);
                                break;
                            case "LIAChannel":
                                LIAChannel=Convert.ToInt16(cols[1]);
                                break;
                            case "biasBox":
                                biasBox=Convert.ToBoolean(cols[1]);
                                break;
                            case "deviceBias":
                                deviceBias=Convert.ToDouble(cols[1]);
                                break;
                            case "lightBias1":
                                lightBias[0] = Convert.ToDouble(cols[1]);
                                break;
                            case "lightBias2":
                                lightBias[1] = Convert.ToDouble(cols[1]);
                                break;
                            case "lightBias3":
                                lightBias[2] = Convert.ToDouble(cols[1]);
                                break;
                        }

                        Debug.WriteLine(line);
                    }
                }
            }
            catch (Exception e)
            {
                // Let the user know what went wrong.
                Console.WriteLine("The file could not be read:");
                Console.WriteLine(e.Message);
            }

        }
        
        
        /// <summary>
        /// Show the recipe setting form. The properties of the recipe can be changed in the form.
        /// </summary>
        public void showRecipeSettingForm()
        {

        }

        /// <summary>
        /// Create a summary of the recipe. This text summary can be displayed in the textbox of the recipe editor
        /// </summary>
        public void generateDescription()
        {
        }


        
    }
}
