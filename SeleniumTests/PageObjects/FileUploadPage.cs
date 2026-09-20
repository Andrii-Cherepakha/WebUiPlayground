using OpenQA.Selenium;
using SeleniumTests.Core;

namespace SeleniumTests.PageObjects
{
    public class FileUploadPage : PageObject
    {
        public FileUploadPage(IWebDriver driver) : base(driver)
        {
        }

        private IWebElement UploadFrameElement => Context.GetElement(By.CssSelector("iframe[src='/static/upload.html']"));
        private IWebElement FileInput => Context.GetElement(By.CssSelector("input[type='file']"));

        public void SetFiles(string filePath)
        {
            Driver.SwitchTo().Frame(UploadFrameElement);
            FileInput.SendKeys(filePath);
            Driver.SwitchTo().DefaultContent();
        }

        public string? GetSelectedFileName()
        {
            Driver.SwitchTo().Frame(UploadFrameElement);
            var value = FileInput.GetAttribute("value");
            Driver.SwitchTo().DefaultContent();
            return value;
        }

        public IList<string> GetFileNames()
        {
            IList<string> files = new List<string>();
            Driver.SwitchTo().Frame(UploadFrameElement);
            var items = Context.GetElements(By.XPath("//div[@class='file-list']//div[@class='file-info']"));
            foreach (var item in items)
            {
                files.Add(item.Text);
            }
            Driver.SwitchTo().DefaultContent();
            return files;
        }
    }
}
