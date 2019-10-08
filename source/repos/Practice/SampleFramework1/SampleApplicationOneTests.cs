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
        public TestUser TheTestUser { get; private set; }

        [TestMethod]
        public void Test1()
        {
            var sampleApplicationPage = new SampleApplicationPage(Driver);
            sampleApplicationPage.GoTo();
           
            var ultimateHomePage = sampleApplicationPage.FillOutFormAndSubmit(TheTestUser);
            Assert.IsTrue(ultimateHomePage.IsVisible,"UltimateQA home page is not visible");
            
        }
        [TestMethod]
        public void PretendTestNumber2()
        {
            var sampleApplicationPage = new SampleApplicationPage(Driver);
            sampleApplicationPage.GoTo();
           
            var ultimateHomePage = sampleApplicationPage.FillOutFormAndSubmit(TheTestUser);
            Assert.IsFalse(!ultimateHomePage.IsVisible, "UltimateQA home page is not visible");
        }
     
        private IWebDriver GetChromeDriver()
        {
            var path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            return  new ChromeDriver(path);
        }
        [TestInitialize]
        public void SetupForEverySingleTestMethod()
        {
            Driver = GetChromeDriver();
            TheTestUser = new TestUser();
            TheTestUser.FirstName = "Danilo";
            TheTestUser.LastName = "Kukric";
        }
        [TestCleanup]
        public void CleanupAfterEveryTestMethod()
        {
            Driver.Close();
            Driver.Quit();
        }
    }
}
