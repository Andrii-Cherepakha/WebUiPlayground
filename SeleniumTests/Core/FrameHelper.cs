using OpenQA.Selenium;

namespace SeleniumTests.Core
{
    public class FrameHelper
    {
        private readonly IWebDriver driver;

        public FrameHelper(IWebDriver driver)
        {
            this.driver = driver;
        }

        public void SwitchToFrameContent(string name)
        {
            driver.SwitchTo().Frame(name);
        }

        public void SwitchToDefaultContext()
        {
            driver.SwitchTo().DefaultContent();
        }
    }
}
