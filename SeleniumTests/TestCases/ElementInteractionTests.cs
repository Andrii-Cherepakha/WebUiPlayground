
using NUnit.Framework;
using SeleniumTests.PageObjects;

namespace SeleniumTests.TestCases
{
    public class ElementInteractionTests : BaseTest
    {
        [Test]
        public void VisibilityTest()
        {
            var homePage = GetPage<HomePage>();
            homePage.Open();

            homePage.OpenSection("Visibility");

            var visibilityPage = GetPage<VisibilityPage>();

            Console.WriteLine("\nBEFORE HIDE: ");

            Console.WriteLine($"Removed           is visible: {visibilityPage.RemovedBtn.Displayed}");
            Console.WriteLine($"Zero Width        is visible: {visibilityPage.ZeroWidthBtn.Displayed}");
            Console.WriteLine($"Overlapped        is visible: {visibilityPage.OverlappedBtn.Displayed}");
            Console.WriteLine($"Opacity 0         is visible: {visibilityPage.TransparentBtn.Displayed}");
            Console.WriteLine($"Visibility Hidden is visible: {visibilityPage.InvisibleBtn.Displayed}");
            Console.WriteLine($"Not Displayed     is visible: {visibilityPage.NotDisplayedBtn.Displayed}");
            Console.WriteLine($"OffScreen         is visible: {visibilityPage.OffScreenBtn.Displayed}");

            visibilityPage.HideBtn.Click();

            Console.WriteLine("\nAFTER HIDE: ");

            //Console.WriteLine($"RemovedBtn      is visible: {visibilityPage.RemovedBtn.Displayed}"); // NoSuchElementException
            Console.WriteLine($"Removed           is visible: NoSuchElementException");
            Console.WriteLine($"Zero Width        is visible: {visibilityPage.ZeroWidthBtn.Displayed}");
            Console.WriteLine($"Overlapped        is visible: {visibilityPage.OverlappedBtn.Displayed}");
            Console.WriteLine($"Opacity 0         is visible: {visibilityPage.TransparentBtn.Displayed}");
            Console.WriteLine($"Visibility Hidden is visible: {visibilityPage.InvisibleBtn.Displayed}");
            Console.WriteLine($"Not Displayed     is visible: {visibilityPage.NotDisplayedBtn.Displayed}");
            Console.WriteLine($"OffScreen         is visible: {visibilityPage.OffScreenBtn.Displayed}");
        }

        [Test(Description = "Entering text to a partially visible element")]
        public void InputTextIntoTheOverlappedElement()
        {
            var homePage = GetPage<HomePage>();
            homePage.Open();

            homePage.OpenSection("Overlapped Element");

            var overlappedElementPage = GetPage<OverlappedElementPage>();

            const string ID = "ID-001";
            const string NAME = "John Doe";
            const string SUBJECT = "Test Subject";

            overlappedElementPage.IdTextBox.SendKeys(ID); // no overlapped, no scroll needed

            JsExecutor.ScrollToElement(overlappedElementPage.NameTextBox);
            //Action.ScrollToElement(overlappedElementPage.NameTextBox); // does not help
            overlappedElementPage.NameTextBox.SendKeys(NAME); // partialy overlapped, scroll needed

            overlappedElementPage.SubjectTextBox.SendKeys(SUBJECT); // completly overlapped, no scroll needed

            Assert.That(overlappedElementPage.IdTextBox.GetAttribute("value"), Is.EqualTo(ID));
            Assert.That(overlappedElementPage.NameTextBox.GetAttribute("value"), Is.EqualTo(NAME));
            Assert.That(overlappedElementPage.SubjectTextBox.GetAttribute("value"), Is.EqualTo(SUBJECT));
        }

        [Test]
        public void ClickTest()
        {
            var homePage = GetPage<HomePage>();
            homePage.Open();
            homePage.OpenSection("Click");

            var clickPage = GetPage<ClickPage>();

            clickPage.Btn.Click();

            Assert.That(clickPage.Btn.GetAttribute("class"), Contains.Substring("btn-success"));

            homePage.Open();
            homePage.OpenSection("Scroll to Click");

            var scrollToClickPage = GetPage<ScrollToClickPage>();

            scrollToClickPage.Btn1.Click();
            scrollToClickPage.Btn2.Click();
            scrollToClickPage.Btn3.Click();
            Action.MoveToElement(scrollToClickPage.HoverRow4);
            scrollToClickPage.Btn4.Click();

            Assert.That(scrollToClickPage.ProgressText.Text, Is.EqualTo("All buttons clicked!"));

            homePage.Open();
            homePage.OpenSection("Mouse Over");

            var mouseOverPage = GetPage<MouseOverPage>();

            mouseOverPage.ClickMeBtn.Click();
            mouseOverPage.LinkBtn.Click();

            Assert.That(mouseOverPage.ClickMeCount.Text, Is.EqualTo("1"));
            Assert.That(mouseOverPage.LinkCount.Text, Is.EqualTo("1"));
        }
    }
}
