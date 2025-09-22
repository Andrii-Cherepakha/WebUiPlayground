using Microsoft.Playwright.NUnit;
using PlayWrightTests.PageObjects;

namespace PlayWrightTests.TestCases
{
    public abstract class BaseTest : PageTest
    {
        protected T? GetPage<T>() where T : BasePage => Activator.CreateInstance(typeof(T), Page) as T;
    }
}
