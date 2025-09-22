using NUnit.Framework;
using SeleniumTests.Core;

namespace SeleniumTests.TestCases
{
    public class NavigationTest : BaseTest
    {

        [Test]
        public void StartBrowserTest()
        {
            Navigation.OpenBasePage();
        }
    }
}
