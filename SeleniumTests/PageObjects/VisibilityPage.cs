using OpenQA.Selenium;
using SeleniumTests.Core;

namespace SeleniumTests.PageObjects
{
    public class VisibilityPage : PageObject
    {
        public VisibilityPage(ISearchContext search) : base(search)
        {
        }

        private readonly By HideBtnLocator = By.Id("hideButton");
        private readonly By RemovedBtnLocator = By.Id("removedButton");
        private readonly By ZeroWidthBtnLocator = By.Id("zeroWidthButton");
        private readonly By OverlappedBtnLocator = By.Id("overlappedButton");
        private readonly By TransparentBtnLocator = By.Id("transparentButton");
        private readonly By InvisibleBtnLocator = By.Id("invisibleButton");
        private readonly By NotDisplayedBtnLocator = By.Id("notdisplayedButton");
        private readonly By OffScreenBtnLocator = By.Id("offscreenButton");

        public IWebElement HideBtn => Context.GetElement(HideBtnLocator);
        public IWebElement RemovedBtn => Context.GetElement(RemovedBtnLocator);
        public IWebElement ZeroWidthBtn => Context.GetElement(ZeroWidthBtnLocator);
        public IWebElement OverlappedBtn => Context.GetElement(OverlappedBtnLocator);
        public IWebElement TransparentBtn => Context.GetElement(TransparentBtnLocator);
        public IWebElement InvisibleBtn => Context.GetElement(InvisibleBtnLocator);
        public IWebElement NotDisplayedBtn => Context.GetElement(NotDisplayedBtnLocator);
        public IWebElement OffScreenBtn => Context.GetElement(OffScreenBtnLocator);

    }
}
