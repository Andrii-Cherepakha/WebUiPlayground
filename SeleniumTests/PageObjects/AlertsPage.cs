using OpenQA.Selenium;
using SeleniumTests.Core;

namespace SeleniumTests.PageObjects
{
    public class AlertsPage : PageObject
    {
        public AlertsPage(IWebDriver driver) : base(driver) { }

        public IWebElement AlertButton => Context.GetElement(By.Id("alertButton"));
        public IWebElement ConfirmButton => Context.GetElement(By.Id("confirmButton"));
        public IWebElement PromptButton => Context.GetElement(By.Id("promptButton"));
    }
}
