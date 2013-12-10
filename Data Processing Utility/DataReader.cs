using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
 
namespace DataProcessing
{
    public enum LoadFileType { DBQERef,DBQEDev,csv2col,csv1col,KHcsv};
    public class DataReader
    {
        System.IO.StreamReader readFile;


        public DataReader(string filePath)
        {
            try
            {
                readFile = new System.IO.StreamReader(filePath);
            }
            catch (Exception)
            {

                System.Windows.Forms.MessageBox.Show("Failed to load the file");
            }
        }

        public DataReader(string filePath, LoadFileType fType)
        {
            try
            {
                readFile = new System.IO.StreamReader(filePath);
            }
            catch (Exception)
            {

                System.Windows.Forms.MessageBox.Show("Failed to load the file");
            }
            loadDataArray(fType);
        }

        public DataReader(string filePath, int col1, int col2)
        {
            try
            {
                readFile = new System.IO.StreamReader(filePath);
            }
            catch (Exception)
            {

                System.Windows.Forms.MessageBox.Show("Failed to load the file");
            }
            loadMultiColCsvData(col1, col2);
        }

        public DataReader()
        {
            try
            {
                readFile = new System.IO.StreamReader("Newport 818-UV.CAL");
            }
            catch (Exception)
            {
                System.Windows.Forms.MessageBox.Show("Failed to load the calibration file");
            }
            loadDataArray(LoadFileType.csv2col);
        }

        public double[] dataArray1=new double[0];
        public double[] dataArray2=new double[0];
        internal singleColData[] fileDataColumn;

        /// <summary>
        /// Load data from a multi-columns csv file. 
        /// This function ignores any lines that cannot convert to double
        /// </summary>
        /// <param name="col1">the column number for the first array, the column number starts from zero</param>
        /// <param name="col2">the column number for the second array, the column number starts from zero</param>
        private void loadMultiColCsvData(int col1, int col2)
        {
            int len = 0;

            while (readFile.EndOfStream != true)
            {
                string tempStr = readFile.ReadLine();
                string[] dataStr = tempStr.Split(new char[] { ',', ' ', '\t' },
                    StringSplitOptions.RemoveEmptyEntries);
               
                try
                {
                    double temp1 = Convert.ToDouble(dataStr[col1]);
                    double temp2 = Convert.ToDouble(dataStr[col2]);

                    Array.Resize(ref dataArray1, len + 1);
                    Array.Resize(ref dataArray2, len + 1);

                    dataArray1[len] = temp1;
                    dataArray2[len] = temp2;

                    len++;
                }
                catch (FormatException)
                {
                    System.Diagnostics.Debug.WriteLine("Cannot convert the data in line {0} to double", len+1);                    
                }
                


            }
        }
        
