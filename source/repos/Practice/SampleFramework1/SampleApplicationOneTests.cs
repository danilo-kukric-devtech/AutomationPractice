using System;
using System.IO;
using System.Reflection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace SampleFramework1
{
    [TestClass]
    [TestCategory("SampleApplicationOne")]
    public class SampleApplicationOneTests
    {
        private IWebDriver Driver { get; set; }
        
        [TestMethod]
        public void Test1()
        {
            Driver = GetChromeDriver();
            var sampleApplicationPage = new SampleApplicationPage(Driver);
            sampleApplicationPage.GoTo();
            Assert.IsTrue(sampleApplicationPage.IsVisible,"Sample application page is not visible");

            var ultimateHomePage = sampleApplicationPage.FillOutFormAndSubmit("Danilo");
            Assert.IsTrue(ultimateHomePage.IsVisible,"UltimateQA home page is not visible");
            Driver.Close();
            Driver.Quit();
        }

        private IWebDriver GetChromeDriver()
        {
            var path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            return  new ChromeDriver(path);
        }
    }
}
