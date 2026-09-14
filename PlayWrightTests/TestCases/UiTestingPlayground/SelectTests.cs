using NUnit.Framework;
using PlayWrightTests.PageObjects.UiTestingPlayground;

namespace PlayWrightTests.TestCases.UiTestingPlayground
{
    [Parallelizable(ParallelScope.Self)]
    [TestFixture]
    public class SelectTests : BaseTest
    {
        private SelectPage selectPage;

        [SetUp]
        public async Task SetUp()
        {
            var homePage = GetPage<HomePage>();
            await homePage.OpenAsync();
            await homePage.OpenSectionAsync("Select");

            selectPage = GetPage<SelectPage>();
        }

        [Test]
        public async Task SelectLanguageTest()
        {
            await selectPage.Language.SelectOptionAsync(new[] { "cs" });
            Assert.That(await selectPage.StatusLanguage.TextContentAsync(), Is.EqualTo("Selected: C# (value: cs)"));
        }

        [Test]
        public async Task SelectCityTest()
        {
            await selectPage.City.SelectOptionAsync(new[] { "la" });
            Assert.That(await selectPage.StatusCity.TextContentAsync(), Is.EqualTo("Selected: Los Angeles (value: la)")); // <-- &nbsp; special character in the text
        }

        [Test]
        public async Task SelectProductTest()
        {
            await selectPage.ProductVersion.SelectOptionAsync(new[] { "v3.0" });
            Assert.That(await selectPage.StatusProduct.TextContentAsync(), Is.EqualTo("Selected: Release 3.0 (value: v3.0)"));
        }

        [Test]
        public async Task SelectColorsTest()
        {
            await selectPage.Colors.SelectOptionAsync(new[] { "Orange", "Green", "Purple" });
            // Deselect Orange by selecting only Green and Purple
            await selectPage.Colors.SelectOptionAsync(new[] { "Green", "Purple" });
            Assert.That(await selectPage.StatusColors.TextContentAsync(), Is.EqualTo("Selected: Green, Purple"));
        }

        [Test]
        public async Task SelectFruitsTest()
        {
            Assert.That(await selectPage.StatusFruits.TextContentAsync(), Is.Not.Null.And.Not.Empty);
            await selectPage.Fruits.SelectOptionAsync(new[] { "Elderberry" });
            Assert.That(await selectPage.StatusFruits.TextContentAsync(), Does.Contain("Elderberry"));
        }
    }
}
