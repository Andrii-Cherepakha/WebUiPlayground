using Microsoft.Playwright;

namespace PlayWrightTests.PageObjects.UiTestingPlayground
{
    public class AjaxDataPage : BasePage
    {
        public AjaxDataPage(IPage page) : base(page) { }

        public ILocator AjaxButton => Page.Locator("#ajaxButton");

        private const string AjaxDataUrl = "**/ajaxdata";

        public async Task WaitForSpinner()
        {
            await Page.Locator("#spinner").WaitForAsync(new() { State = WaitForSelectorState.Hidden });
        }

        public async Task<IEnumerable<string>> GetContent()
        {
            var items = await Page.Locator("#content p").AllAsync();
            var response = new List<string>();
            foreach (var item in items)
            {
                var text = await item.InnerTextAsync();
                response.Add(text);
            }
            return response;
        }

        public async Task MockResponse(string text)
        {
            await Page.RouteAsync(AjaxDataUrl, async route =>
            {
                await route.FulfillAsync(new()
                {
                    Status = 200,
                    ContentType = "text/plain",
                    Body = text
                });
            });
        }

        public async Task UnmockResponse()
        {
            await Page.UnrouteAsync(AjaxDataUrl);
        }
    }
}
