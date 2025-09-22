
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;

namespace SeleniumTests.Core
{
    public sealed class Selenium
    {
        private IWebDriver driver;

        public IWebDriver Driver
        {
            get
            {
                if (driver is null)
                    InitDriver();

                return driver;
            }
        }

        public bool Initialized => driver != null;

        public void CloseBrowser()
        {
            if (driver is null)
                return;

            driver.Quit();
            driver.Dispose();
            driver = null;
        }

        private void InitDriver() => driver = new ChromeDriver(AppDomain.CurrentDomain.BaseDirectory, GetChromeOptions());

        private static ChromeOptions GetChromeOptions()
        {
            ChromeOptions options = new ChromeOptions();

            options.AddArgument("--start-maximized");
            options.AddArgument("--disable-extensions");
            options.AddArgument("--disable-infobars");
            options.AddArgument("--no-sandbox");

            return options;
        }

    }
}
