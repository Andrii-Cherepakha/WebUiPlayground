// Instructions for the assistant (Copilot) — templates for code generation

// --- Playwright: Page template ---------------------------------------------
// Trigger: "Create Playwright page <Name>"
// Generate:
// - namespace: PlayWrightTests.PageObjects.UiTestingPlayground
// - class: <Name>Page : BasePage
// - constructor: public <Name>Page(IPage page) : base(page) {}
// - file path: PlayWrightTests/PageObjects/UiTestingPlayground/<Name>Page.cs
// Example:
// public class ExamplePage : BasePage
// {
//     public ExamplePage(IPage page) : base(page) { }
// }

// --- Playwright: Test template ---------------------------------------------
// Trigger: "Create Playwright test <Name>"
// Generate:
// - namespace: PlayWrightTests.TestCases.UiTestingPlayground
// - class: <Name>Tests : BaseTest
// - attributes: [Parallelizable(ParallelScope.Self)] [TestFixture]
// - one empty async test method: public async Task SomeTest()
// - file path: PlayWrightTests/TestCases/UiTestingPlayground/<Name>Tests.cs
// Example:
// [Parallelizable(ParallelScope.Self)]
// [TestFixture]
// public class ExampleTests : BaseTest
// {
//     [Test]
//     public async Task SomeTest() { }
// }

// --- Selenium: Page template ------------------------------------------------
// Trigger: "Create Selenium page <Name>"
// Generate:
// - namespace: SeleniumTests.PageObjects
// - class: <Name>Page : PageObject
// - constructor: public <Name>Page(IWebDriver driver) : base(driver) {}
// - file path: SeleniumTests/PageObjects/<Name>Page.cs
// Example:
// public class ExamplePage : PageObject
// {
//     public ExamplePage(IWebDriver driver) : base(driver) { }
// }

// --- Selenium: Test template ------------------------------------------------
// Trigger: "Create Selenium test <Name>"
// Generate:
// - namespace: SeleniumTests.TestCases
// - class: <Name>Tests : BaseTest
// - attribute: [TestFixture]
// - one empty sync test method: public void SomeTest()
// - file path: SeleniumTests/TestCases/<Name>Tests.cs
// Example:
// [TestFixture]
// public class ExampleTests : BaseTest
// {
//     [Test]
//     public void SomeTest() { }
// }