using Microsoft.Playwright;
using NUnit.Framework;
using PlayWrightTests.PageObjects.UiTestingPlayground;

namespace PlayWrightTests.TestCases.UiTestingPlayground
{
    [Parallelizable(ParallelScope.Self)]
    [TestFixture]
    public class SelectorTests : BaseTest
    {
        private HomePage homePage;

        [SetUp]
        public async Task SetUp()
        {
            homePage = GetPage<HomePage>();
            await homePage.OpenAsync();
        }

        [Test]
        public async Task ByIdByText()
        {
            await homePage.OpenSectionAsync("CSS Selectors");
            var selectorsPage = GetPage<SelectorsPage>();

            IList<ILocator> buttons = new List<ILocator>();

            // same element by different locators/selectors
            buttons.Add(selectorsPage.PrimaryBtnById);
            buttons.Add(selectorsPage.PrimaryBtnByDataIdCss);
            buttons.Add(selectorsPage.PrimaryBtnByDataIdXpath);
            buttons.Add(selectorsPage.PrimaryBtnByTextXpath);
            buttons.Add(selectorsPage.PrimaryBtnByTextNormalizedXpath);
            buttons.Add(selectorsPage.PrimaryBtnByText);

            Assert.That(buttons.Count, Is.EqualTo(6));

            foreach (var button in buttons)
            {
                Assert.That(await button.EvaluateAsync<string>("el => el.tagName"), Is.EqualTo("BUTTON"));
                Assert.That(await button.TextContentAsync(), Is.EqualTo("Primary Button"));
                Assert.That(await button.GetAttributeAsync("id"), Is.EqualTo("primary-btn"));
                Assert.That(await button.GetAttributeAsync("data-id"), Is.EqualTo("primary-btn"));
                Assert.That(await button.GetAttributeAsync("class"), Is.EqualTo("btn btn-primary"));
            }
        }

        [Test]
        public async Task ByTextSiblingParentAncestor()
        {
            await homePage.OpenSectionAsync("CSS Selectors");
            var selectorsPage = GetPage<SelectorsPage>();

            Assert.That(await selectorsPage.Item2.GetAttributeAsync("data-id"), Is.EqualTo("combo-item-2"));
            Assert.That(await selectorsPage.Item2PrecedingSibling.GetAttributeAsync("data-id"), Is.EqualTo("combo-item-1"));
            Assert.That(await selectorsPage.Item2FollowingSibling.GetAttributeAsync("data-id"), Is.EqualTo("combo-item-3"));
            Assert.That(await selectorsPage.Item2ParentUl.GetAttributeAsync("data-id"), Is.EqualTo("combo-list"));
            Assert.That(await selectorsPage.Item2ParentDiv.GetAttributeAsync("data-id"), Is.EqualTo("combo-container"));
            Assert.That(await selectorsPage.Item2AncestorDiv.GetAttributeAsync("data-id"), Is.EqualTo("combo-container"));
        }

        [Test]
        public async Task InvisibleElements()
        {
            await homePage.OpenSectionAsync("CSS Selectors");
            var selectorsPage = GetPage<SelectorsPage>();

            Assert.That(await selectorsPage.HiddenDisplayNone.EvaluateAsync<string>("el => el.tagName"), Is.EqualTo("BUTTON"));
            Assert.That(await selectorsPage.HiddenVisibility.EvaluateAsync<string>("el => el.tagName"), Is.EqualTo("BUTTON"));
            Assert.That(await selectorsPage.HiddenOverflow.EvaluateAsync<string>("el => el.tagName"), Is.EqualTo("BUTTON"));
            Assert.That(await selectorsPage.HiddenZeroOpacity.EvaluateAsync<string>("el => el.tagName"), Is.EqualTo("BUTTON"));
            Assert.That(await selectorsPage.HiddenOffScreen.EvaluateAsync<string>("el => el.tagName"), Is.EqualTo("BUTTON"));

            Assert.That(await selectorsPage.HiddenDisplayNone.GetAttributeAsync("data-id"), Is.EqualTo("hidden-display"));
            Assert.That(await selectorsPage.HiddenVisibility.GetAttributeAsync("data-id"), Is.EqualTo("hidden-visibility"));
            Assert.That(await selectorsPage.HiddenOverflow.GetAttributeAsync("data-id"), Is.EqualTo("hidden-overflow"));
            Assert.That(await selectorsPage.HiddenZeroOpacity.GetAttributeAsync("data-id"), Is.EqualTo("hidden-opacity"));
            Assert.That(await selectorsPage.HiddenOffScreen.GetAttributeAsync("data-id"), Is.EqualTo("hidden-offscreen"));

            // in all cases Text is string.Empty
            Assert.That(await selectorsPage.HiddenDisplayNone.TextContentAsync(), Is.EqualTo("Hidden via display:none"));
            Assert.That(await selectorsPage.HiddenVisibility.TextContentAsync(), Is.EqualTo("Hidden via visibility:hidden"));
            Assert.That(await selectorsPage.HiddenOverflow.TextContentAsync(), Is.EqualTo("Hidden via zero-size parent"));
            Assert.That(await selectorsPage.HiddenZeroOpacity.TextContentAsync(), Is.EqualTo("Hidden via opacity:0"));
            Assert.That(await selectorsPage.HiddenOffScreen.TextContentAsync(), Is.EqualTo("Hidden via offscreen position"));
        }

