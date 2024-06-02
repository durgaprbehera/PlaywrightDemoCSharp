using Microsoft.Playwright;
using Microsoft.Playwright.NUnit;
using PlaywrightDemoCSharp.Pages;
using System;
using System.IO;
using System.Reflection;

namespace PlaywrightDemoCSharp;

public class PDFTest : PageTest
{
    [SetUp]
    public async Task SetupAsync()
    {
        await Page.GotoAsync("http://www.pdf995.com/samples/");
    }

    [Test]
    public async Task UsingWaitForDownloadAsync()
    {
        // Start the task of waiting for the download before clicking
        var waitForDownloadTask = Page.WaitForDownloadAsync();
        await Page.Locator("td[data-sort='pdf.pdf'] a").ClickAsync();
        var download = await waitForDownloadTask;

        // Wait for the download process to complete and save the downloaded file somewhere
        await download.SaveAsAsync("./" + download.SuggestedFilename);
    }

    [Test]
    public async Task UsingRunAndWaitForDownloadAsync()
    {
        var download = await Page.RunAndWaitForDownloadAsync(async () => { await Page.Locator("td[data-sort='pdfeditsample.pdf'] a").ClickAsync(); }, new PageRunAndWaitForDownloadOptions() { Timeout = 10000 });

        //Prints the download url (here output => http://www.pdf995.com/samples/pdfeditsample.pdf )
        Console.WriteLine(download.Url);

        //Prints the Result for Path (here ouput => C:\Users\****\AppData\Local\Temp\playwright-artifacts-XXXXXXiFNm4w\867a5d45-3883-427c-bce5-dc086bc067c1)
        Console.WriteLine(download.PathAsync().Result);

        //Prints the Status for the Failure (here output => WaitingForActivation)
        Console.WriteLine(download.FailureAsync().Status);

        // Wait for the download process to complete and save the downloaded file somewhere
        await download.SaveAsAsync("./" + download.SuggestedFilename);
    }

}