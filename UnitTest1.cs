using Microsoft.Playwright;
using PlaywrightDemoCSharp.Pages;
using System.IO;
using System.Reflection;

namespace PlaywrightDemoCSharp;

public class Tests
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public async Task Test1()
    {
        //Playwright
        using var playwright = await Playwright.CreateAsync();
        //Browser
        await using var browser = await playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions
        {
            Headless = false
        });

        // Create a new incognito browser context
        var context = await browser.NewContextAsync();

        // Open a new page within the incognito context
        var page = await context.NewPageAsync();

        await page.GotoAsync("https://snapdeal.com/");

        var loginPage = new LoginPage(page);

        await loginPage.ClickLogin();

        await loginPage.Login("admin","");

        var isExist = await loginPage.VerifyLogin();
        Assert.IsTrue(isExist);
    }
}