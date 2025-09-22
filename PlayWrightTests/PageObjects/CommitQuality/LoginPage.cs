using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Playwright;

namespace PlayWrightTests.PageObjects.CommitQuality
{
    public class LoginPage : BasePage
    {
        public LoginPage(IPage page) : base(page)
        {
        }

        private ILocator UserName => Page.GetByTestId("username-textbox");
        private ILocator Password => Page.GetByTestId("password-textbox");
        private ILocator LoginBtn => Page.GetByTestId("login-button");

        public async Task Open()
        {
            await Page.GotoAsync("https://commitquality.com/login");
        }

        public async Task Login(string userName, string password)
        {
            await UserName.FillAsync(userName);
            await Password.FillAsync(password);
            await LoginBtn.ClickAsync();
        }
    }
}
