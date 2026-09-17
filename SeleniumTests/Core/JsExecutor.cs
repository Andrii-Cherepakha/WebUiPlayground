using OpenQA.Selenium;

namespace SeleniumTests.Core
{
    public class JsExecutor
    {
        private readonly IJavaScriptExecutor executor;

        public JsExecutor(IWebDriver driver)
        {
            executor = (IJavaScriptExecutor)driver;
        }

        public void ScrollToElement(IWebElement element)
        {
            executor.ExecuteScript("arguments[0].scrollIntoView(true);", element);
        }

        public ShadowRoot GetShadowRoot(IWebElement shadowHost)
        {
            return (ShadowRoot)executor.ExecuteScript("return arguments[0].shadowRoot", shadowHost);
        }
    }
}
