using Microsoft.Playwright;

namespace PlayWrightTests.PageObjects.UiTestingPlayground
{
    public class AlertsPage : BasePage
    {
        public AlertsPage(IPage page) : base(page) { }

        public ILocator AlertButton => Page.Locator("#alertButton");
        public ILocator ConfirmButton => Page.Locator("#confirmButton");
        public ILocator PromptButton => Page.Locator("#promptButton");
    }
}
