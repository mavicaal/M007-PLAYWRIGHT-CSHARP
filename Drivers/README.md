# Drivers

This folder contains browser and driver management classes.

## BrowserManager.cs

Manages the browser lifecycle including initialization, context creation, and cleanup.

**Features:**

- Multi-browser support (Chromium, Firefox, WebKit)
- Automatic timeouts configuration
- Proper resource cleanup
- Structured logging

**Usage:**

```csharp
var browserManager = new BrowserManager();
await browserManager.InitializeBrowserAsync();
var page = browserManager.Page;
// ... use page ...
await browserManager.DisposeAsync();
```

## BasePage.cs

Base class for all page objects providing common interaction methods.

**Key Methods:**

- `ClickAsync(string selector)` - Click an element
- `FillAsync(string selector, string text)` - Fill a text field
- `GetTextAsync(string selector)` - Get element text content
- `IsVisibleAsync(string selector)` - Check element visibility
- `WaitForSelectorAsync(string selector)` - Wait for element presence
- `SelectOptionAsync(string selector, string value)` - Select dropdown option
- `CheckAsync(string selector)` - Check a checkbox
- `UncheckAsync(string selector)` - Uncheck a checkbox

All methods include logging for debugging and traceability.

## Best Practices

1. **Use Base Methods**: Leverage BasePage methods instead of calling Page directly
2. **Encapsulation**: Keep Page reference private
3. **Logging**: All interactions are automatically logged
4. **Error Handling**: Methods throw meaningful exceptions with logging
5. **Consistency**: Use consistent naming and parameter patterns
