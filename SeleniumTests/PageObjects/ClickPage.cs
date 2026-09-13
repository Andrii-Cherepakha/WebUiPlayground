using OpenQA.Selenium;
using SeleniumTests.Core;

namespace SeleniumTests.PageObjects
{
    public class ClickPage : PageObject
    {
        public ClickPage(IWebDriver driver) : base(driver)
        {
        }

        public IWebElement Btn => Context.GetElement(By.Id("badButton"));    
    }
}
