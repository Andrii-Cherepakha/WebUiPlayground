using NUnit.Framework;
using PlayWrightTests.PageObjects.UiTestingPlayground;

namespace PlayWrightTests.TestCases.UiTestingPlayground
{
    [Parallelizable(ParallelScope.Self)]
    [TestFixture]
    public class FrameTests : BaseTest
    {
        [Test]
        public async Task OuterFrameTest()
        {
            var homePage = GetPage<HomePage>();
            await homePage.OpenAsync();
            await homePage.OpenSectionAsync("Frames");

            var framesPage = GetPage<FramesPage>();

            await framesPage.OuterFrame.EditBtn.ClickAsync();
            Assert.That(await framesPage.OuterFrame.Result.InnerTextAsync(), Is.EqualTo("Button pressed: Edit"));

            await framesPage.OuterFrame.SubmitBtn.ClickAsync();
            Assert.That(await framesPage.OuterFrame.Result.InnerTextAsync(), Is.EqualTo("Button pressed: Submit"));

            await framesPage.OuterFrame.ClickMeBtn.ClickAsync();
            Assert.That(await framesPage.OuterFrame.Result.InnerTextAsync(), Is.EqualTo("Button pressed: Click me"));

            await framesPage.OuterFrame.PrimaryBtn.ClickAsync();
            Assert.That(await framesPage.OuterFrame.Result.InnerTextAsync(), Is.EqualTo("Button pressed: Primary"));
        }

        [Test]
        public async Task InnerFrameTest()
        {
            var homePage = GetPage<HomePage>();
            await homePage.OpenAsync();
            await homePage.OpenSectionAsync("Frames");

            var framesPage = GetPage<FramesPage>();

            await framesPage.InnerFrame.EditBtn.ClickAsync();
            Assert.That(await framesPage.InnerFrame.Result.InnerTextAsync(), Is.EqualTo("Button pressed: Edit"));

            await framesPage.InnerFrame.SubmitBtn.ClickAsync();
            Assert.That(await framesPage.InnerFrame.Result.InnerTextAsync(), Is.EqualTo("Button pressed: Submit"));

            await framesPage.InnerFrame.ClickMeBtn.ClickAsync();
            Assert.That(await framesPage.InnerFrame.Result.InnerTextAsync(), Is.EqualTo("Button pressed: Click me"));

            await framesPage.InnerFrame.PrimaryBtn.ClickAsync();
            Assert.That(await framesPage.InnerFrame.Result.InnerTextAsync(), Is.EqualTo("Button pressed: Primary"));
        }
    }
}
