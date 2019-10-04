using OpenQA.Selenium;

namespace SampleFramework1
{
    public class UltimateQAHomePage : BaseSampeApplicationPage
    {
        public IWebElement Logo => Driver.FindElement(By.Id("logo"));
        public UltimateQAHomePage(IWebDriver driver) : base(driver)
        {
        }

        public bool IsVisible => Logo.Displayed;

      
    }
}