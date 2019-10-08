using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace SampleFramework1
{
    internal class SampleApplicationPage : BaseSampeApplicationPage
    {

        public SampleApplicationPage(IWebDriver driver): base(driver)
        {
        }

        public bool IsVisible
        {
            get
            {
                return Driver.Title.Contains(PageTitle);
            }
             internal set{ }
        }
        //Page Title
        private string PageTitle => "Sample Application Lifecycle - Sprint 2 | Ultimate QA";
        //First Name Field
        public IWebElement FirstNameField => Driver.FindElement(By.Name("firstname"));
        //Submit button
        public IWebElement SubmitButton => Driver.FindElement(By.XPath("//*[@type='submit']"));
        //Last Name Field
        public IWebElement LastNameField => Driver.FindElement(By.Name("lastname"));
        

        public void GoTo()
        {
           Driver.Navigate().GoToUrl("https://www.ultimateqa.com/sample-application-lifecycle-sprint-2/");
           Assert.IsTrue(IsVisible, 
               $"Sample application page is not visible. Expected => {PageTitle}." +
               $"Actual =>{Driver.Title}");
        }

        public UltimateQAHomePage FillOutFormAndSubmit(TestUser user)
        {
            FirstNameField.SendKeys(user.FirstName);
            LastNameField.SendKeys(user.LastName);
            SubmitButton.Click();
          return new UltimateQAHomePage(Driver);
        }

        public UltimateQAHomePage FillOutLastName(string value)
        {
           LastNameField.SendKeys(value);
           return new UltimateQAHomePage(Driver);
        }
    }
}