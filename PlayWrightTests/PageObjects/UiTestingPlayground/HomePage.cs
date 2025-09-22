using Microsoft.Playwright;

namespace PlayWrightTests.PageObjects.UiTestingPlayground
{
    public class HomePage : BasePage
    {
        public HomePage(IPage page) : base(page)
        {
        }

        public async Task OpenAsync()
        {
            await Page.GotoAsync("http://uitestingplayground.com/");
        }

        public async Task OpenSectionAsync(string section)
        {
            await Page.GetByRole(AriaRole.Link).Filter(new() { HasText = section }).ClickAsync();
        }

    }
}
