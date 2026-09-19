using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace SeleniumTests.Core
{
    public class AlertsHelper
    {
        private readonly IWebDriver driver;

        public AlertsHelper(IWebDriver driver)
        {
            this.driver = driver;
        }

        public IAlert SwitchToAlert()
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            return wait.Until(d =>
            {
                try
                {
                    return d.SwitchTo().Alert();
                }
                catch (NoAlertPresentException)
                {
                    return null;
                }
            });
        }
}
}
