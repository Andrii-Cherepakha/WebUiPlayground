using Microsoft.Playwright.NUnit;
using NUnit.Framework;

namespace PlayWrightTests.TestCases.CommitQuality
{
    [Parallelizable(ParallelScope.Self)]
    [TestFixture]
    public class CommitQuality : PageTest
    {
        [Test]
        public async Task RandomPopup()
        {
            await Page.AddLocatorHandlerAsync(Page.GetByText("Random Popup"),
                async () =>
                {
                    await Page.GetByText("Close").ClickAsync();
                });

            string url = "https://commitquality.com/practice-random-popup";

            await Page.GotoAsync(url);
            await Task.Delay(6000);
            await Page.GetByTestId("accordion-1").ClickAsync(new() { Timeout = 2000 });
        }
    }
}
