using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace SampleFramework1
{
    internal class SampleAppPage : BaseSampeApplicationPage
    {

        public SampleAppPage(IWebDriver driver): base(driver)
        {
        }

        //Page Title
        private string PageTitleSprint3 => "Sample Application Lifecycle - Sprint 3 | Ultimate QA";
        //First Name Field
        public IWebElement FirstNameField => Driver.FindElement(By.Name("firstname"));
        //Submit button
        public IWebElement SubmitButton => Driver.FindElement(By.XPath("//*[@type='submit']"));
        //Last Name Field
        public IWebElement LastNameField => Driver.FindElement(By.Name("lastname"));
        //Female gender radio button
        public IWebElement FemaleGenderRadioButton => Driver.FindElement(By.XPath("//input[@value='female']"));
        //Other radio button
        public IWebElement OtherGenderRadioButton => Driver.FindElement(By.XPath("//input[@value='other']"));
        public IWebElement FemaleGenderRadioButtonForEmergencyContact => Driver.FindElement(By.Id("radio2-f"));
        public IWebElement FirstNameFieldForEmergencyContact => Driver.FindElement(By.Id("f2"));
        public IWebElement LastNameFieldForEmergencycontact => Driver.FindElement(By.Id("l2"));

        public bool IsVisible
        {
            get
            {
                return Driver.Title.Contains(PageTitle);
            }
             internal set{ }
        }
        public bool IsVisibleSprint3Page
        {

            get
            {
                return Driver.Title.Contains(PageTitleSprint3);

            }
            internal set { }
        }
        //Page Title
        private string PageTitle => "Sample Application Lifecycle - Sprint 2 | Ultimate QA";

        internal void FillOutEmergencyContactForm(TestUser emergencyContactUser)
        {
            SetGenderForEmergencyContact(emergencyContactUser);
            FirstNameFieldForEmergencyContact.SendKeys(emergencyContactUser.FirstName);
            LastNameFieldForEmergencycontact.SendKeys(emergencyContactUser.LastName);
        }

        private void SetGenderForEmergencyContact(TestUser user)
        {
            switch (user.GenderType)
            {
                case Gender.Male:
                    break;
                case Gender.Female:
                    FemaleGenderRadioButtonForEmergencyContact.Click();
                    break;
                case Gender.Other:
                    OtherGenderRadioButton.Click();
                    break;
                default:
                    break;
            }
        }
        public void GoTo()
        {
           Driver.Navigate().GoToUrl("https://www.ultimateqa.com/sample-application-lifecycle-sprint-3/");
           Assert.IsTrue(IsVisibleSprint3Page, 
               $"Sample application page is not visible. Expected => {PageTitleSprint3}." +
               $"Actual =>{Driver.Title}");
        }

        public UltimateQAHomePage FillOutFormAndSubmit(TestUser user)
        {
            SetGender(user);
            FirstNameField.SendKeys(user.FirstName);
            LastNameField.SendKeys(user.LastName);
            SubmitButton.Click();
          return new UltimateQAHomePage(Driver);
        }
        private void SetGender(TestUser user)
        {
            switch (user.GenderType)
            {
                case Gender.Male:
                    break;
                case Gender.Female:
                    FemaleGenderRadioButton.Click();
                    break;
                case Gender.Other:
                    OtherGenderRadioButton.Click();
                    break;
                default:
                    break;
            }
        }
        public UltimateQAHomePage FillOutLastName(string value)
        {
           LastNameField.SendKeys(value);
           return new UltimateQAHomePage(Driver);
        }
    }
}