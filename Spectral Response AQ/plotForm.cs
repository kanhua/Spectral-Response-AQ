using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;


namespace Spectral_Response_AQ
{
    public partial class plotForm : Form
    {
        GraphUtility.Graph graphInst = new GraphUtility.Graph();

        int seriesNum = 1;
        public plotForm()
        {
            InitializeComponent();
        }

        public void setUpAxes()
        {
            graphInst.SetupAxes(false,false);
            
        }
        public void setXYAxesTitle(string xTitle, string yTitle)
        {
            graphInst.XTitle = xTitle;
            graphInst.YTitle = yTitle;
        }

        public void addPoint(int series,double x,double y)
        {
            graphInst.AddPoint(series, x, y);
            graphInst.SetupAxes(false, false);
            graphInst.Render(ref plotPictureBox);
        }

        public void addSeries(double[] dataX,double[] dataY,bool clearall=true)
        {
            if (clearall)
            {
                graphInst.DeleteAllSeries();
                seriesNum = 1;
            }
            
            for (int i = 0; i < dataX.Length; i++)
            {
                graphInst.AddPoint(seriesNum, dataX[i], dataY[i]);
            }
            graphInst.SetupAxes(false, false);
            graphInst.Render(ref plotPictureBox);
        }

        private void plotForm_ResizeEnd(object sender, EventArgs e)
        {
            plotPictureBox.Width = this.Width - 30;
            plotPictureBox.Height = this.Height - 60;
            graphInst.Render(ref plotPictureBox);
        }

        private void openQEFileDialog_FileOk(object sender, CancelEventArgs e)
        {
            string[] selectedFileNames = openQEFileDialog.FileNames;
            foreach (string selectedFile in selectedFileNames)
            {
                DataProcessing.DataReader dReader = new
                    DataProcessing.DataReader(selectedFile, DataProcessing.LoadFileType.KHcsv);
                graphInst.Series[seriesNum].Name = System.IO.Path.GetFileName(selectedFile);
                addSeries(dReader.dataArray1, dReader.dataArray2, false);
                seriesNum++;
            }
            graphInst.AutoPlaceLegend();
        }

        private void clearAll()
        {
            graphInst.DeleteAllSeries();
            graphInst.Render(ref plotPictureBox);
        }

        private void addPlotToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openQEFileDialog.Multiselect = true;
            openQEFileDialog.ShowDialog();
        }

      


        
    
        
    }
}
