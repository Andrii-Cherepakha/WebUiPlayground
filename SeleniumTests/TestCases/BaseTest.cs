using NUnit.Framework;
using SeleniumTests.Core;
using SeleniumTests.PageObjects;

namespace SeleniumTests.TestCases
{
    public abstract class BaseTest
    {
        private protected Navigation Navigation => navigation ?? (navigation = new Navigation(selenium.Driver));

        private Navigation navigation;
        private readonly Selenium selenium = new Selenium();

        [OneTimeTearDown]
        public virtual void OneTimeTearDown()
        {
            selenium.CloseBrowser();
        }

        protected T? GetPage<T>() where T : PageObject => Activator.CreateInstance(typeof(T), selenium.Driver) as T;
    }
}
