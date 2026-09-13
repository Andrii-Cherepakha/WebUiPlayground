using OpenQA.Selenium;
using SeleniumTests.Core;

namespace SeleniumTests.PageObjects
{
    public class OverlappedElementPage : PageObject
    {
        public OverlappedElementPage(IWebDriver driver) : base(driver)
        {
        }

        public IWebElement IdTextBox => Context.GetElement(By.Id("id"));
        public IWebElement NameTextBox => Context.GetElement(By.Id("name"));
        public IWebElement SubjectTextBox => Context.GetElement(By.Id("subject"));        
    }
}
