using NUnit.Framework;
using PlayWrightTests.PageObjects.UiTestingPlayground;

namespace PlayWrightTests.TestCases.UiTestingPlayground
{
    [Parallelizable(ParallelScope.Self)]
    [TestFixture]
    public class FileUploadTests : BaseTest
    {
        [Test]
        public async Task FileUploadTest()
        {
            var homePage = GetPage<HomePage>();
            await homePage.OpenAsync();
            await homePage.OpenSectionAsync("File Upload");

            var fileUploadPage = GetPage<FileUploadPage>();

            var tmp = Path.Combine(Path.GetTempPath(), $"pw-upload-{Guid.NewGuid()}.txt");
            File.WriteAllText(tmp, "playwright upload test");

            await fileUploadPage.SetFilesAsync(tmp);

            // Assert.That(await fileUploadPage.GetSelectedFileName(), Is.Not.Null.And.Contains(Path.GetFileName(tmp)));
            Assert.That(await fileUploadPage.GetFileNames(), Does.Contain(Path.GetFileName(tmp)));

            if (File.Exists(tmp)) File.Delete(tmp);
        }
    }
}
