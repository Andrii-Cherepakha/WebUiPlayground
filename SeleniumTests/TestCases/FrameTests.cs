using NUnit.Framework;
using SeleniumTests.PageObjects;

namespace SeleniumTests.TestCases
{
    public class FrameTests : BaseTest
    {
        [Test]
        public void OuterFrameTest()
        {
            var homePage = GetPage<HomePage>();
            homePage.Open();
            homePage.OpenSection("Frames");

            Frame.SwitchToFrameContent("frame-outer");

            FrameTest();

            Frame.SwitchToDefaultContext();
        }

        [Test]
        public void InnerFrameTest()
        {
            var homePage = GetPage<HomePage>();
            homePage.Open();
            homePage.OpenSection("Frames");

            Frame.SwitchToFrameContent("frame-outer");
            Frame.SwitchToFrameContent("frame-inner");

            FrameTest();

            Frame.SwitchToDefaultContext();
        }

        private void FrameTest()
        {
            var framesPage = GetPage<FramesPage>();

            framesPage.Frame.EditBtn.Click();
            Assert.That(framesPage.Frame.Result.Text, Is.EqualTo("Button pressed: Edit"));

            framesPage.Frame.SubmitBtn.Click();
            Assert.That(framesPage.Frame.Result.Text, Is.EqualTo("Button pressed: Submit"));

            framesPage.Frame.ClickMeBtn.Click();
            Assert.That(framesPage.Frame.Result.Text, Is.EqualTo("Button pressed: Click me"));

            framesPage.Frame.PrimaryBtn.Click();
            Assert.That(framesPage.Frame.Result.Text, Is.EqualTo("Button pressed: Primary"));
        }
    }
}
