using Microsoft.Playwright;


namespace PlayWrightTests.PageObjects.UiTestingPlayground
{
    public class OverlappedElementPage : BasePage
    {
        public OverlappedElementPage(IPage page) : base(page)  {}
        public ILocator IdTextBox => Page.Locator("#id");
        public ILocator NameTextBox => Page.Locator("#name");
        public ILocator SubjectTextBox => Page.Locator("#subject");
    }
}
