# PlaywrightDemoCSharp
This repository contains a demo project for automating web interactions using Playwright with C#. It demonstrates how to set up a Playwright project, navigate to a webpage, and download a PDF file.

Prerequisites
Before you can run this project, ensure you have the following installed:

.NET SDK
Visual Studio or any preferred C# IDE
Node.js (required for Playwright)
Getting Started
Follow these steps to set up and run the project:

1. Clone the Repository
sh
Copy code
git clone https://github.com/durgaprbehera/PlaywrightDemoCSharp.git
cd PlaywrightDemoCSharp
2. Install Playwright
Install Playwright for .NET using the NuGet Package Manager. You can do this by running the following command in the Package Manager Console:

sh
Copy code
dotnet add package Microsoft.Playwright
3. Build the Project
Build the project to restore the NuGet packages:

sh
Copy code
dotnet build
4. Run the Project
Run the project using the following command:

sh
Copy code
dotnet run
This will execute the demo script that navigates to a webpage and downloads a PDF file.

Project Structure
Program.cs: The main file containing the script to automate the web interaction using Playwright.
Code Explanation
Here is a brief overview of what the script does:

Initialize Playwright and Browser: Creates an instance of Playwright and launches a Chromium browser with headless mode disabled.
Navigate to the Page: The browser navigates to a specified URL where the PDF link is located.
Handle File Download: Clicks the link to download the PDF and waits for the download to complete.
Save the File: Saves the downloaded PDF to the current directory.
Example Code
csharp
Copy code
using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.Playwright;

class Program
{
    static async Task Main(string[] args)
    {
        using var playwright = await Playwright.CreateAsync();
        await using var browser = await playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions { Headless = false });
        var context = await browser.NewContextAsync();
        var page = await context.NewPageAsync();

        // Navigate to the page with the PDF link
        await page.GotoAsync("https://example.com");

        // Handle file download
        var download = await page.RunAndWaitForDownloadAsync(async () =>
        {
            await page.ClickAsync("a#pdf-link"); // Replace with the actual selector for the PDF link
        });

        // Save the downloaded file
        var filePath = Path.Combine(Directory.GetCurrentDirectory(), "downloaded.pdf");
        await download.SaveAsAsync(filePath);

        Console.WriteLine($"PDF downloaded to: {filePath}");
    }
}
Contributing
Contributions are welcome! Please open an issue or submit a pull request for any improvements or bug fixes.

License
This project is licensed under the MIT License. See the LICENSE file for details.

Contact
For any questions or suggestions, feel free to reach out to me at your.email@example.com.

Happy coding! 🚀
