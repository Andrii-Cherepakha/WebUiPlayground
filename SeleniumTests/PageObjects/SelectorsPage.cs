using OpenQA.Selenium;
using SeleniumTests.Core;

namespace SeleniumTests.PageObjects
{
    public class SelectorsPage : PageObject
    {
        public SelectorsPage(IWebDriver driver) : base(driver) {}

        // same element by different locators/selectors
        public IWebElement PrimaryBtnById => Context.GetElement(By.Id("primary-btn"));
        public IWebElement PrimaryBtnByDataIdCss => Context.GetElement(By.CssSelector("[data-id='primary-btn']"));
        public IWebElement PrimaryBtnByDataIdXpath => Context.GetElement(By.XPath("//button[@data-id='primary-btn']"));
        public IWebElement PrimaryBtnByTextXpath => Context.GetElement(By.XPath("//button[text()='Primary Button']"));
        public IWebElement PrimaryBtnByTextNormilizedXpath => Context.GetElement(By.XPath("//button[normalize-space()='Primary Button']"));

        // sibling, parent, ancestor
        public IWebElement Item2 => Context.GetElement(By.XPath("//li[text()='Item 2 (special)']"));
        public IWebElement Item2PrecedingSibling => Context.GetElement(By.XPath("//li[text()='Item 2 (special)']//preceding-sibling::li"));
        public IWebElement Item2FollowingSibling => Context.GetElement(By.XPath("//li[text()='Item 2 (special)']//following-sibling::li"));
        public IWebElement Item2ParentUl => Context.GetElement(By.XPath("//li[text()='Item 2 (special)']//parent::ul"));
        public IWebElement Item2ParentDiv => Context.GetElement(By.XPath("//li[text()='Item 2 (special)']//parent::ul//parent::div"));
        public IWebElement Item2AncestorDiv => Context.GetElement(By.XPath("//li[text()='Item 2 (special)']//ancestor::div[@id='combo-container']"));

        // invisible elements
        public IWebElement HiddenDisplayNone => Context.GetElement(By.Id("hidden-display"));
        public IWebElement HiddenVisibility => Context.GetElement(By.Id("hidden-visibility"));
        public IWebElement HiddenOverflow => Context.GetElement(By.Id("hidden-overflow"));
        public IWebElement HiddenZeroOpacity => Context.GetElement(By.Id("hidden-opacity"));
        public IWebElement HiddenOffScreen => Context.GetElement(By.Id("hidden-offscreen"));


        // Shadow DOM

        // aliases to avoid chaining in the test
        public IWebElement ButtonLevel1 => ShadowLevel1.Button;
        public IWebElement InputLevel1 => ShadowLevel1.Input;
        public IWebElement ButtonLevel2 => ShadowLevel1.NestedLevel?.Button;
        public IWebElement InputLevel2 => ShadowLevel1.NestedLevel?.Input;
        public IWebElement ButtonLevel3 => ShadowLevel1.NestedLevel?.NestedLevel?.Button;
        public IWebElement InputLevel3 => ShadowLevel1.NestedLevel?.NestedLevel?.Input;

        // Note: Selenium does not support XPath inside the shadow root
        private ShadowLevel ShadowLevel1 => new ShadowLevel(Context
                .GetElement(By.CssSelector("css-outer-component[data-id='shadow-host-outer']"))
                .GetShadowRoot(), Level1Config);

        #region Shadow DOM classes

        private sealed class ShadowLevelConfig
        {
            public int Level { get; init; }
            public By? NestedLevelSelector { get; init; }
            public Func<ISearchContext, ShadowLevel>? NestedLevelFactory { get; init; }
        }

        private sealed class ShadowLevel : PageObject
        {
            private readonly ShadowLevelConfig _config;

            public ShadowLevel(ISearchContext shadowRoot, ShadowLevelConfig config) : base(shadowRoot)
            {
                _config = config;
            }

            public IWebElement Button => Context.GetElement(By.CssSelector($"button#shadow-btn-l{_config.Level}"));

            public IWebElement Input => Context.GetElement(By.CssSelector($"input#shadow-input-l{_config.Level}"));

            public ShadowLevel? NestedLevel =>
                _config.NestedLevelFactory == null || _config.NestedLevelSelector == null
                    ? null
                    : _config.NestedLevelFactory(Context.GetElement(_config.NestedLevelSelector).GetShadowRoot());

            public int Level => _config.Level;
        }

        private static readonly ShadowLevelConfig Level3Config = new()
        {
            Level = 3,
            NestedLevelSelector = null,
            NestedLevelFactory = null
        };

        private static readonly ShadowLevelConfig Level2Config = new()
        {
            Level = 2,
            NestedLevelSelector = By.CssSelector("css-deep-component[data-id='shadow-host-deep']"),
            NestedLevelFactory = root => new ShadowLevel(root, Level3Config)
        };

        private static readonly ShadowLevelConfig Level1Config = new()
        {
            Level = 1,
            NestedLevelSelector = By.CssSelector("css-inner-component[data-id='shadow-host-inner']"),
            NestedLevelFactory = root => new ShadowLevel(root, Level2Config)
        };

        #endregion
    }
}
