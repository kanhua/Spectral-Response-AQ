using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataProcessing
{
    /// <summary>
    /// A class that manipulates the values of XY data array
    /// </summary>
    public class XYDataArray
    {

        public pairXYData[] XYData=new pairXYData[0];


        public XYDataArray()
        {
            this.XYData = new pairXYData[0];
        }
        
        public XYDataArray(ref double[] arrayX, ref double[] arrayY)
        {
            if(checkDimensionAligned(ref arrayX, ref arrayY))
            {
                Array.Resize(ref XYData, arrayX.GetLength(0));
                for (int i = 0; i < arrayX.GetLength(0); i++)
                {
                    XYData[i].XData = arrayX[i];
                    XYData[i].YData = arrayY[i];
                }
            }
        }



        public XYDataArray(XYDataArray data)
        {
            this.XYData = data.XYData;
        }

        private bool checkDimensionAligned(ref double[] arrayA, ref double[] arrayB)
        {
            if (arrayA.GetLength(0) == arrayB.GetLength(0))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        //private bool sort(ref double[] array);

        private double interpolate(double x1, double x2, double y1, double y2, double xp)
        {
            double yp = ((y2 - y1) / (x2 - x1)) * (xp - x2) + y2;
            return yp;
        }

        public double[] getDataArray(int dim)
        {
            double[] tempArray = new double[XYData.Length];
            for (int i = 0; i < tempArray.Length; i++)
            {
                if (dim == 0)
                {
                    tempArray[i] = XYData[i].XData;
                }
                else if (dim == 1)
                {
                    tempArray[i] = XYData[i].YData;
                }
            }
            return tempArray;
            
        }

        
        public XYDataArray generateNewXYArray(ref double[] arrayX)
        {
            //double tempX = XYData[0].XData;

            //create a new array X and array Y
            double[] newArrayX = new double[0];
            double[] newArrayY = new double[0];

            //index that counts the length of newly created array
            int newArrayIdx=0;

            int refArrayIndex = 0;
            int arrayXidx = 0;
            foreach (double newX in arrayX)
            {
                while (refArrayIndex <= XYData.GetUpperBound(0))
                {
                    if (newX < XYData[refArrayIndex].XData)
                    {
                        
                        if (refArrayIndex == 0)
                        {
                            //do extrapolation if at boundary

                            //discard boundary for the time being
                            //newArrayY[arrayXidx] = -1000;
                            break;
                        }
                        else
                        {
                            //do interpolation betwen XYData[j] and XYData[j-1]
                            double tempX = XYData[refArrayIndex].XData;
                            double nextTempX = XYData[refArrayIndex-1].XData;
                            double tempY = XYData[refArrayIndex].YData;
                            double nextTempY = XYData[refArrayIndex-1].YData;

                            Array.Resize(ref newArrayX, newArrayIdx+1);
                            Array.Resize(ref newArrayY, newArrayIdx+1);

                            newArrayX[newArrayIdx] = newX;
                            newArrayY[newArrayIdx] = interpolate(tempX, nextTempX, tempY, nextTempY,newX);
                            newArrayIdx++;
                            break;
                        }
                    }
                    else if (newX > XYData[refArrayIndex].XData)
                    {
                        //continue, go to next index
                        if (refArrayIndex <= XYData.GetUpperBound(0))
                        {
                            refArrayIndex++;
                        }
                    }
                    else if (newX == XYData[refArrayIndex].XData)
                    {
                        Array.Resize(ref newArrayX, newArrayIdx + 1);
                        Array.Resize(ref newArrayY, newArrayIdx + 1);

                        newArrayX[newArrayIdx] = newX;
                        newArrayY[newArrayIdx] = XYData[refArrayIndex].YData;
                        newArrayIdx++;
                        break;
                    }
                }
                arrayXidx++;
            }

            //create a XYDataArray to store the generated  X Y values
            XYDataArray newXYDataArray = new XYDataArray(ref newArrayX, ref newArrayY);
            return newXYDataArray;

        }

        public void showData()
        {
            dataPlotForm d1 = new dataPlotForm();
            d1.plotData(XYData);
            d1.Show();
        }

        public XYDataArray Yproduct(ref XYDataArray data)
        {
            double[] tempArray1 = this.getDataArray(0);
            double[] tempArray2 = this.getDataArray(1);
            XYDataArray productData = new XYDataArray(ref tempArray1, ref tempArray2);
            if (XYData.Length != data.XYData.Length)
            {
                return null;
            }
            else
            {
                for (int i = 0; i < XYData.Length; i++)
                {
                    productData.XYData[i].YData = this.XYData[i].YData * data.XYData[i].YData;
                }
            }
            return productData;
        }

        public XYDataArray YByACoef(double coefficient)
        {
            XYDataArray newData = new XYDataArray(this); 
            for (int i = 0; i < XYData.Length; i++)
            {
                newData.XYData[i].YData *= coefficient;
            }
            return newData;
        }
        public XYDataArray Yinverse()
        {
            XYDataArray newData = new XYDataArray(this);
            for (int i = 0; i < XYData.Length; i++)
            {
                newData.XYData[i].YData = 1 / newData.XYData[i].YData;
            }
            return newData;
        }

        /// <summary>
        /// Trime the data outside the assigned lower bound and upper bound
        /// </summary>
        /// <param name="lowerbound"></param>
        /// <param name="upperbound"></param>
        /// <returns></returns>
        public XYDataArray selectRange(double lowerbound, double upperbound)
        {
            int totalLength = this.XYData.GetLength(0);
            double[] newXDataArray = new double[totalLength];
            double[] newYDataArray = new double[totalLength];
            int k = 0;
            for (int i = 0; i < totalLength; i++)
            {
                if (this.XYData[i].XData >= lowerbound && this.XYData[i].XData <= upperbound)
                {
                    newXDataArray[k] = this.XYData[i].XData;
                    newYDataArray[k] = this.XYData[i].YData;
                    k++;
                }
            }
            Array.Resize(ref newXDataArray, k);
            Array.Resize(ref newYDataArray, k);
            return new XYDataArray(ref newXDataArray, ref newYDataArray);
        }

        static public XYDataArray concate(XYDataArray A, XYDataArray B)
        {
            int ALength = A.XYData.GetLength(0);
            int BLength = B.XYData.GetLength(0);

            double[] newXDataArray = new double[ALength+BLength];
            double[] newYDataArray = new double[ALength + BLength];
          
            for (int i = 0; i < ALength; i++)
            {
                    newXDataArray[i] = A.XYData[i].XData;
                    newYDataArray[i] = A.XYData[i].YData;
            }

            for (int i = 0; i < BLength; i++)
            {
                newXDataArray[i + ALength] = B.XYData[i].XData;
                newYDataArray[i + ALength] = B.XYData[i].YData;
            }

            return new XYDataArray(ref newXDataArray, ref newYDataArray);
        }

    }
    public struct pairXYData
    {
        public double XData;
        public double YData;
    }
}
