using Microsoft.Playwright;
using NUnit.Framework;
using PlayWrightTests.PageObjects.CommitQuality;

namespace PlayWrightTests.TestCases.CommitQuality
{
    //[SetUpFixture]
    public class CommitQualityLogedBaseTest
    {
        public IPlaywright Playwright { get; set; }
        public IBrowser Browser { get; set; }

        public IPage Page { get; set; }

        [OneTimeSetUp]
        public async Task Login()
        {
            Playwright = await Microsoft.Playwright.Playwright.CreateAsync();
            Browser = await Playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions { Headless = false });
            var context = await Browser.NewContextAsync();
            Page = await context.NewPageAsync();

            var loginPage = new LoginPage(Page);
            await loginPage.Open();
            await loginPage.Login("test", "test");

            await context.StorageStateAsync(new()
            {
                Path = StorageStatePath
            });

            // makes sense if the method defined in a separate class
            //await Page.CloseAsync();
            //await Browser.CloseAsync();
        }

        [SetUp]
        public async Task Setup()
        {
            //var context = await Browser.NewContextAsync(new()
            //{
            //    StorageStatePath = StorageStatePath
            //});
        }

        [TearDown]
        public async Task TearDown()
        {
            // makes sense if the method defined in a separate class
            //await Page.CloseAsync();
            //await Browser.CloseAsync();            
        }

        private string StorageStatePath => Path.Combine(Directory.GetCurrentDirectory(), "state.json");
    }
}
