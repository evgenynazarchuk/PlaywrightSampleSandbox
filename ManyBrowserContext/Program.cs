using System;
using PlaywrightSharp;
using System.Threading.Tasks;
using System.Threading;
using System.Collections.Generic;

namespace ManyBrowserContext
{
    class Program
    {
        public static async Task GoLink(IBrowser browser, string url)
        {
            var context = await browser.NewContextAsync();
            var page = await context.NewPageAsync();
            page.DefaultTimeout = TimeSpan.FromMinutes(10).Milliseconds;

            var startTime = DateTime.Now;
            await page.GoToAsync(url);
            var endTime = DateTime.Now;
            var diffTime = endTime.Subtract(startTime);

            var result = $"{url}\t\t\t\t{diffTime}\t{startTime}\t{endTime}";
            Console.WriteLine(result);
        }

        static async Task Main(string[] args)
        {
            using var playwright = await Playwright.CreateAsync();
            await using var browser = await playwright.Chromium.LaunchAsync(headless: true);

            var countPage = Links.Urls.Length;
            var tasks = new Task[countPage];
            for (int i = 0; i < countPage; i++)
            {
                tasks[i] = GoLink(browser, Links.Urls[i]);
            }
            Task.WaitAll(tasks);
        }
    }
}
