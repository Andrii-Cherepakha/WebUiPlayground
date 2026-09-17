using OpenQA.Selenium;
using SeleniumTests.Core;

namespace SeleniumTests.PageObjects
{
    public class SelectorsPage : PageObject
    {
        public SelectorsPage(IWebDriver driver) : base(driver)
        {
        }

        // Expose the ability to find an element to use it directly in the test
        public IWebElement GetElement(By by) => Context.GetElement(by);
    }
}
