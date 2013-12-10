using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;



namespace DataProcessing
{
    public partial class dataPlotForm : Form
    {
        GraphUtility.Graph dataGraph = new GraphUtility.Graph();
        public dataPlotForm()
        {
            InitializeComponent();
        }
        public void plotData(ref double[] xdata, ref double[] ydata)
        {
            dataGraph.DeleteAllSeries();
            for (int i = 0; i < xdata.Length; i++)
            {
                dataGraph.AddPoint(1, xdata[i], ydata[i]);
            }
            dataGraph.SetupAxes();
            dataGraph.Render(ref pictureBox1);
        }

        public void plotData(pairXYData[] xydata)
        {
            dataGraph.DeleteAllSeries();
            for (int i = 0; i < xydata.Length; i++)
            {
                dataGraph.AddPoint(1, xydata[i].XData, xydata[i].YData);
            }
            dataGraph.SetupAxes();
            dataGraph.Render(ref pictureBox1);
        }
       
    }
}