        public void loadDataArray(LoadFileType ft)
        {
            switch (ft)
            {
                case LoadFileType.DBQERef:
                    try
                    {
                        bool dataStart = false;
                        int length = 0;
                        while (readFile.EndOfStream != true)
                        {
                            string tempStr = readFile.ReadLine();
                            if (dataStart == false)
                            {
                                if (tempStr.Contains("Wavelength (nm)"))
                                {
                                    dataStart = true;
                                }
                            }
                            else
                            {
                                string[] dataStr = tempStr.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                                Array.Resize(ref dataArray1, length + 1);
                                Array.Resize(ref dataArray2, length + 1);

                                dataArray1[length] = Convert.ToDouble(dataStr[0]);
                                dataArray2[length] = Convert.ToDouble(dataStr[1]);

                                length++;

                            }
                        }
                    }
                    catch (Exception)
                    {
                        System.Windows.Forms.MessageBox.Show("Fail to load the data from file. Please check the file");
                    }
                    break;
                case LoadFileType.csv2col:
                    int len = 0;
                    while (readFile.EndOfStream!=true)
                    {
                        string tempStr = readFile.ReadLine();
                        string[] dataStr = tempStr.Split(new char[] { ',',' ','\t' }, 
                            StringSplitOptions.RemoveEmptyEntries);
                        Array.Resize(ref dataArray1, len + 1);
                        Array.Resize(ref dataArray2, len + 1);

                        dataArray1[len] = Convert.ToDouble(dataStr[0]);
                        dataArray2[len] = Convert.ToDouble(dataStr[1]);

                        len++;
                    }
                    break;
                case LoadFileType.KHcsv:
                    loadDataArray_KHcsv();
                    break;
                case LoadFileType.DBQEDev:
                    try
                    {
                        bool dataStart = false;
                        bool convertedQEFile = false;
                        int length = 0;
                        while (readFile.EndOfStream != true)
                        {
                            string tempStr = readFile.ReadLine();
                            if (dataStart == false)
                            {
                                if (tempStr.Contains("Wavelength (nm)"))
                                {
                                    dataStart = true;
                                    if (tempStr.Contains("QE"))
                                    {
                                        convertedQEFile = true;
                                    }
                                }
                            }
                            else
                            {
                                string[] dataStr = tempStr.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                                Array.Resize(ref dataArray1, length + 1);
                                Array.Resize(ref dataArray2, length + 1);

                                dataArray1[length] = Convert.ToDouble(dataStr[0]);
                                if (convertedQEFile==true)
                                {
                                    dataArray2[length] = Convert.ToDouble(dataStr[3]);
                                }
                                else
                                {
                                    dataArray2[length] = Convert.ToDouble(dataStr[1]);
                                }
                                length++;

                            }
                        }
                    }
                    catch (Exception)
                    {
                        System.Windows.Forms.MessageBox.Show("Fail to load the data from file. Please check the file");
                    }
                    break;
            }
            
        }

        public string[] headerPart = new string[0];
        private void loadDataArray_KHcsv()
        {
            
            
            //Read the first row of the file
            string tempStr = readFile.ReadLine();
            string[] columnNameStr = tempStr.Split(new char[] { ',', '\t' }, StringSplitOptions.RemoveEmptyEntries);
            int headerCols = 2;
            int totalDataColumns = columnNameStr.Length - headerCols;
            if (columnNameStr[0] != "" && columnNameStr [1]!= "")
            {
                Array.Resize(ref headerPart, headerPart.Length + 1);
                headerPart[headerPart.GetUpperBound(0)] = columnNameStr[0] + "," + columnNameStr[1];
            }


            //use jagged array to store data;
            double[][] tempDataArray = new double[totalDataColumns][];

            fileDataColumn = new singleColData[totalDataColumns];

            //Initialise the arrays
            for (int i = 0; i < totalDataColumns; i++)
            {
                tempDataArray[i] = new double[0];
            }

            int len = 0;
            //Read the data part
            while (readFile.EndOfStream != true)
            {
                tempStr = readFile.ReadLine();
                String[] dataStr = tempStr.Split(new char[] { ',', '\t' });

                if (dataStr[0] != "" && dataStr[1] != "")
                {
                    Array.Resize(ref headerPart, headerPart.Length + 1);
                    headerPart[headerPart.GetUpperBound(0)] = dataStr[0] + "," + dataStr[1];
                }

                //only convert the third and the forth column in the data
                for (int i = 0; i < 2; i++)
                {
                    Array.Resize(ref tempDataArray[i], len + 1);
                    try
                    {
                        tempDataArray[i][len] = Convert.ToDouble(dataStr[i + headerCols]);
                    }
                    catch (FormatException)
                    {
                        string msg = "error in line#" + Convert.ToString(len + 2);
                        MessageBox.Show("Errors found in the file. Please check if the input file has correct format");
                        break;
                    }
                }
                len++;
            }

            //Write the data into single column data arrays
            for (int i = 0; i < totalDataColumns; i++)
            {
                fileDataColumn[i].name = columnNameStr[i + headerCols];
                fileDataColumn[i].data = tempDataArray[i];
            }

            //Write data to dataarray1 and dataarray2, this is temporary
            dataArray1 = fileDataColumn[0].data;
            dataArray2 = fileDataColumn[1].data;



        }
    }
}
