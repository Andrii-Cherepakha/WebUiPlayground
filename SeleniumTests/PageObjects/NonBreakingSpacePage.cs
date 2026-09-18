using OpenQA.Selenium;
using SeleniumTests.Core;

namespace SeleniumTests.PageObjects
{
    public class NonBreakingSpacePage : PageObject
    {
        public NonBreakingSpacePage(IWebDriver driver) : base(driver)
        {
        }

        public IWebElement BtnNbsp => Context.GetElement(By.XPath("//button[text()='My Button']")); // <-- &nbsp; special character in the text
        public IWebElement BtnNormalized => Context.GetElement(By.XPath("//button[normalize-space(.)='My Button']"));

        /*
        
        text() selects only direct text node children of an element, not descendants
        Fails if: 
            There are leading / trailing spaces: " My Button " : <button>  My  Button  </button>
            The text is split into multiple nodes              : <button><span>My</span> Button</button>

        . as a string returns the string-value of the element, which is the concatenation of all descendant text nodes.
        Still requires an exact match, including spaces.

        normalize-space(.) Takes the string-value of the element (all descendant text). Trims leading/trailing whitespace.
        */

    }
}
