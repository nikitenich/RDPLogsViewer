using Microsoft.VisualStudio.TestTools.UnitTesting;
using RDPLogsViewer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static RDPLogsViewer.MainForm;

namespace RDPLogsViewer.Tests
{
    [TestClass()]
    public class MainFormTests
    {
        [TestMethod()]
        public void generateQueryStringByCheckedListBoxesTest()
        {
            List<int> selected1 = new List<int> { 39, 40 };
            List<int> selected2 = new List<int> { 39 };
            Assert.AreEqual("*[System[(EventID=39 or EventID=40)]]",
                generateQueryStringByCheckedListBoxes(selected1));
            Assert.AreEqual("*[System[(EventID=39)]]",
                generateQueryStringByCheckedListBoxes(selected2));
        }
    }
}