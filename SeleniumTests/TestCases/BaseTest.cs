using NUnit.Framework;
using SeleniumTests.Core;
using SeleniumTests.PageObjects;

namespace SeleniumTests.TestCases
{
    public abstract class BaseTest
    {
        private readonly Selenium selenium = new Selenium();

        [OneTimeTearDown]
        public virtual void OneTimeTearDown()
        {
            selenium.CloseBrowser();
        }

        protected T? GetPage<T>() where T : PageObject => Activator.CreateInstance(typeof(T), selenium.Driver) as T;

        protected JsExecutor JsExecutor => new JsExecutor(selenium.Driver);
        protected ActionsHelper Action => new ActionsHelper(selenium.Driver);
        protected FrameHelper Frame => new FrameHelper(selenium.Driver);
    }
}
