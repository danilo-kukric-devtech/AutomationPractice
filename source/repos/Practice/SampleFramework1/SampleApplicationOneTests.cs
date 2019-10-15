using System;
using System.IO;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;
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
        internal SampleAppPage SampleAppPage { get; private set; }
        public TestUser TheTestUser { get; private set; }
        public TestUser EmergencyContactUser { get; set; }

        [TestMethod]
        [Description("Fillout form")]
        public void Test1()
        {
            
            SetGenderTypes(Gender.Female, Gender.Female);
            SampleAppPage.GoTo();
            SampleAppPage.FillOutEmergencyContactForm(EmergencyContactUser);
            var ultimateHomePage = SampleAppPage.FillOutFormAndSubmit(TheTestUser);
            AssertPageVisisble(ultimateHomePage);
        }
        [TestMethod]
        [Description("Negative test")]
        public void PretendTestNumber2()
        {
            TheTestUser.GenderType = Gender.Female;
            SampleAppPage.GoTo();
            SampleAppPage.FillOutEmergencyContactForm(EmergencyContactUser);
            var ultimateHomePage = SampleAppPage.FillOutFormAndSubmit(TheTestUser);
            AssertPageVisisbleVariation2(ultimateHomePage);
        }
        [TestMethod]
        [Description("Select other gender")]
        public void Test3()
        {
            SetGenderTypes(Gender.Other, Gender.Other);
            SampleAppPage.GoTo();
            SampleAppPage.FillOutEmergencyContactForm(EmergencyContactUser);
            var ultimateHomePage = SampleAppPage.FillOutFormAndSubmit(TheTestUser);
            AssertPageVisisble(ultimateHomePage);
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
            SampleAppPage = new SampleAppPage(Driver);
            TheTestUser = new TestUser();
            TheTestUser.FirstName = "Danilo";
            TheTestUser.LastName = "Kukric";
        }
        private static void AssertPageVisisble(UltimateQAHomePage ultimateHomePage)
        {
            Assert.IsTrue(ultimateHomePage.IsVisible, "UltimateQA home page is not visible");
        }
        private void AssertPageVisisbleVariation2(UltimateQAHomePage ultimateHomePage)
        {
            Assert.IsFalse(!ultimateHomePage.IsVisible, "UltimateQA home page is not visible");
        }
        private void SetGenderTypes(Gender primaryContact, Gender emergencyContact)
        {
            TheTestUser.GenderType = primaryContact;
            EmergencyContactUser.GenderType = emergencyContact;
        }
        [TestCleanup]
        public void CleanupAfterEveryTestMethod()
        {
            Driver.Close();
            Driver.Quit();
        }

    }
}
