using Microsoft.Playwright;

namespace PlayWrightTests.PageObjects.UiTestingPlayground
{
    public class ScrollToClickPage : BasePage
    {
        public ScrollToClickPage(IPage page) : base(page) { }

        public ILocator Btn1 => Page.Locator("#scrollTarget1"); // Page Scroll
        public ILocator Btn2 => Page.Locator("#scrollTarget2"); // Container Scroll
        public ILocator Btn3 => Page.Locator("#scrollTarget3"); // Nested Scroll (Parent + Child)
        public ILocator HoverRow4 => Page.Locator("#targetRow4"); // Hover to Reveal
        public ILocator Btn4 => Page.Locator("#scrollTarget4");
        public ILocator ProgressText => Page.Locator("#progressText");
    }
}
