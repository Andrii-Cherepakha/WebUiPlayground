using NUnit.Framework;
using PlayWrightTests.PageObjects.UiTestingPlayground;

namespace PlayWrightTests.TestCases.UiTestingPlayground
{
    [Parallelizable(ParallelScope.Self)]
    [TestFixture]
    public class AlertsTests : BaseTest
    {
        private AlertsPage alertsPage;

        [SetUp]
        public async Task SetUp()
        {
            var homePage = GetPage<HomePage>();
            await homePage.OpenAsync();
            await homePage.OpenSectionAsync("Alerts");
            alertsPage = GetPage<AlertsPage>();
        }

        [Test]
        public async Task AlertTest()
        {
            alertsPage.OnDialog(async (_, dialog) =>
            {
                Assert.That(dialog.Message, Contains.Substring("Today is a working day."));
                await dialog.AcceptAsync();
            });

            await alertsPage.AlertButton.ClickAsync();
        }

        [Test]
        public async Task ConfirmTest()
        {
            int dialogCount = 0;

            alertsPage.OnDialog(async (_, dialog) =>
            {
                dialogCount++;

                Console.WriteLine($"Dialog #{dialogCount}: {dialog.Type} – {dialog.Message}");

                if (dialogCount == 1)
                {
                    Assert.That(dialog.Message, Contains.Substring("Do you agree?"));
                }
                else if (dialogCount == 2)
                {
                    Assert.That(dialog.Message, Contains.Substring("Yes"));
                }

                await dialog.AcceptAsync();
            });

            await alertsPage.ConfirmButton.ClickAsync();
            await alertsPage.WaitForDialogAsync(); // Wait for the second dialog to appear
            Assert.That(dialogCount, Is.EqualTo(2), "Expected 2 dialogs to be handled.");
        }

        [Test]
        public async Task PromptTest()
        {
            int dialogCount = 0;
            string promptText = "John Doe";

            alertsPage.OnDialog(async (_, dialog) =>
            {
                dialogCount++;

                Console.WriteLine($"Dialog #{dialogCount}: {dialog.Type} – {dialog.Message}");

                if (dialogCount == 1)
                {
                    await dialog.AcceptAsync(promptText);
                }
                else if (dialogCount == 2)
                {
                    Assert.That(dialog.Message, Contains.Substring(promptText));
                    await dialog.AcceptAsync();
                }                
            });

            await alertsPage.PromptButton.ClickAsync();
            await alertsPage.WaitForDialogAsync(); // Wait for the second dialog to appear
            Assert.That(dialogCount, Is.EqualTo(2), "Expected 2 dialogs to be handled.");
        }
    }
}
