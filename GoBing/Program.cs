using System.Threading.Tasks;
using PlaywrightSharp;

namespace GoBing
{
    class Program
    {
        public static async Task Main(string[] args)
        {
            using var playwright = await Playwright.CreateAsync();
            await using var browser = await playwright.Chromium.LaunchAsync(headless: false);
            var page = await browser.NewPageAsync();
            await page.GoToAsync("https://www.bing.com");
            await page.ScreenshotAsync(path: "GoBind.png");
        }
    }
}
