using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using PlaywrightSharp;

namespace GoCheckCache
{
    class Program
    {
        static async Task Main(string[] args)
        {
            using var playwright = await Playwright.CreateAsync();
            await using var browser = await playwright.Chromium.LaunchAsync(headless: true);
            var context = await browser.NewContextAsync();
            var page = await context.NewPageAsync();

            DateTime startTime;
            DateTime endTime;
            TimeSpan diffTime;
            string result;

            for (int i = 0; i < 10; i++)
            {
                startTime = DateTime.Now;
                await page.GoToAsync("https://www.google.com");
                endTime = DateTime.Now;
                diffTime = endTime.Subtract(startTime);
                result = $"google\t\t\t\t{diffTime}\t{startTime}\t{endTime}";
                Console.WriteLine(result);
            }
        }
    }
}
