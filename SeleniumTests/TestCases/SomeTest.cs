
using NUnit.Framework;
using SeleniumTests.PageObjects;

namespace SeleniumTests.TestCases
{
    public class SomeTest : BaseTest
    {
        [Test]
        public void VisibilityTest()
        {
            Navigation.OpenMainPage();

            var homePage = GetPage<HomePage>();
            homePage.OpenSection("Visibility");

            var visibilityPage = GetPage<VisibilityPage>();

            Console.WriteLine($"RemovedBtn      is visible: {visibilityPage.RemovedBtn.Displayed}");
            Console.WriteLine($"ZeroWidthBtn    is visible: {visibilityPage.ZeroWidthBtn.Displayed}");
            Console.WriteLine($"OverlappedBtn   is visible: {visibilityPage.OverlappedBtn.Displayed}");
            Console.WriteLine($"TransparentBtn  is visible: {visibilityPage.TransparentBtn.Displayed}");
            Console.WriteLine($"InvisibleBtn    is visible: {visibilityPage.InvisibleBtn.Displayed}");
            Console.WriteLine($"NotDisplayedBtn is visible: {visibilityPage.NotDisplayedBtn.Displayed}");
            Console.WriteLine($"OffScreenBtn    is visible: {visibilityPage.OffScreenBtn.Displayed}");

            visibilityPage.HideBtn.Click();

            Console.WriteLine("\n AFTER HIDE: ");

            // Console.WriteLine($"RemovedBtn      is visible: {visibilityPage.RemovedBtn.Displayed}"); // NoSuchElementException
            Console.WriteLine($"RemovedBtn      is visible: NoSuchElementException");
            Console.WriteLine($"ZeroWidthBtn    is visible: {visibilityPage.ZeroWidthBtn.Displayed}");
            Console.WriteLine($"OverlappedBtn   is visible: {visibilityPage.OverlappedBtn.Displayed}");
            Console.WriteLine($"TransparentBtn  is visible: {visibilityPage.TransparentBtn.Displayed}");
            Console.WriteLine($"InvisibleBtn    is visible: {visibilityPage.InvisibleBtn.Displayed}");
            Console.WriteLine($"NotDisplayedBtn is visible: {visibilityPage.NotDisplayedBtn.Displayed}");
            Console.WriteLine($"OffScreenBtn    is visible: {visibilityPage.OffScreenBtn.Displayed}");
        }
    }
}
