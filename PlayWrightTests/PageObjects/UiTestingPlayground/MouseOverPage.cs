using Microsoft.Playwright;

namespace PlayWrightTests.PageObjects.UiTestingPlayground
{
    public class MouseOverPage : BasePage
    {
        public MouseOverPage(IPage page) : base(page) { }

        public ILocator ClickMeBtn => Page.GetByText("Click me");
        public ILocator LinkBtn => Page.GetByText("Link Button");
        public ILocator ClickMeCount => Page.Locator("#clickCount");
        public ILocator LinkCount => Page.Locator("#clickButtonCount");
    }
}
