using Microsoft.Playwright;

namespace PlayWrightTests.PageObjects.UiTestingPlayground
{
    public class VerifyTextPage : BasePage
    {
        public VerifyTextPage(IPage page) : base(page) { }

        public ILocator TextElementHello => Page.Locator("//span[normalize-space(.)='Hello UserName!']");
        public ILocator TextElementWelcome => Page.Locator("//span[normalize-space(.)='Welcome UserName!']");

        public ILocator TextElementHelloByText => Page.GetByText("Hello UserName!");
        public ILocator TextElementWelcomeByText => Page.GetByText("Welcome UserName!", new() { Exact = true });
    }
}
