using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumTests.Core;

namespace SeleniumTests.PageObjects
{
    public class SelectPage : PageObject
    {
        public SelectPage(IWebDriver driver) : base(driver)
        {
        }

        // Select elements
        public SelectElement Language => GetSelectElement("selectLanguage");
        public SelectElement City => GetSelectElement("selectCity");
        public SelectElement ProductVersion => GetSelectElement("selectProduct");
        public SelectElement Colors => GetSelectElement("selectColors");
        public SelectElement Fruits => GetSelectElement("selectFruits");

        // Status labels
        public IWebElement StatusLanguage => Context.GetElement(By.Id("statusLanguage"));
        public IWebElement StatusCity => Context.GetElement(By.Id("statusCity"));
        public IWebElement StatusProduct => Context.GetElement(By.Id("statusProduct"));
        public IWebElement StatusColors => Context.GetElement(By.Id("statusColors"));
        public IWebElement StatusFruits => Context.GetElement(By.Id("statusFruits"));

        private SelectElement GetSelectElement(string id)
        {
            var element = Context.GetElement(By.Id(id));
            return new SelectElement(element);
        }
    }
}
