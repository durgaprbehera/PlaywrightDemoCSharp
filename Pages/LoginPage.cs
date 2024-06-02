using Microsoft.Playwright;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlaywrightDemoCSharp.Pages
{
    public class LoginPage
    {
        private readonly IPage _page;

        public LoginPage(IPage page)
        {
            _page = page;
        }

        private ILocator SignInButton => _page.Locator("//div[@class='accountInner']/span[contains(text(),'Sign In')]");
        private ILocator LoginLink => _page.Locator("//a[contains(@href,'/login')]");
        private ILocator YourAccountLink => _page.Locator("//a[contains(@href,'/myorders')][contains(text(),'Your Account')]");
        private ILocator UserNameTextBox => _page.Locator("input[id='userName']");
        private ILocator ContinueButton => _page.Locator("#checkUser");
        private ILocator UsernameError => _page.Locator("#userName-error");

        /**
         * Click on the Login link to open Login page.
         */
        public async Task ClickLogin()
        {
            await SignInButton.ClickAsync();
            await LoginLink.ClickAsync();
            await YourAccountLink.ClickAsync();
        }

        public async Task Login(string Username, string Password)
        {
            await UserNameTextBox.FillAsync(Username);
            await ContinueButton.ClickAsync();
        }

        public async Task<bool> VerifyLogin()
        {
            return await UsernameError.IsVisibleAsync();
        }

    }
       
}
