using Microsoft.Playwright;
using PlaywrightTests.Config;
using Serilog;

namespace PlaywrightTests.Drivers;

public class BrowserManager : IAsyncDisposable
{
    private readonly ConfigurationManager _configManager;
    private IPlaywright? _playwright;
    private IBrowser? _browser;
    private IBrowserContext? _context;
    private IPage? _page;

    public IPage Page => _page ?? throw new InvalidOperationException("Page not initialized");
    public IBrowser Browser => _browser ?? throw new InvalidOperationException("Browser not initialized");

    public BrowserManager()
    {
        _configManager = new ConfigurationManager();
    }

    public async Task InitializeBrowserAsync()
    {
        try
        {
            _playwright = await Playwright.CreateAsync();
            
            var settings = _configManager.PlaywrightSettings;
            _browser = settings.BrowserType.ToLower() switch
            {
                "chromium" => await _playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions 
                { 
                    Headless = settings.Headless,
                    SlowMo = settings.SlowMo 
                }),
                "firefox" => await _playwright.Firefox.LaunchAsync(new BrowserTypeLaunchOptions 
                { 
                    Headless = settings.Headless,
                    SlowMo = settings.SlowMo 
                }),
                "webkit" => await _playwright.Webkit.LaunchAsync(new BrowserTypeLaunchOptions 
                { 
                    Headless = settings.Headless,
                    SlowMo = settings.SlowMo 
                }),
                _ => throw new ArgumentException($"Unsupported browser type: {settings.BrowserType}")
            };

            _context = await _browser.NewContextAsync();
            _page = await _context.NewPageAsync();
            
            // Set default timeouts
            _page.SetDefaultTimeout(settings.Timeout);
            _page.SetDefaultNavigationTimeout(settings.NavigationTimeout);

            Log.Information($"Browser {settings.BrowserType} initialized successfully");
        }
        catch (Exception ex)
        {
            Log.Error(ex, "Failed to initialize browser");
            throw;
        }
    }

    public async ValueTask DisposeAsync()
    {
        try
        {
            if (_context != null)
                await _context.CloseAsync();
            
            if (_browser != null)
                await _browser.CloseAsync();
            
            _playwright?.Dispose();
            
            Log.Information("Browser closed successfully");
        }
        catch (Exception ex)
        {
            Log.Error(ex, "Error closing browser");
        }
    }
}
