using System;
using SOA_Generation_Service;
using SOA_Generation_Service.Report;
using SOA_Generation_Service.ReportModel;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tool = utilities;
using System.Collections.Generic;

namespace SoaTest
{
    [TestClass]
    public class UnitTest1
    {
        Tool.DataAccessProperties tool = new Tool.DataAccessProperties();
        [TestMethod]
        public void GetWeekOfMonth()
        {
            int result = DateTimeExtensions.GetWeekOfMonth(DateTime.Parse("April 30, 2017"));

            Assert.AreEqual(5, result);


        }

        [TestMethod]
        public void GetWeekOfYear()
        {
            int result = DateTimeExtensions.GetWeekOfYear(DateTime.Parse("March 12, 2017"));

            Assert.AreEqual(5, result);


        }
        [TestMethod]
        public void GetLastWeekOfMonth()
        {
            int isLastWeek = DateTimeExtensions.GetLastWeekOfMonth(DateTime.Parse("April 28, 2017"));
            Assert.AreEqual(1, isLastWeek);
        }

        [TestMethod]
        public void TestReport()
        {
            //32AF304F-09AA-40A9-B131-E541E1ED8827
            //77F64DD0-C604-406D-B5E0-9A78D7B39E7C
            //9034C5C7-4123-468B-82AA-A225DDA15367
            int result = 0;
            Guid[] ids = new Guid[] { Guid.Parse("9034C5C7-4123-468B-82AA-A225DDA15367"), Guid.Parse("32AF304F-09AA-40A9-B131-E541E1ED8827"), Guid.Parse("77F64DD0-C604-406D-B5E0-9A78D7B39E7C") };
            foreach (Guid item in ids)
            {
                SOA_Generation_Service.PrintStatementOfAccount printer = new PrintStatementOfAccount(item, @"C:\Users\AP Cargo Sub Server\Desktop\CMS Web Client 2.0 (Web App)\CMSVersion2\Corporate\SOAPrintedPDF", "Data Source = 192.168.1.58, 1434; Initial Catalog = cms2_Beta3; User ID = sa; Password = mssql; Connect Timeout = 180; Connection Lifetime = 0; Pooling = true;");
                result += printer.Print();
            }


            Assert.AreEqual(3, result);
        }

        [TestMethod]
        public void TestService()
        {
            int result = 0;
            List<int> bill = new List<int> { 7, 15, 30 };
            foreach (int item in bill)
            {
                StatementOfAccountGeneration gen = new StatementOfAccountGeneration(item);
                result++;
            }
            Assert.AreEqual(3, result);
        }
    }
}
