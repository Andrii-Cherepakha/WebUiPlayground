using OpenQA.Selenium;
using SeleniumTests.Core;

namespace SeleniumTests.PageObjects
{
    public class VisibilityPage : PageObject
    {
        public VisibilityPage(IWebDriver driver) : base(driver)
        {
        }


        public IWebElement HideBtn => Context.GetElement(By.Id("hideButton"));
        public IWebElement RemovedBtn => Context.GetElement(By.Id("removedButton"));
        public IWebElement ZeroWidthBtn => Context.GetElement(By.Id("zeroWidthButton"));
        public IWebElement OverlappedBtn => Context.GetElement(By.Id("overlappedButton"));
        public IWebElement TransparentBtn => Context.GetElement(By.Id("transparentButton"));
        public IWebElement InvisibleBtn => Context.GetElement(By.Id("invisibleButton"));
        public IWebElement NotDisplayedBtn => Context.GetElement(By.Id("notdisplayedButton"));
        public IWebElement OffScreenBtn => Context.GetElement(By.Id("offscreenButton"));

    }
}
