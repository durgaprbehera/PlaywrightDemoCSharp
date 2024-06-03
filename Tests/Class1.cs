using Microsoft.Playwright;
using PlaywrightDemoCSharp.Pages;
using System.IO;
using System.Reflection;

namespace PlaywrightDemoCSharp.Tests;

public class Tests1
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public async Task VerifyCSS()
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

        await page.GotoAsync("https://selectors.webdriveruniversity.com/");

        var isExist = await page.Locator("td:has-text(\"Thornton\")").IsVisibleAsync(new() { Timeout = 10_000 });
        Assert.IsTrue(isExist);

        var string1 = "the Bird";
        var string2 = "Larry";

        var loc = page.Locator("tr").Filter(new() { HasText = string1 }).
            Filter(new() { HasText = string2 });

        await loc.WaitForAsync(new() { Timeout = 1000 });

        var loc1 = loc.Locator("td:nth-child(4)");

        Console.WriteLine("With td:nth-child:: " + await loc1.TextContentAsync());

        foreach (var li in await loc1.AllTextContentsAsync())
        {
            Console.WriteLine("::::: " + li);
        }

        foreach (var li in await page.Locator("//tr").Filter(new() { HasText = "Thornton" }).
            Filter(new() { HasText = "Jacob" }).AllTextContentsAsync())
        {
            Console.WriteLine("Test: " + li);
        }

        Console.WriteLine(await page.Locator("table[class*=table] th").AllAsync());

        foreach (var li in await page.Locator("table[class*=table] th").AllAsync())
        {
            Console.WriteLine(li.ScrollIntoViewIfNeededAsync());
            //await page.WaitForTimeoutAsync(5000);
        }

        foreach (var li in await page.Locator("h2+table[class*='table table'] th[scope=col]").AllTextContentsAsync())
        {
            Console.WriteLine(li + ": " + li.Equals("Last"));
        }

    }

    [Test]
    public async Task VerifyListGroup()
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

        await page.GotoAsync("https://selectors.webdriveruniversity.com/");

        var isExist = await page.Locator("td:has-text(\"Thornton\")").IsVisibleAsync();
        Assert.IsTrue(isExist);

        var text1 = await page.Locator("li").Filter(new() { HasText = "Web Development" }).Locator("span").TextContentAsync();
        Console.WriteLine(text1);

        var text2 = await page.Locator("li").Filter(new() { HasText = "Data Science" }).Locator("span").TextContentAsync();
        Console.WriteLine(text2);

        var text3 = await page.Locator("li").Filter(new() { HasText = "Programming Languages" }).Locator("span").TextContentAsync();
        Console.WriteLine(text3);

    }

    [Test]
    public async Task VerifyListGroup1()
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

        await page.GotoAsync("https://selectors.webdriveruniversity.com/");

        var isExist = await page.Locator("td:has-text(\"Thornton\")").IsVisibleAsync();
        Assert.IsTrue(isExist);

        var text1 = await page.Locator("ul[class*='traversal-drinks-list']>li").AllTextContentsAsync();

        foreach (var item in text1)
        {
            Console.WriteLine(item);
        }

        Console.WriteLine("-------------------------------------------");

        var text2 = await page.Locator("ul[class*='traversal-food-list']>li").AllTextContentsAsync();

        foreach (var item in text2)
        {
            Console.WriteLine(item);
        }

        Console.WriteLine("-------------------------------------------");

        var text3 = await page.Locator("ul[class*='traversal-job-list']>li+ul>li").AllTextContentsAsync();

        foreach (var item in text3)
        {
            Console.WriteLine(item);
        }
    }

    [Test]
    public async Task VerifyGetAttribute()
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

        await page.GotoAsync("https://selectors.webdriveruniversity.com/");

        var isExist = await page.Locator("td:has-text(\"Thornton\")").IsVisibleAsync();
        Assert.IsTrue(isExist);

        var text = await page.Locator("ul[class*='traversal-job-list']>li+ul").GetAttributeAsync("class");
        Console.WriteLine(text);
    }
}