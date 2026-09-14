using Microsoft.Playwright;

namespace PlayWrightTests.PageObjects.UiTestingPlayground
{
    public class SelectPage : BasePage
    {
        public SelectPage(IPage page) : base(page) { }

        // Select elements
        public ILocator Language => Page.Locator("#selectLanguage");
        public ILocator City => Page.Locator("#selectCity");
        public ILocator ProductVersion => Page.Locator("#selectProduct");
        public ILocator Colors => Page.Locator("#selectColors");
        public ILocator Fruits => Page.Locator("#selectFruits");

        // Status labels
        public ILocator StatusLanguage => Page.Locator("#statusLanguage");
        public ILocator StatusCity => Page.Locator("#statusCity");
        public ILocator StatusProduct => Page.Locator("#statusProduct");
        public ILocator StatusColors => Page.Locator("#statusColors");
        public ILocator StatusFruits => Page.Locator("#statusFruits");
    }
}
