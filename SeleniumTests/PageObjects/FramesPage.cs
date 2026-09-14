using OpenQA.Selenium;
using SeleniumTests.Core;

namespace SeleniumTests.PageObjects
{
    public class FramesPage : PageObject
    {
        public FramesPage(IWebDriver driver) : base(driver)
        {
            Frame = new FrameWithButtons(driver);
        }

        public readonly FrameWithButtons Frame; // one object for both outer and inner frames since they are identical in structure

        public class FrameWithButtons : PageObject
        {
            public FrameWithButtons(IWebDriver driver) : base(driver)
            {
            }

            public IWebElement EditBtn => Context.GetElement(By.CssSelector("button[data-action='edit']"));
            public IWebElement SubmitBtn => Context.GetElement(By.CssSelector("button[onclick*='Submit']"));
            public IWebElement ClickMeBtn => Context.GetElement(By.CssSelector("button[name='my-button']"));
            public IWebElement PrimaryBtn => Context.GetElement(By.CssSelector("button.btn-class"));
            public IWebElement Result => Context.GetElement(By.Id("result"));
        }
    }
}
