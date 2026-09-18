using NUnit.Framework;
using OpenQA.Selenium;
using SeleniumTests.PageObjects;

namespace SeleniumTests.TestCases
{
    public class SelectorTests : BaseTest
    {
        private readonly HomePage homePage;
        private readonly SelectorsPage selectorsPage;

        public SelectorTests()
        {
            homePage = GetPage<HomePage>();
            selectorsPage = GetPage<SelectorsPage>();
        }

        [SetUp]
        public void SetUp()
        {
            homePage.Open();
        }

        [Test]
        public void ByIdByText()
        {
            homePage.OpenSection("CSS Selectors");

            IList<IWebElement> buttons = new List<IWebElement>();

            // same element by different locators/selectors
            buttons.Add(selectorsPage.PrimaryBtnById);
            buttons.Add(selectorsPage.PrimaryBtnByDataIdCss);
            buttons.Add(selectorsPage.PrimaryBtnByDataIdXpath);
            buttons.Add(selectorsPage.PrimaryBtnByTextXpath);
            buttons.Add(selectorsPage.PrimaryBtnByTextNormilizedXpath);

            Assert.That(buttons.Count, Is.EqualTo(5));

            foreach (var button in buttons)
            {
                Assert.That(button.TagName, Is.EqualTo("button"));
                Assert.That(button.Text, Is.EqualTo("Primary Button"));
                Assert.That(button.GetAttribute("id"), Is.EqualTo("primary-btn"));
                Assert.That(button.GetAttribute("data-id"), Is.EqualTo("primary-btn"));
                Assert.That(button.GetAttribute("class"), Is.EqualTo("btn btn-primary"));
            }
        }

        [Test]
        public void ByTextSiblingParentAncestor()
        {
            homePage.OpenSection("CSS Selectors");

            Assert.That(selectorsPage.Item2.GetAttribute("data-id"), Is.EqualTo("combo-item-2"));
            Assert.That(selectorsPage.Item2PrecedingSibling.GetAttribute("data-id"), Is.EqualTo("combo-item-1"));
            Assert.That(selectorsPage.Item2FollowingSibling.GetAttribute("data-id"), Is.EqualTo("combo-item-3"));
            Assert.That(selectorsPage.Item2ParentUl.GetAttribute("data-id"), Is.EqualTo("combo-list"));
            Assert.That(selectorsPage.Item2ParentDiv.GetAttribute("data-id"), Is.EqualTo("combo-container"));
            Assert.That(selectorsPage.Item2AncestorDiv.GetAttribute("data-id"), Is.EqualTo("combo-container"));
        }

        [Test]
        public void InvisibleElements()
        {
            homePage.OpenSection("CSS Selectors");

            Assert.That(selectorsPage.HiddenDisplayNone.TagName, Is.EqualTo("button"));
            Assert.That(selectorsPage.HiddenVisibility.TagName, Is.EqualTo("button"));
            Assert.That(selectorsPage.HiddenOverflow.TagName, Is.EqualTo("button"));
            Assert.That(selectorsPage.HiddenZeroOpacity.TagName, Is.EqualTo("button"));
            Assert.That(selectorsPage.HiddenOffScreen.TagName, Is.EqualTo("button"));

            Assert.That(selectorsPage.HiddenDisplayNone.GetAttribute("data-id"), Is.EqualTo("hidden-display"));
            Assert.That(selectorsPage.HiddenVisibility.GetAttribute("data-id"), Is.EqualTo("hidden-visibility"));
            Assert.That(selectorsPage.HiddenOverflow.GetAttribute("data-id"), Is.EqualTo("hidden-overflow"));
            Assert.That(selectorsPage.HiddenZeroOpacity.GetAttribute("data-id"), Is.EqualTo("hidden-opacity"));
            Assert.That(selectorsPage.HiddenOffScreen.GetAttribute("data-id"), Is.EqualTo("hidden-offscreen"));

            // in all cases Text is string.Empty
            // Assert.That(selectorsPage.HiddenDisplayNone.Text, Is.EqualTo("Hidden via display:none"));
            // Assert.That(selectorsPage.HiddenVisibility.Text, Is.EqualTo("Hidden via visibility:hidden"));
            // Assert.That(selectorsPage.HiddenOverflow.Text, Is.EqualTo("Hidden via zero-size parent"));
            // Assert.That(selectorsPage.HiddenZeroOpacity.Text, Is.EqualTo("Hidden via opacity:0"));
            // Assert.That(selectorsPage.HiddenOffScreen.Text, Is.EqualTo("Hidden via offscreen position"));
        }

