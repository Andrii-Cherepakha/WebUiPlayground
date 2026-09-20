using NUnit.Framework;
using SeleniumTests.PageObjects;

namespace SeleniumTests.TestCases
{
    [TestFixture]
    public class FileUploadTests : BaseTest
    {
        private FileUploadPage fileUploadPage;

        [SetUp]
        public void SetUp()
        {
            var homePage = GetPage<HomePage>();
            homePage.Open();
            homePage.OpenSection("File Upload");
            fileUploadPage = GetPage<FileUploadPage>();
        }

        [Test]
        public void UploadFileTest()
        {
            var tmp = Path.Combine(Path.GetTempPath(), $"upload-test-{Guid.NewGuid()}.txt");
            File.WriteAllText(tmp, "test content");

            fileUploadPage.SetFiles(tmp);

            Assert.That(fileUploadPage.GetSelectedFileName(), Is.Not.Null.And.Contains(Path.GetFileName(tmp)));
            Assert.That(fileUploadPage.GetFileNames(), Does.Contain(Path.GetFileName(tmp)));

            if (File.Exists(tmp)) File.Delete(tmp);
        }
    }
}
