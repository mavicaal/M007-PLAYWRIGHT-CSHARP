using Microsoft.Playwright;
using Serilog;

namespace PlaywrightTests.Drivers;

public abstract class BasePage
{
    protected readonly IPage Page;
    protected readonly ILogger Logger;

    protected BasePage(IPage page)
    {
        Page = page ?? throw new ArgumentNullException(nameof(page));
        Logger = Log.Logger;
    }

    protected async Task GotoAsync(string url)
    {
        Logger.Information($"Navigating to: {url}");
        await Page.GotoAsync(url);
    }

    protected async Task<List<string>> GetAllTextAsync(string selector)
    {
        Logger.Information($"Getting all text from elements: {selector}");
        var elements = await Page.QuerySelectorAllAsync(selector);
        var textList = new List<string>();

        foreach (var element in elements)
        {
            var text = await element.TextContentAsync();
            if (!string.IsNullOrEmpty(text))
                textList.Add(text);
        }

        return textList;
    }

    protected async Task WaitForLoadStateAsync(LoadState state = LoadState.NetworkIdle)
    {
        Logger.Information($"Waiting for load state: {state}");
        await Page.WaitForLoadStateAsync(state);
    }
    // Locator helper methods for common elements
    protected ILocator GetLinkLocator(string linkName)
    {
        Logger.Information($"Getting link locator: {linkName}");
        return Page.GetByRole(AriaRole.Link, new() { Name = linkName });
    }

    protected ILocator GetHeadingLocator(string headingName)
    {
        Logger.Information($"Getting heading locator: {headingName}");
        return Page.GetByRole(AriaRole.Heading, new() { Name = headingName });
    }

    protected ILocator GetButtonLocator(string buttonName)
    {
        Logger.Information($"Getting button locator: {buttonName}");
        return Page.GetByRole(AriaRole.Button, new() { Name = buttonName });
    }

    protected ILocator GetTextboxLocator(string textboxName)
    {
        Logger.Information($"Getting textbox locator: {textboxName}");
        return Page.GetByRole(AriaRole.Textbox, new() { Name = textboxName });
    }
}
