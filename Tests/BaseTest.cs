using Microsoft.Playwright;
using NUnit.Framework;
using PlaywrightTests.Drivers;
using PlaywrightTests.Utilities;

namespace PlaywrightTests.Tests;

[TestFixture]
public abstract class BaseTest
{
    protected BrowserManager BrowserManager = null!;
    protected ScreenshotHelper ScreenshotHelper = null!;

    [SetUp]
    public async Task SetUp()
    {
        LoggerSetup.ConfigureLogging();
        
        BrowserManager = new BrowserManager();
        await BrowserManager.InitializeBrowserAsync();
        
        ScreenshotHelper = new ScreenshotHelper(BrowserManager);
    }

    [TearDown]
    public async Task TearDown()
    {
        if (TestContext.CurrentContext.Result.Outcome.Status == NUnit.Framework.Interfaces.TestStatus.Failed)
        {
            await ScreenshotHelper.CaptureScreenshotAsync(TestContext.CurrentContext.Test.Name);
        }

        await BrowserManager.DisposeAsync();
        LoggerSetup.CloseAndFlush();
    }

    protected Task<T> GetPageAsync<T>(Func<IPage, T> pageFactory) where T : class
    {
        return Task.FromResult(pageFactory(BrowserManager.Page));
    }
}
