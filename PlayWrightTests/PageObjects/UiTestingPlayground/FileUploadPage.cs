using Microsoft.Playwright;

namespace PlayWrightTests.PageObjects.UiTestingPlayground
{
    public class FileUploadPage : BasePage
    {
        public FileUploadPage(IPage page) : base(page) { }

        private IFrameLocator UploadFrame => Page.FrameLocator("iframe[src='/static/upload.html']");

        private ILocator FileInfoItems => UploadFrame.Locator("div.file-list div.file-info");

        private ILocator FileInput => UploadFrame.Locator("input[type='file']");

        public async Task SetFilesAsync(string filePath)
        {
            await FileInput.SetInputFilesAsync(filePath);
        }

        public async Task<string?> GetSelectedFileName()
        {
            return await FileInput.GetAttributeAsync("value");
        }

        public async Task<IList<string>> GetFileNames()
        {
            IList<string> files = new List<string>();

            foreach (var item in await FileInfoItems.AllAsync())
            {
                files.Add(await item.TextContentAsync());
            }

            return files;
        }
    }
}
