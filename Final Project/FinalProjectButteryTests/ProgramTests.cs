using Microsoft.VisualStudio.TestTools.UnitTesting;
using FinalProjectButtery;
using System;
using System.Collections.Generic;
using System.Text;

namespace FinalProjectButtery.Tests
{
    [TestClass()]
    public class ProgramTests
    {

        [TestMethod()]
        public void SearchForCarStockTest()
        {

            int stockNumber = 123;
            Program.SearchForCarStock(stockNumber);
            return;

        }

        [TestMethod()]
        public void SearchForCarYearTest()
        {

            int year = 2004;
            Program.SearchForCarYear(year);
            return;


        }

        [TestMethod()]
        public void SearchForCarMakeTest()
        {
            string make = "Ford";
            Program.SearchForCarMake(make);
            return;
        }

        [TestMethod()]
        public void SearchForCarModelTest()
        {
            string model = "Taurus";
            Program.SearchForCarModel(model);
            return;
        }

        [TestMethod()]
        public void SearchForCarColorTest()
        {
            string color = "red";
            Program.SearchForCarColor(color);
            return;
        }
    }
}