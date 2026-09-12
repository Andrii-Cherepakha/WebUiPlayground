using OpenQA.Selenium;

namespace SeleniumTests.PageObjects
{
    public class HomePage : PageObject
    {
        public HomePage(IWebDriver driver) : base(driver)
        {
        }

        public void Navigate()
        {
            Driver?.Navigate().GoToUrl("http://uitestingplayground.com/"); // TODO move to config
        }

        public void OpenSection(string name)
        {
            By section = By.XPath($"//a[text()='{name}']");
            Context.FindElement(section).Click();
        }
    }
}
