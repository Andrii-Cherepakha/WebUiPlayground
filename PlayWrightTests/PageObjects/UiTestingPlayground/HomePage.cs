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
            await Page.GetByText(section, new() { Exact = true }).ClickAsync();
            await Page.WaitForLoadStateAsync(LoadState.DOMContentLoaded);
        }
    }
}
