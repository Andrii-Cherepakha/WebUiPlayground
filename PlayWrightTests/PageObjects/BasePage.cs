using System.Text.RegularExpressions;
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

        protected ILocator GetButton(string text) => Page.GetByRole(AriaRole.Button, new()
        {
            NameRegex = new Regex(text, RegexOptions.IgnoreCase)
        });
    }
}
