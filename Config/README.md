# Configuration

This folder contains application and framework configuration classes.

## ConfigurationManager.cs

Loads and provides access to configuration settings from `appsettings.json`.

**Usage:**

```csharp
var configManager = new ConfigurationManager();
var baseUrl = configManager.ApplicationSettings.BaseUrl;
var browserType = configManager.PlaywrightSettings.BrowserType;
```

## PlaywrightSettings.cs

Configuration settings specific to Playwright browser automation.

**Properties:**

- `BrowserType` - Chrome, Firefox, or Safari (default: Chromium)
- `Headless` - Run browser in headless mode (default: true)
- `SlowMo` - Slow down actions by specified milliseconds (default: 0)
- `Timeout` - Global timeout for operations in ms (default: 30000)
- `NavigationTimeout` - Timeout for navigation in ms (default: 30000)

## ApplicationSettings.cs

Configuration settings for the application under test.

**Properties:**

- `BaseUrl` - The base URL of the application
- `Environment` - Current test environment (Development, Staging, Production)

## Best Practices

1. **Externalize Configuration**: Never hardcode URLs or settings
2. **Environment-Specific**: Support different configurations per environment
3. **Type-Safe**: Use strongly-typed configuration objects
4. **Validation**: Validate required configuration values
5. **Defaults**: Provide sensible defaults for optional values
