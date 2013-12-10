using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Spectral_Response_AQ;

namespace TestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            int a = 1;
            string filePath = @"C:\Users\kl07\Dropbox\Documents in Dropbox\PhD online\C# Projects\Spectral Response AQ\Spectral Response AQ\3JTop.txt";
            QERecipe qp = new QERecipe(filePath);

        }
    }
}
