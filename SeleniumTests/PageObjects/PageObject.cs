using OpenQA.Selenium;

namespace SeleniumTests.PageObjects
{
    public abstract class PageObject
    {
        protected readonly ISearchContext Context;

        protected PageObject(ISearchContext search) => Context = search;
    }
}
