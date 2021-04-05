using System;
using PlaywrightSharp;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GoEmulateNetworkConditions
{
    class Program
    {
        static async Task Main(string[] args)
        {
            using var playwright = await Playwright.CreateAsync();
            await using var browser = await playwright.Chromium.LaunchAsync(headless: true);

            // dont work
            //var client = await browser.NewBrowserCDPSessionAsync();
            //await client.SendAsync("network.EmulateNetworkConditions", new Dictionary<string, string>()
            //{
            //    ["offile"] = "true"
            //});
        }
    }
}
