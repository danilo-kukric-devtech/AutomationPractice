using OpenQA.Selenium;

namespace SampleFramework1
{
    public class BaseSampeApplicationPage
    {
        protected IWebDriver Driver { get; set; }

        public BaseSampeApplicationPage(IWebDriver driver)
        {
            Driver = driver;
        }


    }
}