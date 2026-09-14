using NUnit.Framework;
using PlayWrightTests.PageObjects.UiTestingPlayground;

namespace PlayWrightTests.TestCases.UiTestingPlayground
{
    [Parallelizable(ParallelScope.Self)]
    [TestFixture]
    public class ElementInteractionTest : BaseTest
    {
        [Test]
        public async Task VisibilityTest()
        {
            var homePage = GetPage<HomePage>();
            await homePage.OpenAsync();

            await homePage.OpenSectionAsync("Visibility");

            var visibilityPage = GetPage<VisibilityPage>();

            Console.WriteLine("\nBEFORE HIDE: ");

            Console.WriteLine($"Removed           is visible: {await visibilityPage.RemovedBtn.IsVisibleAsync()}");
            Console.WriteLine($"Zero Width        is visible: {await visibilityPage.ZeroWidthBtn.IsVisibleAsync()}");
            Console.WriteLine($"Overlapped        is visible: {await visibilityPage.OverlappedBtn.IsVisibleAsync()}");
            Console.WriteLine($"Opacity 0         is visible: {await visibilityPage.TransparentBtn.IsVisibleAsync()}");
            Console.WriteLine($"Visibility Hidden is visible: {await visibilityPage.InvisibleBtn.IsVisibleAsync()}");
            Console.WriteLine($"Not Displayed     is visible: {await visibilityPage.NotDisplayedBtn.IsVisibleAsync()}");
            Console.WriteLine($"Off Screen        is visible: {await visibilityPage.OffScreenBtn.IsVisibleAsync()}");

            await visibilityPage.HideBtn.ClickAsync();

            Console.WriteLine("\nAFTER HIDE: ");

            Console.WriteLine($"Removed           is visible: {await visibilityPage.RemovedBtn.IsVisibleAsync()}");
            Console.WriteLine($"Zero Width        is visible: {await visibilityPage.ZeroWidthBtn.IsVisibleAsync()}");
            Console.WriteLine($"Overlapped        is visible: {await visibilityPage.OverlappedBtn.IsVisibleAsync()}");
            Console.WriteLine($"Opacity 0         is visible: {await visibilityPage.TransparentBtn.IsVisibleAsync()}");
            Console.WriteLine($"Visibility Hidden is visible: {await visibilityPage.InvisibleBtn.IsVisibleAsync()}");
            Console.WriteLine($"Not Displayed     is visible: {await visibilityPage.NotDisplayedBtn.IsVisibleAsync()}");
            Console.WriteLine($"Off Screen        is visible: {await visibilityPage.OffScreenBtn.IsVisibleAsync()}");
        }

        [Test]
        public async Task InputTextIntoTheOverlappedElement()
        {
            var homePage = GetPage<HomePage>();
            await homePage.OpenAsync();

            await homePage.OpenSectionAsync("Overlapped Element");

            var overlappedElementPage = GetPage<OverlappedElementPage>();

            const string ID = "ID-001";
            const string NAME = "John Doe";
            const string SUBJECT = "Test Subject";

            await overlappedElementPage.IdTextBox.FillAsync(ID); // no overlapped, no scroll needed

            await overlappedElementPage.NameTextBox.EvaluateAsync("element => element.scrollIntoView(true);");
            await overlappedElementPage.NameTextBox.FillAsync(NAME); // partialy overlapped, scroll needed

            await overlappedElementPage.SubjectTextBox.FillAsync(SUBJECT); // completly overlapped, no scroll needed

            Assert.That(overlappedElementPage.IdTextBox.InputValueAsync().Result, Is.EqualTo(ID));
            Assert.That(overlappedElementPage.NameTextBox.InputValueAsync().Result, Is.EqualTo(NAME));
            Assert.That(overlappedElementPage.SubjectTextBox.InputValueAsync().Result, Is.EqualTo(SUBJECT));
        }

        [Test]
        public async Task ClickTest()        
        {
            var homePage = GetPage<HomePage>();
            await homePage.OpenAsync();
            await homePage.OpenSectionAsync("Click");

            var clickPage = GetPage<ClickPage>();

            await clickPage.Btn.ClickAsync();

            var classAttribute = await clickPage.Btn.GetAttributeAsync("class");
            Assert.That(classAttribute, Does.Contain("btn-success"));

            await homePage.OpenAsync();
            await homePage.OpenSectionAsync("Scroll to Click");

            var scrollToClickPage = GetPage<ScrollToClickPage>();

            await scrollToClickPage.Btn1.ClickAsync();
            await scrollToClickPage.Btn2.ClickAsync();
            await scrollToClickPage.Btn3.ClickAsync();
            await scrollToClickPage.HoverRow4.HoverAsync();
            await scrollToClickPage.Btn4.ClickAsync();

            Assert.That(await scrollToClickPage.ProgressText.TextContentAsync(), Is.EqualTo("All buttons clicked!"));

            await homePage.OpenAsync();
            await homePage.OpenSectionAsync("Mouse Over");

            var mouseOverPage = GetPage<MouseOverPage>();

            await mouseOverPage.ClickMeBtn.ClickAsync();
            await mouseOverPage.LinkBtn.ClickAsync();

            Assert.That(await mouseOverPage.ClickMeCount.TextContentAsync(), Is.EqualTo("1"));
            Assert.That(await mouseOverPage.LinkCount.TextContentAsync(), Is.EqualTo("1"));
        }

        //[Test]
        //public async Task FileUpload()
        //{
        //    await Page.GotoAsync("http://uitestingplayground.com/upload");

        //    await Task.Delay(5000);

        //    var fileChooserTask = Page.WaitForFileChooserAsync();
        //    await Page.FrameLocator("//*[@src='/static/upload.html']").Locator("label.browse-btn").ClickAsync();
        //    var fileChooser = await fileChooserTask;
        //    await fileChooser.SetFilesAsync(@"d:\temp\file.txt");


        //    await Task.Delay(5000);
        //}
    }
}
