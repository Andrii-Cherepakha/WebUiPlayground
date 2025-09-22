using Microsoft.Playwright;
using NUnit.Framework;
using PlayWrightTests.PageObjects.UiTestingPlayground;

namespace PlayWrightTests.TestCases.UiTestingPlayground
{
    [Parallelizable(ParallelScope.Self)]
    [TestFixture]
    public class SomeTest : BaseTest
    {
        [Test]
        public async Task TextInputTest()
        {
            string? text = "I'm learning Playwright.";

            var environment = Environment.GetEnvironmentVariable("ENVIRONMENT");
            Console.WriteLine(environment);

            var homePage = GetPage<HomePage>();

            await homePage.OpenAsync();
            await homePage.OpenSectionAsync("Text Input");

            await Expect(Page).ToHaveTitleAsync("Text Input");

            var textInputPage = GetPage<TextInputPage>();

            await textInputPage.Input.FillAsync(text);
            await textInputPage.UpdatingButton.ClickAsync();

            await Expect(textInputPage.UpdatingButton).ToHaveTextAsync(text);
            await Expect(textInputPage.UpdatingButton).Not.ToHaveTextAsync("Some other text.");
        }

        [Test]
        public async Task VisibilityTest()
        {
            var homePage = GetPage<HomePage>();
            await homePage.OpenAsync();
            await homePage.OpenSectionAsync("Visibility");

            var visibilityPage = GetPage<VisibilityPage>();

            await visibilityPage.RemovedBtn.WaitForAsync(new LocatorWaitForOptions {  State = WaitForSelectorState.Visible});

            Console.WriteLine($"RemovedBtn      is visible: {await visibilityPage.RemovedBtn.IsVisibleAsync()}");
            Console.WriteLine($"ZeroWidthBtn    is visible: {await visibilityPage.ZeroWidthBtn.IsVisibleAsync()}");
            Console.WriteLine($"OverlappedBtn   is visible: {await visibilityPage.OverlappedBtn.IsVisibleAsync()}");
            Console.WriteLine($"TransparentBtn  is visible: {await visibilityPage.TransparentBtn.IsVisibleAsync()}");
            Console.WriteLine($"InvisibleBtn    is visible: {await visibilityPage.InvisibleBtn.IsVisibleAsync()}");
            Console.WriteLine($"NotDisplayedBtn is visible: {await visibilityPage.NotDisplayedBtn.IsVisibleAsync()}");
            Console.WriteLine($"OffScreenBtn    is visible: {await visibilityPage.OffScreenBtn.IsVisibleAsync()}");

            await visibilityPage.HideBtn.ClickAsync();

            Console.WriteLine("\n AFTER HIDE: ");

            Console.WriteLine($"RemovedBtn      is visible: {await visibilityPage.RemovedBtn.IsVisibleAsync()}");
            Console.WriteLine($"ZeroWidthBtn    is visible: {await visibilityPage.ZeroWidthBtn.IsVisibleAsync()}");
            Console.WriteLine($"OverlappedBtn   is visible: {await visibilityPage.OverlappedBtn.IsVisibleAsync()}");
            Console.WriteLine($"TransparentBtn  is visible: {await visibilityPage.TransparentBtn.IsVisibleAsync()}");
            Console.WriteLine($"InvisibleBtn    is visible: {await visibilityPage.InvisibleBtn.IsVisibleAsync()}");
            Console.WriteLine($"NotDisplayedBtn is visible: {await visibilityPage.NotDisplayedBtn.IsVisibleAsync()}");
            Console.WriteLine($"OffScreenBtn    is visible: {await visibilityPage.OffScreenBtn.IsVisibleAsync()}");
        }

        [Test]
        public async Task FileUpload()
        {
            await Page.GotoAsync("http://uitestingplayground.com/upload");

            await Task.Delay(5000);

            var fileChooserTask = Page.WaitForFileChooserAsync();
            await Page.FrameLocator("//*[@src='/static/upload.html']").Locator("label.browse-btn").ClickAsync();
            var fileChooser = await fileChooserTask;
            await fileChooser.SetFilesAsync(@"e:\temp\file.txt");


            await Task.Delay(5000);
        }
    }
}
