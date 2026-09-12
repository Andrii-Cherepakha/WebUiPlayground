using OpenQA.Selenium;

namespace SeleniumTests.PageObjects
{
    public abstract class PageObject
    {
        protected readonly IWebDriver? Driver;
        protected readonly ISearchContext Context;

        protected PageObject(IWebDriver driver)
        { 
            Driver = driver;
            Context = driver;
        }

        protected PageObject(ISearchContext search) => Context = search;
    }
}
