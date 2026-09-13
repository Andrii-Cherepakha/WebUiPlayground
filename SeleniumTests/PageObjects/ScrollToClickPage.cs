using OpenQA.Selenium;
using SeleniumTests.Core;

namespace SeleniumTests.PageObjects
{
    public class ScrollToClickPage : PageObject
    {
        public ScrollToClickPage(IWebDriver driver) : base(driver)
        {
        }
        public IWebElement Btn1 => Context.GetElement(By.Id("scrollTarget1")); // Page Scroll
        public IWebElement Btn2 => Context.GetElement(By.Id("scrollTarget2")); // Container Scroll
        public IWebElement Btn3 => Context.GetElement(By.Id("scrollTarget3")); // Nested Scroll (Parent + Child)
        public IWebElement HoverRow4 => Context.GetElement(By.Id("targetRow4")); // Hover to Reveal
        public IWebElement Btn4 => Context.GetElement(By.Id("scrollTarget4"));
        public IWebElement ProgressText => Context.GetElement(By.Id("progressText"));
    }
}