        [Test]
        public void ShadowDOM()
        {
            homePage.OpenSection("CSS Selectors");

            Assert.That(selectorsPage.ButtonLevel1.TagName, Is.EqualTo("button"));
            Assert.That(selectorsPage.ButtonLevel1.GetAttribute("id"), Is.EqualTo("shadow-btn-l1"));
            Assert.That(selectorsPage.ButtonLevel1.GetAttribute("data-level"), Is.EqualTo("1"));
            Assert.That(selectorsPage.ButtonLevel1.GetAttribute("data-id"), Is.EqualTo("shadow-l1-btn"));
            Assert.That(selectorsPage.ButtonLevel1.Text, Is.EqualTo("Level 1 Button"));

            selectorsPage.InputLevel1.SendKeys("Hello from Level 1 Shadow DOM");
            Assert.That(selectorsPage.InputLevel1.GetAttribute("value"), Is.EqualTo("Hello from Level 1 Shadow DOM"));

            Assert.That(selectorsPage.ButtonLevel2.TagName, Is.EqualTo("button"));
            Assert.That(selectorsPage.ButtonLevel2.GetAttribute("id"), Is.EqualTo("shadow-btn-l2"));
            Assert.That(selectorsPage.ButtonLevel2.GetAttribute("data-level"), Is.EqualTo("2"));
            Assert.That(selectorsPage.ButtonLevel2.GetAttribute("data-id"), Is.EqualTo("shadow-l2-btn"));
            Assert.That(selectorsPage.ButtonLevel2.Text, Is.EqualTo("Level 2 Button"));

            selectorsPage.InputLevel2.SendKeys("Hello from Level 2 Shadow DOM");
            Assert.That(selectorsPage.InputLevel2.GetAttribute("value"), Is.EqualTo("Hello from Level 2 Shadow DOM"));

            Assert.That(selectorsPage.ButtonLevel3.TagName, Is.EqualTo("button"));
            Assert.That(selectorsPage.ButtonLevel3.GetAttribute("id"), Is.EqualTo("shadow-btn-l3"));
            Assert.That(selectorsPage.ButtonLevel3.GetAttribute("data-level"), Is.EqualTo("3"));
            Assert.That(selectorsPage.ButtonLevel3.GetAttribute("data-id"), Is.EqualTo("shadow-l3-btn"));
            Assert.That(selectorsPage.ButtonLevel3.Text, Is.EqualTo("Level 3 Button"));

            selectorsPage.InputLevel3.SendKeys("Hello from Level 3 Shadow DOM");
            Assert.That(selectorsPage.InputLevel3.GetAttribute("value"), Is.EqualTo("Hello from Level 3 Shadow DOM"));
        }

        [Test]
        public void ByTextWithSpaces()
        {
            homePage.OpenSection("Verify Text");

            var verifyTextPage = GetPage<VerifyTextPage>();

            Assert.That(verifyTextPage.TextElement.TagName, Is.EqualTo("p"));
            Assert.That(verifyTextPage.TextElement.Text, Is.EqualTo("Hello UserName!"));
        }

        [Test]
        public void ByTextNbsp()
        {
            homePage.OpenSection("Non-Breaking Space");

            var nonBreakingSpacePage = GetPage<NonBreakingSpacePage>();

            Assert.That(nonBreakingSpacePage.BtnNbsp.TagName, Is.EqualTo("button"));
            Assert.That(nonBreakingSpacePage.BtnNbsp.Text, Is.EqualTo("My Button")); // <-- No &nbsp; special character in the text
            Assert.That(nonBreakingSpacePage.BtnNormalized.TagName, Is.EqualTo("button"));
            Assert.That(nonBreakingSpacePage.BtnNormalized.Text, Is.EqualTo("My Button")); // <-- No &nbsp; special character in the text
        }
    }
}
