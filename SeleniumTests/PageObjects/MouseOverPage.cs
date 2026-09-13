using OpenQA.Selenium;
using SeleniumTests.Core;

namespace SeleniumTests.PageObjects
{
    public class MouseOverPage : PageObject
    {
        public MouseOverPage(IWebDriver driver) : base(driver)
        {
        }
        public IWebElement ClickMeBtn => Context.GetElement(By.LinkText("Click me"));
        public IWebElement LinkBtn => Context.GetElement(By.LinkText("Link Button"));
        public IWebElement ClickMeCount => Context.GetElement(By.Id("clickCount"));
        public IWebElement LinkCount => Context.GetElement(By.Id("clickButtonCount"));

    }
}
