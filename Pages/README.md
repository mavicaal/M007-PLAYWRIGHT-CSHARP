# Page Objects

This folder contains page object classes that represent pages in the application being tested.

## Naming Convention

- Create an interface prefixed with `I` (e.g., `ILoginPage.cs`)
- Create the implementation class (e.g., `LoginPage.cs`)
- All page objects should inherit from `BasePage`

## Example Page Object

```csharp
// IProductPage.cs
public interface IProductPage
{
    Task<string> GetProductNameAsync();
    Task<decimal> GetPriceAsync();
    Task AddToCartAsync();
    Task<bool> IsOutOfStockAsync();
}

// ProductPage.cs
public class ProductPage : BasePage, IProductPage
{
    private const string ProductNameSelector = "h1.product-name";
    private const string PriceSelector = ".product-price";
    private const string AddToCartButtonSelector = "button.add-to-cart";
    private const string OutOfStockSelector = ".out-of-stock";

    public ProductPage(IPage page) : base(page) { }

    public async Task<string> GetProductNameAsync()
    {
        return await GetTextAsync(ProductNameSelector);
    }

    public async Task<decimal> GetPriceAsync()
    {
        var priceText = await GetTextAsync(PriceSelector);
        // Parse and return price
        return decimal.Parse(priceText.Replace("$", ""));
    }

    public async Task AddToCartAsync()
    {
        await ClickAsync(AddToCartButtonSelector);
        await WaitForLoadStateAsync();
    }

    public async Task<bool> IsOutOfStockAsync()
    {
        return await IsVisibleAsync(OutOfStockSelector);
    }
}
```

## Best Practices

1. **Encapsulation**: Keep selectors private
2. **Descriptive Methods**: Method names should describe the action
3. **Single Responsibility**: Each method should do one thing
4. **No Assertions**: Page objects should not contain assertions
5. **Async/Await**: Always use async methods
6. **Logging**: Leverage BasePage logging through inherited methods
