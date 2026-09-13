using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;

namespace SeleniumTests.Core
{
    public class ActionsHelper
    {
        private readonly IWebDriver driver;

        public ActionsHelper(IWebDriver driver)
        {
            this.driver = driver;
        }

        public void MoveToElement(IWebElement element)
        {
            var actions = new Actions(driver);
            actions.MoveToElement(element).Perform();
        }

        public void ScrollToElement(IWebElement element)
        {
            var actions = new Actions(driver);
            actions.ScrollToElement(element).Perform();
        }
    }
}
