using NUnit.Framework;
using SeleniumTests.PageObjects;

namespace SeleniumTests.TestCases
{
    public class SelectTests : BaseTest
    {
        private readonly SelectPage selectPage;

        public SelectTests()
        {
            selectPage = GetPage<SelectPage>();
        }

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            var homePage = GetPage<HomePage>();
            homePage.Open();
            homePage.OpenSection("Select");
        }

        [Test]
        public void SelectLanguageTest()
        {
            selectPage.Language.SelectByText("C#");
            Assert.That(selectPage.StatusLanguage.Text, Is.EqualTo("Selected: C# (value: cs)"));
        }

        [Test]
        public void SelectCityTest()
        {
            selectPage.City.SelectByText("Los Angeles");
            Assert.That(selectPage.StatusCity.Text, Is.EqualTo("Selected: Los Angeles (value: la)"));
        }

        [Test]
        public void SelectProductTest()
        {
            selectPage.ProductVersion.SelectByText("Release 3.0");
            Assert.That(selectPage.StatusProduct.Text, Is.EqualTo("Selected: Release 3.0 (value: v3.0)"));
        }

        [Test]
        public void SelectColorsTest()
        {
            selectPage.Colors.SelectByText("Orange");
            selectPage.Colors.SelectByText("Green");
            selectPage.Colors.SelectByText("Purple");
            selectPage.Colors.DeselectByText("Orange");
            Assert.That(selectPage.StatusColors.Text, Is.EqualTo("Selected: Green, Purple"));
        }

        [Test]
        public void SelectFruitsTest()
        {
            Assert.That(selectPage.Fruits.AllSelectedOptions, Is.Not.Empty);
            selectPage.Fruits.SelectByText("Elderberry");
            Assert.That(selectPage.StatusFruits.Text, Contains.Substring("Elderberry"));
        }
    }
}
