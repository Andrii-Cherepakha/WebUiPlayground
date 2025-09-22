using Microsoft.Playwright;

namespace PlayWrightTests.PageObjects.UiTestingPlayground
{
    public class TextInputPage : BasePage
    {
        public TextInputPage(IPage page) : base(page)
        {
        }

        public ILocator Input => Page.Locator("id=newButtonName");
        public ILocator UpdatingButton => Page.Locator("id=updatingButton");
    }
}
