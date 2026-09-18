using OpenQA.Selenium;
using SeleniumTests.Core;

namespace SeleniumTests.PageObjects
{
    public class VerifyTextPage : PageObject
    {
        public VerifyTextPage(IWebDriver driver) : base(driver)
        {
        }

        public IWebElement TextElement => Context.GetElement(By.XPath("//p[normalize-space(.)='Hello UserName!']"));
    }
}
