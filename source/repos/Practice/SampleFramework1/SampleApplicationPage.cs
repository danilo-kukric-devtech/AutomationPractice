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
                return Driver.Title.Contains("Sample Application Lifecycle - Sprint 1 - Ultimate QA");
            }
             internal set{ }
        }

        public IWebElement FirstNameField => Driver.FindElement(By.Name("firstname"));

        public IWebElement SubmitButton => Driver.FindElement(By.Id("submitForm"));

        public void GoTo()
        {
           Driver.Navigate().GoToUrl("https://www.ultimateqa.com/sample-application-lifecycle-sprint-1/");
        }

        public UltimateQAHomePage FillOutFormAndSubmit(string value)
        {
            FirstNameField.SendKeys(value);
            SubmitButton.Click();
            return new UltimateQAHomePage(Driver);
        }
    }
}