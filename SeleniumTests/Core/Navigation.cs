using OpenQA.Selenium;

namespace SeleniumTests.Core
{
    internal class Navigation
    {
        private readonly IWebDriver driver;
        private readonly Uri baseUrl = new Uri("http://uitestingplayground.com/"); // TODO move to config

        public Navigation(IWebDriver driver) => this.driver = driver;

        public void OpenPage(Uri url) => driver.Navigate().GoToUrl(url);

        public void OpenBasePage() => OpenPage(baseUrl);
    }
}
