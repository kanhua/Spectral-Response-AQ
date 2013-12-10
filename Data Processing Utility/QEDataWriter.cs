using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace DataProcessing
{
    public class QEDataWriter
    {
        singleColData[] fileData=new singleColData[0];
        string[] headerStrings;

        public QEDataWriter(string[] headerStrings)
        {
            this.headerStrings = headerStrings;
        }

        public QEDataWriter()
        {
            headerStrings=new string[]{"aaa","bbb","ccc"};
        }
        
        public void addColumn(string columnName, double[] data)
        {
            Array.Resize(ref fileData, fileData.Length + 1);
            fileData[fileData.GetUpperBound(0)].name = columnName;
            fileData[fileData.GetUpperBound(0)].data = data;
        }


        public void writeDataAndHeaderIntoFile(string fileName)
        {
            using (System.IO.StreamWriter writeFile = new System.IO.StreamWriter(fileName))
            {
                int totalRows = Math.Max(fileData[0].data.Length + 1,headerStrings.Length);
                for (int i = 0; i < totalRows; i++)
                {
                    //write header columns
                    if (i <= headerStrings.GetUpperBound(0))
                    {
                        writeFile.Write(headerStrings[i]);
                        writeFile.Write(",");
                    }
                    else
                    {
                        writeFile.Write(",,");
                    }

                    //write data
                    if (i == 0)
                    {
                        foreach (singleColData sCol in fileData)
                        {
                            writeFile.Write(sCol.name);
                            writeFile.Write(",");
                        }
                    }
                    else
                    {
                        foreach (singleColData sCol in fileData)
                        {
                            //Write data if the index is still within the array length
                            if ((i - 1) < sCol.data.Length)
                            {
                                double temp = sCol.data[i - 1];

                                if (temp <= 10000 || temp >= 0.001)
                                {
                                    writeFile.Write(temp.ToString("G"));
                                    writeFile.Write(",");
                                }
                                else
                                {
                                    writeFile.Write(temp.ToString("E"));
                                    writeFile.Write(",");
                                }
                            }
                        }
                    }
                    writeFile.WriteLine();
                }
            }
        }
        
        public void writeDataIntoFile(string fileName)
        {
            using (System.IO.StreamWriter writeFile = new System.IO.StreamWriter(fileName))
            {
                foreach (singleColData sCol in fileData)
                {
                    writeFile.Write(sCol.name);
                    writeFile.Write(",");
                }
                writeFile.WriteLine();
                int totalRows = fileData[0].data.Length;
                for (int i = 0; i < totalRows; i++)
                {
                    foreach (singleColData sCol in fileData)
                    {
                        writeFile.Write(sCol.data[i]);
                        writeFile.Write(",");
                    }
                    writeFile.WriteLine();
                }
            }
        }

        public void writeDataIntoDBFormatFile(string fileName)
        {
            using (System.IO.StreamWriter writeFile = new System.IO.StreamWriter(fileName))
            {
                foreach (singleColData sCol in fileData)
                {
                    writeFile.Write("{0,-20}",sCol.name);
                }
                writeFile.WriteLine();
                int totalRows = fileData[0].data.Length;
                for (int i = 0; i < totalRows; i++)
                {
                    foreach (singleColData sCol in fileData)
                    {
                        writeFile.Write("{0,-20}",sCol.data[i]);
                    }
                    writeFile.WriteLine();
                }
            }

        }


    }
    struct singleColData
    {
        internal string name;
        internal double[] data; 
    }
}
