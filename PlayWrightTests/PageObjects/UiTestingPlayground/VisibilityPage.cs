using Microsoft.Playwright;

namespace PlayWrightTests.PageObjects.UiTestingPlayground
{
    public class VisibilityPage : BasePage
    {
        public VisibilityPage(IPage page) : base(page)
        {
        }

        public ILocator HideBtn => Page.Locator("#hideButton");
        public ILocator RemovedBtn => Page.Locator("#removedButton");
        public ILocator ZeroWidthBtn => Page.Locator("#zeroWidthButton");
        public ILocator OverlappedBtn => Page.Locator("#overlappedButton");
        public ILocator TransparentBtn => Page.Locator("#transparentButton");
        public ILocator InvisibleBtn => Page.Locator("#invisibleButton");
        public ILocator NotDisplayedBtn => Page.Locator("#notdisplayedButton");
        public ILocator OffScreenBtn => Page.Locator("#offscreenButton");

    }
}
