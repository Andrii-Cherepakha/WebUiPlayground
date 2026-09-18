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

        // aliases to avoid chaining ShadowLevel1.ShadowLevel2.ShadowLevel3.Button and ShadowLevel1.ShadowLevel2.ShadowLevel3.Input
        public IWebElement ButtonLevel1 => ShadowLevel1.Button;
        public IWebElement InputLevel1 => ShadowLevel1.Input;
        public IWebElement ButtonLevel2 => ShadowLevel1.ShadowLevel2.Button;
        public IWebElement InputLevel2 => ShadowLevel1.ShadowLevel2.Input;
        public IWebElement ButtonLevel3 => ShadowLevel1.ShadowLevel2.ShadowLevel3.Button;
        public IWebElement InputLevel3 => ShadowLevel1.ShadowLevel2.ShadowLevel3.Input;


        private ShadowDOMLevel1 ShadowLevel1 =>
            new ShadowDOMLevel1(Context
                .GetElement(By.CssSelector("css-outer-component[data-id='shadow-host-outer']"))
                .GetShadowRoot());

        // Note: Selenium does not support XPath inside the shadow root

        private class ShadowDOMLevel1 : PageObject
        {
            public ShadowDOMLevel1(ISearchContext shadowRoot) : base(shadowRoot) { }

            public IWebElement Button => Context.GetElement(By.CssSelector($"button#shadow-btn-l1"));
            public IWebElement Input => Context.GetElement(By.CssSelector($"input#shadow-input-l1"));

            public ShadowDOMLevel2 ShadowLevel2 => new ShadowDOMLevel2(Context
                .GetElement(By.CssSelector("css-inner-component[data-id='shadow-host-inner']"))
                .GetShadowRoot());
        }

        private class ShadowDOMLevel2 : PageObject
        {
            public ShadowDOMLevel2(ISearchContext shadowRoot) : base(shadowRoot) { }

            public IWebElement Button => Context.GetElement(By.CssSelector($"button#shadow-btn-l2"));
            public IWebElement Input => Context.GetElement(By.CssSelector($"input#shadow-input-l2"));

            public ShadowDOMLevel3 ShadowLevel3 => new ShadowDOMLevel3(Context
                .GetElement(By.CssSelector("css-deep-component[data-id='shadow-host-deep']"))
                .GetShadowRoot());
        }

        private class ShadowDOMLevel3 : PageObject
        {
            public ShadowDOMLevel3(ISearchContext shadowRoot) : base(shadowRoot) { }

            public IWebElement Button => Context.GetElement(By.CssSelector($"button#shadow-btn-l3"));
            public IWebElement Input => Context.GetElement(By.CssSelector($"input#shadow-input-l3"));
        }
    }
}
