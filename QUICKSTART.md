# Quick Start Guide

## Initial Setup

### 1. Prerequisites

- .NET 8.0 or later
- Visual Studio Code or Visual Studio 2022
- PowerShell (for setup scripts on Windows)

### 2. Install Dependencies

```bash
# On Windows
dotnet restore
dotnet build

# Install Playwright browsers
dotnet tool install --global Microsoft.Playwright.CLI
playwright install
```

### 3. Configuration

Update [appsettings.json](appsettings.json) with your test environment:

```json
{
  "Application": {
    "BaseUrl": "https://your-app-url.com"
  }
}
```

## Running Tests

### Run All Tests

```bash
dotnet test
```

### Run Specific Test Class

```bash
dotnet test --filter "TestClass=PlaywrightTests.Tests.LoginTests"
```

### Run with Verbose Output

```bash
dotnet test --verbosity detailed
```

### Run in Headless Mode (Default)

Already configured in [appsettings.json](appsettings.json)

### Run in Headed Mode

Change `appsettings.json`:

```json
"Playwright": {
  "Headless": false
}
```

## Creating Your First Test

### Step 1: Identify Page Elements

Open your application in a browser and inspect the HTML elements you want to interact with.

### Step 2: Create a Page Object

1. Create interface: `Pages/IMyPage.cs`
2. Create implementation: `Pages/MyPage.cs`
3. Extend `BasePage` class
4. Add methods for your interactions

Example:

```csharp
public interface IMyPage
{
    Task ClickButtonAsync();
    Task<string> GetMessageAsync();
}

public class MyPage : BasePage, IMyPage
{
    private const string ButtonSelector = "#my-button";
    private const string MessageSelector = ".message";

    public MyPage(IPage page) : base(page) { }

    public async Task ClickButtonAsync()
    {
        await ClickAsync(ButtonSelector);
    }

    public async Task<string> GetMessageAsync()
    {
        return await GetTextAsync(MessageSelector);
    }
}
```

### Step 3: Create a Test

Create `Tests/MyTests.cs`:

```csharp
[TestFixture]
public class MyTests : BaseTest
{
    private IMyPage _myPage;

    [SetUp]
    public new async Task SetUp()
    {
        await base.SetUp();
        await BrowserManager.Page.GotoAsync("https://your-app-url.com");
        _myPage = new MyPage(BrowserManager.Page);
    }

    [Test]
    public async Task MyTest_ShouldPass()
    {
        // Arrange
        // Act
        await _myPage.ClickButtonAsync();

        // Assert
        var message = await _myPage.GetMessageAsync();
        Assert.That(message, Is.EqualTo("Expected Message"));
    }
}
```

## Folder Structure Reference

- **Pages/**: Page object definitions
- **Tests/**: Test classes
- **Drivers/**: Browser management and base page class
- **Config/**: Configuration settings
- **Utilities/**: Helper classes for logging, waiting, screenshots
- **Data/**: Test data and models
- **Reports/**: Logs, screenshots, and test results

## Useful Commands

```bash
# List available tests
dotnet test --list-tests

# Run with specific logger
dotnet test --logger "console;verbosity=detailed"

# Generate test results XML
dotnet test --logger "trx;LogFileName=TestResults.trx"

# Run with filter
dotnet test --filter "Name~Login"
```

## Debugging

### View Logs

Check `Reports/Logs/` for detailed execution logs.

### Capture Screenshots

Automatically captured on test failure in `Reports/Screenshots/`.

### Enable Debug Output

Set log level in [appsettings.json](appsettings.json):

```json
"Logging": {
  "LogLevel": "Debug"
}
```

## Common Issues

### Browser Not Found

Install browsers:

```bash
playwright install
```

### Timeout Issues

Increase timeouts in [appsettings.json](appsettings.json):

```json
"Playwright": {
  "Timeout": 60000,
  "NavigationTimeout": 60000
}
```

### Element Not Found

- Verify selector is correct using browser DevTools
- Wait for element: `await page.WaitForSelectorAsync(selector)`
- Use explicit waits: `await WaitHelpers.WaitUntilAsync(...)`

## Next Steps

1. ✅ Review the example page objects and tests
2. ✅ Update selectors for your application
3. ✅ Add more page objects as needed
4. ✅ Create comprehensive test suite
5. ✅ Set up CI/CD integration
6. ✅ Configure parallel test execution

## Resources

- [Playwright Documentation](https://playwright.dev/dotnet/)
- [NUnit Documentation](https://docs.nunit.org/)
- [Best Practices](../README.md)
- [Page Object Model Pattern](https://www.selenium.dev/documentation/test_practices/encouraged/page_object_models/)
