using Microsoft.Playwright;

namespace PlayWrightTests.PageObjects
{
    public abstract class BasePage
    {
        protected readonly IPage Page;
        public BasePage(IPage page)
        {
            Page = page;
        }
    }
}
