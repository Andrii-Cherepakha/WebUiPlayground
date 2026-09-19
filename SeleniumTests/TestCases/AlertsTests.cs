using NUnit.Framework;
using SeleniumTests.PageObjects;

namespace SeleniumTests.TestCases
{
    [TestFixture]
    public class AlertsTests : BaseTest
    {
        private AlertsPage alertsPage;
        
        [SetUp]
        public void SetUp()
        {
            var homePage = GetPage<HomePage>();
            homePage.Open();
            homePage.OpenSection("Alerts");
            alertsPage = GetPage<AlertsPage>();
        }

        [Test]
        public void AlertTest()
        {
            alertsPage.AlertButton.Click();

            var alert = Alert.SwitchToAlert();
            Assert.That(alert, Is.Not.Null, "Alert was not present");
            Assert.That(alert.Text, Contains.Substring("Today is a working day."));
            alert.Accept();
        }

        [Test]
        public void ConfirmTest()
        {
            alertsPage.ConfirmButton.Click();

            var alert = Alert.SwitchToAlert();
            Assert.That(alert, Is.Not.Null, "Alert was not present");
            Assert.That(alert.Text, Contains.Substring("Do you agree?"));
            alert.Accept();

            alert = Alert.SwitchToAlert();
            Assert.That(alert, Is.Not.Null, "Alert was not present");
            Assert.That(alert.Text, Contains.Substring("Yes"));
            alert.Accept();
        }

        [Test]
        public void PromptTest()
        {
            alertsPage.PromptButton.Click();

            var alert = Alert.SwitchToAlert();
            Assert.That(alert, Is.Not.Null, "Alert was not present");

            string promptText = "John Doe";
            alert.SendKeys(promptText);
            alert.Accept();

            alert = Alert.SwitchToAlert(); 
            Assert.That(alert, Is.Not.Null, "Alert was not present");
            Assert.That(alert.Text, Contains.Substring(promptText));
            alert.Accept();
        }
    }
}
