using Microsoft.Playwright;

namespace PlayWrightTests.PageObjects.UiTestingPlayground
{
    internal class NonBreakingSpacePage : BasePage
    {
        public NonBreakingSpacePage(IPage page) : base(page) { }

        public ILocator BtnNbsp => Page.Locator("//button[text()='My Button']"); // <-- &nbsp; special character in the text
        public ILocator BtnNormalized => Page.Locator("//button[normalize-space(.)='My Button']");
        public ILocator BtnNbspByText => Page.GetByRole(AriaRole.Button, new () { Name = "My Button" }); // <-- No &nbsp; special character in the text
    }
}
