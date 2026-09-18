using Microsoft.Playwright;

namespace PlayWrightTests.PageObjects.UiTestingPlayground
{
    public class SelectorsPage : BasePage
    {
        public SelectorsPage(IPage page) : base(page) { }

        // same element by different locators/selectors
        public ILocator PrimaryBtnById => Page.Locator("#primary-btn");
        public ILocator PrimaryBtnByDataIdCss => Page.Locator("[data-id='primary-btn']");
        public ILocator PrimaryBtnByDataIdXpath => Page.Locator("//button[@data-id='primary-btn']");
        public ILocator PrimaryBtnByTextXpath => Page.Locator("//button[text()='Primary Button']");
        public ILocator PrimaryBtnByTextNormalizedXpath => Page.Locator("//button[normalize-space()='Primary Button']");
        public ILocator PrimaryBtnByText => Page.GetByText("Primary Button");

        // sibling, parent, ancestor
        public ILocator Item2 => Page.Locator("//li[text()='Item 2 (special)']");
        public ILocator Item2PrecedingSibling => Page.Locator("//li[text()='Item 2 (special)']//preceding-sibling::li");
        public ILocator Item2FollowingSibling => Page.Locator("//li[text()='Item 2 (special)']//following-sibling::li");
        public ILocator Item2ParentUl => Page.Locator("//li[text()='Item 2 (special)']//parent::ul");
        public ILocator Item2ParentDiv => Page.Locator("//li[text()='Item 2 (special)']//parent::ul//parent::div");
        public ILocator Item2AncestorDiv => Page.Locator("//li[text()='Item 2 (special)']//ancestor::div[@id='combo-container']");

        // invisible elements
        public ILocator HiddenDisplayNone => Page.Locator("#hidden-display");
        public ILocator HiddenVisibility => Page.Locator("#hidden-visibility");
        public ILocator HiddenOverflow => Page.Locator("#hidden-overflow");
        public ILocator HiddenZeroOpacity => Page.Locator("#hidden-opacity");
        public ILocator HiddenOffScreen => Page.Locator("#hidden-offscreen");
    }
}
