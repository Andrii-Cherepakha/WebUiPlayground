using OpenQA.Selenium;
using SeleniumTests.Core;

namespace SeleniumTests.PageObjects
{
    public class NonBreakingSpacePage : PageObject
    {
        public NonBreakingSpacePage(IWebDriver driver) : base(driver)
        {
        }

        public IWebElement BtnNbsp => Context.GetElement(By.XPath("//button[text()='My Button']")); // <-- &nbsp; special character in the text
        public IWebElement BtnNormalized => Context.GetElement(By.XPath("//button[normalize-space(.)='My Button']"));
    }
}
