using PlaywrightTests.Drivers;

namespace PlaywrightTests.Utilities;

public class ScreenshotHelper
{
    private readonly BrowserManager _browserManager;
    private readonly string _screenshotPath;

    public ScreenshotHelper(BrowserManager browserManager, string screenshotPath = "Reports/Screenshots")
    {
        _browserManager = browserManager ?? throw new ArgumentNullException(nameof(browserManager));
        _screenshotPath = screenshotPath;

        if (!Directory.Exists(_screenshotPath))
            Directory.CreateDirectory(_screenshotPath);
    }

    public async Task CaptureScreenshotAsync(string testName)
    {
        var timestamp = DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss-fff");
        var filename = Path.Combine(_screenshotPath, $"{testName}_{timestamp}.png");
        
        await _browserManager.Page.ScreenshotAsync(new()
        {
            Path = filename
        });

        Serilog.Log.Information($"Screenshot saved: {filename}");
    }

    public async Task CaptureScreenshotAsync(string testName, string elementSelector)
    {
        var element = await _browserManager.Page.QuerySelectorAsync(elementSelector);
        if (element != null)
        {
            var timestamp = DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss-fff");
            var filename = Path.Combine(_screenshotPath, $"{testName}_element_{timestamp}.png");
            
            await element.ScreenshotAsync(new()
            {
                Path = filename
            });

            Serilog.Log.Information($"Element screenshot saved: {filename}");
        }
    }
}
