using Microsoft.Playwright;

namespace PlayWrightTests.PageObjects.UiTestingPlayground
{
    public class VisibilityPage : BasePage
    {
        public VisibilityPage(IPage page) : base(page)
        {
        }

        public ILocator HideBtn => GetButton("Hide"); //Page.Locator("id=hideButton");
        public ILocator RemovedBtn => GetButton("Removed"); //Page.Locator("id=removedButton");
        public ILocator ZeroWidthBtn => GetButton("Zero Width"); //Page.Locator("id=zeroWidthButton");
        public ILocator OverlappedBtn => GetButton("Overlapped"); //Page.Locator("id=overlappedButton");
        public ILocator TransparentBtn => GetButton("Opacity 0"); //Page.Locator("id=transparentButton");
        public ILocator InvisibleBtn => GetButton("Visibility Hidden"); //Page.Locator("id=invisibleButton");
        public ILocator NotDisplayedBtn => GetButton("Display None"); //Page.Locator("id=notdisplayedButton");
        public ILocator OffScreenBtn => GetButton("Offscreen"); //Page.Locator("id=offscreenButton");

    }
}
