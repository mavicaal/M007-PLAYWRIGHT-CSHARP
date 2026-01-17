# Welcome to M007-PLAYWRIGHT-CSHARP

## 🎯 What You Have

A **production-ready, best practice test automation framework** using Microsoft Playwright and C# with the **Page Object Model (POM)** pattern.

This is a fully scaffolded project with:

- ✅ Complete folder structure
- ✅ Base classes for extension
- ✅ Example page objects and tests
- ✅ Configuration management
- ✅ Logging and reporting
- ✅ Comprehensive documentation

## 📚 Documentation

Start here based on your needs:

### For New Users

1. **[QUICKSTART.md](QUICKSTART.md)** - Get up and running in 5 minutes
   - Initial setup instructions
   - How to run tests
   - Creating your first test

### For Understanding Architecture

2. **[ARCHITECTURE.md](ARCHITECTURE.md)** - Visual diagrams and flows
   - Project architecture diagram
   - Test execution flow
   - Page Object Model pattern
   - Data and configuration flows
   - Class hierarchies

### For Project Structure

3. **[STRUCTURE.md](STRUCTURE.md)** - Detailed breakdown
   - Complete directory structure with descriptions
   - Component overview
   - Technologies and dependencies
   - Best practices checklist
   - Getting started guide

## 🗂️ Folder Guide

| Folder         | Purpose            | Contains                                                  |
| -------------- | ------------------ | --------------------------------------------------------- |
| **Pages/**     | Page Object Models | `ILoginPage.cs`, `LoginPage.cs`, etc.                     |
| **Tests/**     | Test Classes       | `BaseTest.cs`, `LoginTests.cs`, etc.                      |
| **Drivers/**   | Browser Management | `BrowserManager.cs`, `BasePage.cs`                        |
| **Config/**    | Configuration      | `ConfigurationManager.cs`, settings classes               |
| **Utilities/** | Helper Classes     | `LoggerSetup.cs`, `WaitHelpers.cs`, `ScreenshotHelper.cs` |
| **Data/**      | Test Data          | `TestDataProvider.cs`, model classes                      |
| **Reports/**   | Generated Reports  | Logs, screenshots, test results                           |

## 🚀 Quick Start

**[QUICKSTART.md](QUICKSTART.md)** - Detailed breakdown

## 📖 Key Concepts

### Page Object Model (POM)

The framework uses the Page Object Model pattern to:

- Encapsulate page elements and interactions
- Separate test logic from page structure
- Improve maintainability
- Reduce code duplication

**Example:**

```csharp
// Interface defines contract
public interface ILoginPage
{
    Task LoginAsync(string username, string password);
}

// Implementation encapsulates selectors
public class LoginPage : BasePage, ILoginPage
{
    private const string UsernameSelector = "#username";
    private const string PasswordSelector = "#password";
    private const string LoginButtonSelector = "button[type='submit']";

    public async Task LoginAsync(string username, string password)
    {
        await FillAsync(UsernameSelector, username);
        await FillAsync(PasswordSelector, password);
        await ClickAsync(LoginButtonSelector);
    }
}

// Test uses high-level methods
[Test]
public async Task Login_WithValidCredentials_ShouldSucceed()
{
    await _loginPage.LoginAsync("user", "password");
    // Assert results
}
```

### Base Classes

- **BasePage**: All page objects inherit this
  - Common interaction methods (Click, Fill, GetText, etc.)
  - Built-in logging
  - Wait mechanisms

- **BaseTest**: All test classes inherit this
  - Automatic browser initialization
  - Screenshot on failure
  - Proper setup/teardown

### Configuration Management

- Externalized settings in `appsettings.json`
- Type-safe configuration objects
- Support for multiple environments

### Logging & Reporting

- Serilog for structured logging
- Automatic screenshots on test failure
- Daily log files with retention policy

### External Resources

- [Playwright Documentation](https://playwright.dev/dotnet/)
- [NUnit Documentation](https://docs.nunit.org/)
- [Page Object Model Pattern](https://www.selenium.dev/documentation/test_practices/encouraged/page_object_models/)
- [Serilog Documentation](https://serilog.net/)

## ✅ What's Included

### Core Framework

- [x] Multi-browser support (Chromium, Firefox, WebKit)
- [x] Page Object Model pattern
- [x] Base classes for extension
- [x] Configuration management
- [x] Structured logging
- [x] Screenshot capture on failure
- [x] Custom wait helpers
- [x] Test data provider

### Example Implementations

- [x] Login page object and tests
- [x] Home page object and tests
- [x] Test data models
- [x] Utility helpers

### Documentation

- [x] Architecture diagrams
- [x] Quick start guide
- [x] Comprehensive README
- [x] Folder-specific READMEs
- [x] Setup instructions
- [x] Best practices guide

### Configuration Files

- [x] appsettings.json for environment config
- [x] .runsettings for test runner config
- [x] .gitignore for version control
- [x] PlaywrightTests.csproj with dependencies

## 📊 Next Steps

1. **Read** [QUICKSTART.md](QUICKSTART.md) for immediate setup
2. **Review** [ARCHITECTURE.md](ARCHITECTURE.md) for design patterns
3. **Explore** the example code in `Pages/` and `Tests/`
4. **Customize** for your application
5. **Expand** with additional page objects and tests

## 🆘 Need Help?

- **Setup Issues**: Check [QUICKSTART.md](QUICKSTART.md)
- **Understanding Architecture**: See [ARCHITECTURE.md](ARCHITECTURE.md)
- **Specific Folder**: Check the README in that folder

## 🎯 Best Practices Used

✅ Page Object Model pattern
✅ Separation of concerns
✅ DRY (Don't Repeat Yourself)
✅ SOLID principles
✅ Async/await for non-blocking operations
✅ Strong typing for safety
✅ Configuration management
✅ Comprehensive logging
✅ Test isolation
✅ Clear naming conventions

## 📝 File Navigation

### Main Documentation

- [QUICKSTART.md](QUICKSTART.md) - Start here
- [ARCHITECTURE.md](ARCHITECTURE.md) - How it works
- [STRUCTURE.md](STRUCTURE.md) - What's included

### Folder READMEs

- [Pages/README.md](Pages/README.md) - Page Object Guidelines
- [Tests/README.md](Tests/README.md) - Testing Guidelines
- [Drivers/README.md](Drivers/README.md) - Browser Management
- [Config/README.md](Config/README.md) - Configuration
- [Utilities/README.md](Utilities/README.md) - Helper Classes
- [Data/README.md](Data/README.md) - Test Data

### Configuration

- [appsettings.json](appsettings.json) - Environment settings
- [.runsettings](.runsettings) - Test runner configuration
- [.gitignore](.gitignore) - Git rules

### Project Files

- [PlaywrightTests.csproj](PlaywrightTests.csproj) - Project definition
- [setup.sh](setup.sh) - Setup script
