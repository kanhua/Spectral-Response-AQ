using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DataProcessing;

namespace Spectral_Response_AQ
{
    public partial class calcReflectivityForm : Form
    {
        public string DUTFullFilePath;
        public string REFFullFilePath;
        public string mirrorRefFullFilePath;
        
        public calcReflectivityForm()
        {
            InitializeComponent();
        }

        private void selectDUTButton_Click(object sender, EventArgs e)
        {
            openFileDialog1.Reset();
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                DUTFileTextBox.Text = openFileDialog1.FileName;
                DUTFullFilePath = openFileDialog1.FileName;
            }
        }

        private void selectReferenceButton_Click(object sender, EventArgs e)
        {
            openFileDialog1.Reset();
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                referenceTextBox.Text = openFileDialog1.FileName;
                REFFullFilePath = openFileDialog1.FileName;
            }
        }

        private void selectMirrorRefButton_Click(object sender, EventArgs e)
        {
            openFileDialog1.Reset();
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                mirrorRefTextBox.Text = openFileDialog1.FileName;
                mirrorRefFullFilePath = openFileDialog1.FileName;
            }
        }

        private void convertButton_Click(object sender, EventArgs e)
        {
            string visRangeFilePath = @"C:\SpectralResponseAQSettingFiles\mirror_cali_vis.txt";
            string nirRangeFilePath = @"C:\SpectralResponseAQSettingFiles\mirror_cali_NIR.txt";
           
            DataReader CALFile = new DataReader(mirrorRefFullFilePath, 0, 1);       //calibrated mirror reflectivity file
            DataReader REFFile = new DataReader(REFFullFilePath, LoadFileType.KHcsv); //mirror reflectance file
            DataReader DUTFile = new DataReader(DUTFullFilePath, LoadFileType.KHcsv);

            DataReader CALFileRange1 = new DataReader(visRangeFilePath, 0, 1);
            DataReader CALFileRange2 = new DataReader(nirRangeFilePath, 0, 1);


            string DUTFileName = System.IO.Path.GetFileNameWithoutExtension(DUTFullFilePath);
            string DUTDir = System.IO.Path.GetDirectoryName(DUTFullFilePath);
            string DUText = System.IO.Path.GetExtension(DUTFullFilePath);
            string newDUTFullPathForRange1 = System.IO.Path.Combine(DUTDir, DUTFileName + "_converted1" + DUText);
            string newDUTFullPathFoAllRange = System.IO.Path.Combine(DUTDir, DUTFileName + "_converted" + DUText);

           
            double[] REFPhotocurrent=new double[]{0};
            double switchWavelength = Convert.ToDouble(switchWavelengthTextBox.Text);

            XYDataArray deviceQERange1 = new XYDataArray();
            XYDataArray devicePCRange1 = new XYDataArray();
            XYDataArray calibratedREFRange1 = new XYDataArray();

            calibrateSpectrum(DUTFile,REFFile,CALFileRange1,ref deviceQERange1,
                ref devicePCRange1, ref calibratedREFRange1,0, switchWavelength);
            
            QEDataWriter dWriter = new QEDataWriter(DUTFile.headerPart);
            dWriter.addColumn("Wavelength (nm)", deviceQERange1.getDataArray(0));
            dWriter.addColumn("Reflectivity (%)", deviceQERange1.getDataArray(1));
            dWriter.addColumn("DUT Reflectance (nA)", devicePCRange1.getDataArray(1));
            dWriter.addColumn("Mirror Reflectance (nA)", calibratedREFRange1.getDataArray(1));
 //           dWriter.writeDataAndHeaderIntoFile(newDUTFullPathForRange1);

            XYDataArray deviceQERange2 = new XYDataArray();
            XYDataArray devicePCRange2 = new XYDataArray();
            XYDataArray calibratedREFRange2 = new XYDataArray();

            calibrateSpectrum(DUTFile, REFFile, CALFileRange2, ref deviceQERange2,
                ref devicePCRange2, ref calibratedREFRange2, switchWavelength,2000);

            XYDataArray allDeviceQE = XYDataArray.concate(deviceQERange1, deviceQERange2);
            XYDataArray allDevicePC = XYDataArray.concate(devicePCRange1, devicePCRange2);
            XYDataArray allCalibratedREF = XYDataArray.concate(calibratedREFRange1, calibratedREFRange2);

            dWriter = new QEDataWriter(DUTFile.headerPart);
            dWriter.addColumn("Wavelength (nm)", allDeviceQE.getDataArray(0));
            dWriter.addColumn("Reflectivity (%)", allDeviceQE.getDataArray(1));
            dWriter.addColumn("DUT Reflectance (nA)", allDevicePC.getDataArray(1));
            dWriter.addColumn("Mirror Reflectance (nA)", allCalibratedREF.getDataArray(1));

            dWriter.writeDataAndHeaderIntoFile(newDUTFullPathFoAllRange);
        }

        private XYDataArray calibrateSpectrum(DataReader DUTFile,DataReader REFFile,DataReader CALFile,ref XYDataArray deviceQE,
            ref XYDataArray devicePhotocurrent, ref XYDataArray calibratedREF,double lowerbound,double upperbound)
        {

            XYDataArray origCAL = new XYDataArray(ref CALFile.dataArray1, ref CALFile.dataArray2);
            //newCAL is the calibrated photodiode QE based on the wavelength scanned in reference file
            XYDataArray newCAL = origCAL.generateNewXYArray(ref REFFile.dataArray1);

            XYDataArray origREF = new XYDataArray(ref REFFile.dataArray1, ref REFFile.dataArray2);
            //newCAL = newCAL.YByACoef(0.01);
            newCAL = newCAL.Yinverse();

            double[] tempArr = newCAL.getDataArray(0);
            //the array size of newCAL may be less the origREF.Xarray, 
            //so we need to generate the new array again
            calibratedREF = origREF.generateNewXYArray(ref tempArr);
           

            calibratedREF = calibratedREF.Yproduct(ref newCAL);

            
            //This data array is for keeping the for the original photocurrent data
            devicePhotocurrent = new XYDataArray(ref DUTFile.dataArray1, ref DUTFile.dataArray2);

            //This data array is for later conversion
            deviceQE = new XYDataArray(ref DUTFile.dataArray1, ref DUTFile.dataArray2);
            
            XYDataArray calibratedREFtoDev = calibratedREF.generateNewXYArray(ref DUTFile.dataArray1);
            tempArr = calibratedREFtoDev.getDataArray(0);
            deviceQE = deviceQE.generateNewXYArray(ref tempArr);
            calibratedREFtoDev = calibratedREFtoDev.Yinverse();
            deviceQE = deviceQE.Yproduct(ref calibratedREFtoDev);
            //deviceQE = deviceQE.YByACoef(100);
            deviceQE.showData();

            //trim the data based on the selected range
            XYDataArray tmp_deviceQE = deviceQE.selectRange(lowerbound, upperbound);
            deviceQE = tmp_deviceQE;

            XYDataArray tmp_devicePC = deviceQE.selectRange(lowerbound, upperbound);
            devicePhotocurrent = tmp_devicePC;

            XYDataArray tmp_calibratedREF = calibratedREF.selectRange(lowerbound, upperbound);
            calibratedREF = tmp_calibratedREF;

            return deviceQE;

        }

        //private void selectRangeComboBox_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    if (selectRangeComboBox.SelectedIndex == 0)
        //    {
        //        string visRangeFilePath = @"C:\SpectralResponseAQSettingFiles\mirror_cali_vis.txt";
        //        mirrorRefTextBox.Text = visRangeFilePath;
        //        mirrorRefFullFilePath = visRangeFilePath;
        //    }
        //    else if (selectRangeComboBox.SelectedIndex == 1)
        //    {
        //        string nirRangeFilePath = @"C:\SpectralResponseAQSettingFiles\mirror_cali_NIR.txt";
        //        mirrorRefTextBox.Text = nirRangeFilePath;
        //        mirrorRefFullFilePath = nirRangeFilePath;
        //    }
        //}



        


    }
}
