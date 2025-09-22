using OpenQA.Selenium;

namespace SeleniumTests.PageObjects
{
    public class HomePage : PageObject
    {
        public HomePage(ISearchContext search) : base(search)
        {
        }

        public void OpenSection(string name)
        {
            By section = By.XPath($"//a[text()='{name}']");
            Context.FindElement(section).Click();
        }
    }
}
