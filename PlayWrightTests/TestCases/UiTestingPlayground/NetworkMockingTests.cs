using NUnit.Framework;
using PlayWrightTests.PageObjects.UiTestingPlayground;

namespace PlayWrightTests.TestCases.UiTestingPlayground
{
    [Parallelizable(ParallelScope.Self)]
    [TestFixture]
    public class NetworkMockingTests : BaseTest
    {
        [Test]
        public async Task AjaxDataMocking()
        {
            var homePage = GetPage<HomePage>();
            await homePage.OpenAsync();

            await homePage.OpenSectionAsync("AJAX Data");

            var ajaxDataPage = GetPage<AjaxDataPage>();

            await ajaxDataPage.AjaxButton.ClickAsync();
            await ajaxDataPage.WaitForSpinner();
            Assert.That(await ajaxDataPage.GetContent(), Does.Contain("Data loaded with AJAX get request."));

            await ajaxDataPage.MockResponse("Mocked response text");

            await ajaxDataPage.AjaxButton.ClickAsync();
            await ajaxDataPage.WaitForSpinner();
            Assert.That(await ajaxDataPage.GetContent(), Does.Contain("Mocked response text"));

            await ajaxDataPage.UnmockResponse();

            await ajaxDataPage.AjaxButton.ClickAsync();
            await ajaxDataPage.WaitForSpinner();
            Assert.That(await ajaxDataPage.GetContent(), Has.Exactly(2).EqualTo("Data loaded with AJAX get request."));
            Assert.That(await ajaxDataPage.GetContent(), Has.Exactly(1).EqualTo("Mocked response text"));
        }
    }
}