        [Test]
        public async Task ShadowDOM()
        {
            await homePage.OpenSectionAsync("CSS Selectors");
            var selectorsPage = GetPage<SelectorsPage>();

            Assert.That(await selectorsPage.ButtonLevel1.EvaluateAsync<string>("el => el.tagName"), Is.EqualTo("BUTTON"));
            Assert.That(await selectorsPage.ButtonLevel1.GetAttributeAsync("id"), Is.EqualTo("shadow-btn-l1"));
            Assert.That(await selectorsPage.ButtonLevel1.GetAttributeAsync("data-level"), Is.EqualTo("1"));
            Assert.That(await selectorsPage.ButtonLevel1.GetAttributeAsync("data-id"), Is.EqualTo("shadow-l1-btn"));
            Assert.That(await selectorsPage.ButtonLevel1.TextContentAsync(), Is.EqualTo("Level 1 Button"));

            await selectorsPage.InputLevel1.FillAsync("Hello from Level 1 Shadow DOM");
            Assert.That(await selectorsPage.InputLevel1.InputValueAsync(), Is.EqualTo("Hello from Level 1 Shadow DOM"));

            Assert.That(await selectorsPage.ButtonLevel2.EvaluateAsync<string>("el => el.tagName"), Is.EqualTo("BUTTON"));
            Assert.That(await selectorsPage.ButtonLevel2.GetAttributeAsync("id"), Is.EqualTo("shadow-btn-l2"));
            Assert.That(await selectorsPage.ButtonLevel2.GetAttributeAsync("data-level"), Is.EqualTo("2"));
            Assert.That(await selectorsPage.ButtonLevel2.GetAttributeAsync("data-id"), Is.EqualTo("shadow-l2-btn"));
            Assert.That(await selectorsPage.ButtonLevel2.TextContentAsync(), Is.EqualTo("Level 2 Button"));

            await selectorsPage.InputLevel2.FillAsync("Hello from Level 2 Shadow DOM");
            Assert.That(await selectorsPage.InputLevel2.InputValueAsync(), Is.EqualTo("Hello from Level 2 Shadow DOM"));

            Assert.That(await selectorsPage.ButtonLevel3.EvaluateAsync<string>("el => el.tagName"), Is.EqualTo("BUTTON"));
            Assert.That(await selectorsPage.ButtonLevel3.GetAttributeAsync("id"), Is.EqualTo("shadow-btn-l3"));
            Assert.That(await selectorsPage.ButtonLevel3.GetAttributeAsync("data-level"), Is.EqualTo("3"));
            Assert.That(await selectorsPage.ButtonLevel3.GetAttributeAsync("data-id"), Is.EqualTo("shadow-l3-btn"));
            Assert.That(await selectorsPage.ButtonLevel3.TextContentAsync(), Is.EqualTo("Level 3 Button"));

            await selectorsPage.InputLevel3.FillAsync("Hello from Level 3 Shadow DOM");
            Assert.That(await selectorsPage.InputLevel3.InputValueAsync(), Is.EqualTo("Hello from Level 3 Shadow DOM"));
        }

        [Test]
        public async Task ByTextWithSpaces()
        {
            await homePage.OpenSectionAsync("Verify Text");

            var verifyTextPage = GetPage<VerifyTextPage>();

            Assert.That(await verifyTextPage.TextElementHello.EvaluateAsync<string>("el => el.tagName"), Is.EqualTo("SPAN"));
            Assert.That(await verifyTextPage.TextElementHello.InnerTextAsync(), Is.EqualTo("Hello UserName!"));

            Assert.That(await verifyTextPage.TextElementWelcome.EvaluateAsync<string>("el => el.tagName"), Is.EqualTo("SPAN"));
            Assert.That(await verifyTextPage.TextElementWelcome.InnerTextAsync(), Is.EqualTo("Welcome UserName!"));

            //Assert.That(await verifyTextPage.TextElementHelloByText.EvaluateAsync<string>("el => el.tagName"), Is.EqualTo("SPAN"));
            //Assert.That(await verifyTextPage.TextElementHelloByText.InnerTextAsync(), Is.EqualTo("Hello UserName!"));

            Assert.That(await verifyTextPage.TextElementWelcomeByText.EvaluateAsync<string>("el => el.tagName"), Is.EqualTo("SPAN"));
            Assert.That(await verifyTextPage.TextElementWelcomeByText.InnerTextAsync(), Is.EqualTo("Welcome UserName!"));
        }
    }
}
