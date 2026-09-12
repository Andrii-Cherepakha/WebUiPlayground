using NUnit.Framework;
using SeleniumTests.PageObjects;

namespace SeleniumTests.TestCases
{
    public class NavigationTest : BaseTest
    {

        [Test]
        public void StartBrowserTest()
        {
            var homePage = GetPage<HomePage>();
            homePage.Navigate();
        }
    }
}
