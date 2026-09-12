
using NUnit.Framework;
using SeleniumTests.PageObjects;

namespace SeleniumTests.TestCases
{
    public class ElementInteractionTest : BaseTest
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
    }
}
