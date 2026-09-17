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
            buttons.Add(selectorsPage.GetElement(By.Id("primary-btn")));
            buttons.Add(selectorsPage.GetElement(By.CssSelector("[data-id='primary-btn']")));
            buttons.Add(selectorsPage.GetElement(By.XPath("//button[@data-id='primary-btn']")));
            buttons.Add(selectorsPage.GetElement(By.XPath("//button[text()='Primary Button']")));
            buttons.Add(selectorsPage.GetElement(By.XPath("//button[normalize-space()='Primary Button']")));

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

            var item2 = selectorsPage.GetElement(By.XPath("//li[text()='Item 2 (special)']"));
            var precedingSibling = selectorsPage.GetElement(By.XPath("//li[text()='Item 2 (special)']//preceding-sibling::li"));
            var followingSibling = selectorsPage.GetElement(By.XPath("//li[text()='Item 2 (special)']//following-sibling::li"));
            var parentUl = selectorsPage.GetElement(By.XPath("//li[text()='Item 2 (special)']//parent::ul"));
            var parentDiv = selectorsPage.GetElement(By.XPath("//li[text()='Item 2 (special)']//parent::ul//parent::div"));
            // var ancestorDiv = selectorsPage.GetElement(By.XPath("//li[text()='Item 2 (special)']/ancestor::div"));

            Assert.That(item2.GetAttribute("data-id"), Is.EqualTo("combo-item-2"));
            Assert.That(precedingSibling.GetAttribute("data-id"), Is.EqualTo("combo-item-1"));
            Assert.That(followingSibling.GetAttribute("data-id"), Is.EqualTo("combo-item-3"));
            Assert.That(parentUl.GetAttribute("data-id"), Is.EqualTo("combo-list"));
            Assert.That(parentDiv.GetAttribute("data-id"), Is.EqualTo("combo-container"));
        }

        [Test]
        public void InvisibleElements()
        {
            homePage.OpenSection("CSS Selectors");

            var displayNone = selectorsPage.GetElement(By.Id("hidden-display"));
            var hidden = selectorsPage.GetElement(By.Id("hidden-visibility"));
            var zeroSizeParent = selectorsPage.GetElement(By.Id("hidden-overflow"));
            var zeroOpacity = selectorsPage.GetElement(By.Id("hidden-opacity"));
            var offScreen = selectorsPage.GetElement(By.Id("hidden-offscreen"));

            Assert.That(displayNone.TagName, Is.EqualTo("button"));
            Assert.That(hidden.TagName, Is.EqualTo("button"));
            Assert.That(zeroSizeParent.TagName, Is.EqualTo("button"));
            Assert.That(zeroOpacity.TagName, Is.EqualTo("button"));
            Assert.That(offScreen.TagName, Is.EqualTo("button"));

            Assert.That(displayNone.GetAttribute("data-id"), Is.EqualTo("hidden-display"));
            Assert.That(hidden.GetAttribute("data-id"), Is.EqualTo("hidden-visibility"));
            Assert.That(zeroSizeParent.GetAttribute("data-id"), Is.EqualTo("hidden-overflow"));
            Assert.That(zeroOpacity.GetAttribute("data-id"), Is.EqualTo("hidden-opacity"));
            Assert.That(offScreen.GetAttribute("data-id"), Is.EqualTo("hidden-offscreen"));

            // in all cases Text is string.Empty
            // Assert.That(displayNone.Text, Is.EqualTo("Hidden via display:none"));
            // Assert.That(hidden.Text, Is.EqualTo("Hidden via visibility:hidden"));
            // Assert.That(zeroSizeParent.Text, Is.EqualTo("Hidden via zero-size parent"));
            // Assert.That(zeroOpacity.Text, Is.EqualTo("Hidden via opacity:0"));
            // Assert.That(offScreen.Text, Is.EqualTo("Hidden via offscreen position"));
        }

        [Test]
        public void ShadowDOM()
        {
            homePage.OpenSection("CSS Selectors");

            var shadowLevel1 = selectorsPage.
                GetElement(By.XPath("//css-outer-component[@data-id='shadow-host-outer']"))
                .GetShadowRoot();

            // Find an element inside the shadow DOM. Selenium does not support XPath inside the shadow root
            // OpenQA.Selenium.WebDriverArgumentException : invalid argument: invalid locator
            // var button = shadowLevel1.FindElement(By.XPath("//button[@id='shadow-btn-l1']"));
            // var button = shadowLevel1.FindElement(By.Id("shadow-btn-l1"));
            var button1 = shadowLevel1.FindElement(By.CssSelector("button#shadow-btn-l1"));

            Assert.That(button1.TagName, Is.EqualTo("button"));
            Assert.That(button1.GetAttribute("id"), Is.EqualTo("shadow-btn-l1"));
            Assert.That(button1.GetAttribute("data-level"), Is.EqualTo("1"));
            Assert.That(button1.GetAttribute("data-id"), Is.EqualTo("shadow-l1-btn"));
            Assert.That(button1.Text, Is.EqualTo("Level 1 Button"));

            var input1 = shadowLevel1.FindElement(By.CssSelector("input#shadow-input-l1"));
            input1.SendKeys("Hello from Level 1 Shadow DOM");
            Assert.That(input1.GetAttribute("value"), Is.EqualTo("Hello from Level 1 Shadow DOM"));

            // Level 2 shadow DOM
            var shadowLevel2 = shadowLevel1
                .FindElement(By.CssSelector("css-inner-component[data-id='shadow-host-inner']"))
                .GetShadowRoot();

            var button2 = shadowLevel2.FindElement(By.CssSelector("button#shadow-btn-l2"));

            Assert.That(button2.TagName, Is.EqualTo("button"));
            Assert.That(button2.GetAttribute("id"), Is.EqualTo("shadow-btn-l2"));
            Assert.That(button2.GetAttribute("data-level"), Is.EqualTo("2"));
            Assert.That(button2.GetAttribute("data-id"), Is.EqualTo("shadow-l2-btn"));
            Assert.That(button2.Text, Is.EqualTo("Level 2 Button"));

            var input2 = shadowLevel2.FindElement(By.CssSelector("input#shadow-input-l2"));
            input2.SendKeys("Hello from Level 2 Shadow DOM");
            Assert.That(input2.GetAttribute("value"), Is.EqualTo("Hello from Level 2 Shadow DOM"));

            // Level 3 shadow DOM
            var shadowLevel3 = shadowLevel2
                .FindElement(By.CssSelector("css-deep-component[data-id='shadow-host-deep']"))
                .GetShadowRoot();

            var button3 = shadowLevel3.FindElement(By.CssSelector("button#shadow-btn-l3"));

            Assert.That(button3.TagName, Is.EqualTo("button"));
            Assert.That(button3.GetAttribute("id"), Is.EqualTo("shadow-btn-l3"));
            Assert.That(button3.GetAttribute("data-level"), Is.EqualTo("3"));
            Assert.That(button3.GetAttribute("data-id"), Is.EqualTo("shadow-l3-btn"));
            Assert.That(button3.Text, Is.EqualTo("Level 3 Button"));

            var input3 = shadowLevel3.FindElement(By.CssSelector("input#shadow-input-l3"));
            input3.SendKeys("Hello from Level 3 Shadow DOM");
            Assert.That(input3.GetAttribute("value"), Is.EqualTo("Hello from Level 3 Shadow DOM"));
        }

        [Test]
        public void ByTextWithSpaces()
        {
            homePage.OpenSection("Verify Text");

            selectorsPage.GetElement(By.XPath("//p[normalize-space(.)='Hello UserName!']")); // selectorsPage is a stab here
        }

        [Test]
        public void ByTextNbsp()
        {
            homePage.OpenSection("Non-Breaking Space");

            //selectorsPage.GetElement(By.XPath("//button[text()='My Button']")); // selectorsPage is a stab here
            selectorsPage.GetElement(By.XPath("//button[text()='My Button']")); // selectorsPage is a stab here <-- &nbsp; special character in the text
            selectorsPage.GetElement(By.XPath("//button[normalize-space(.)='My Button']"));
        }
    }
}
