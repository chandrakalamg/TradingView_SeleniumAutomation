using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using AventStack.ExtentReports.Reporter.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HybridFwk_POM_TradingView.util
{
    class ExtentReport
    {
        private static ExtentReports extent;
        private static ExtentHtmlReporter htmlReporter;
        private static ExtentTest test;

        public static void StartReport()
        {
            var solutionDir = Directory.GetParent(AppDomain.CurrentDomain.BaseDirectory).Parent.Parent.FullName;
            var reportPath = Path.Combine(solutionDir, @"Reports\");
            htmlReporter = new ExtentHtmlReporter(reportPath + "reporter.html");
            extent = new ExtentReports();
            extent.AttachReporter(htmlReporter);
        }

        public static void CreateTest(string testName)
        {
            test = extent.CreateTest(testName);
        }

        public static void LogTestStep( Status status, string message)
        {
            test.Log(status, message);
        }

        public static void StopReport()
        {
            extent.Flush();
            
        }
    }
}
