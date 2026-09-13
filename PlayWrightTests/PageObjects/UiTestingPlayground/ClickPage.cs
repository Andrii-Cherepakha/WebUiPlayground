using Microsoft.Playwright;

namespace PlayWrightTests.PageObjects.UiTestingPlayground
{
    public class ClickPage : BasePage
    {
        public ClickPage(IPage page) : base(page) { }
        public ILocator Btn => Page.Locator("#badButton");
    }
}
