# Tests

This folder contains test classes that validate application functionality.

## Naming Convention

- Test classes should be named `<Feature>Tests.cs`
- Test methods should start with the feature being tested, followed by the scenario, followed by the expected result
- Format: `FeatureName_Scenario_ExpectedResult()`

## Example Test

```csharp
[TestFixture]
public class CheckoutTests : BaseTest
{
    private IShoppingCartPage _shoppingCartPage;
    private ICheckoutPage _checkoutPage;

    [SetUp]
    public new async Task SetUp()
    {
        await base.SetUp();
        // Additional setup for this test class
    }

    [Test]
    public async Task Checkout_WithValidPayment_ShouldCompleteOrder()
    {
        // Arrange
        var product = TestDataProvider.Products.ValidProduct;

        // Act
        await _shoppingCartPage.AddProductAsync(product);
        await _shoppingCartPage.ProceedToCheckoutAsync();
        await _checkoutPage.EnterShippingAddressAsync(TestDataProvider.Addresses.ValidAddress);
        await _checkoutPage.SelectPaymentMethodAsync("CreditCard");
        var orderNumber = await _checkoutPage.CompleteOrderAsync();

        // Assert
        Assert.That(orderNumber, Is.Not.Null.And.Not.Empty);
    }

    [Test]
    public async Task Checkout_WithExpiredCard_ShouldShowError()
    {
        // Arrange
        var expiredCard = TestDataProvider.PaymentMethods.ExpiredCard;

        // Act
        var errorMessage = await _checkoutPage.EnterPaymentDetailsAsync(expiredCard);

        // Assert
        Assert.That(errorMessage, Does.Contain("expired"));
    }

    [TearDown]
    public new async Task TearDown()
    {
        await base.TearDown();
        // Additional cleanup if needed
    }
}
```

## Test Structure

All tests should follow the **AAA Pattern**:

- **Arrange**: Set up test data and preconditions
- **Act**: Perform the action being tested
- **Assert**: Verify the expected results

## Best Practices

1. **Independence**: Each test should be independent and runnable in any order
2. **Clarity**: Test names should clearly describe what is being tested
3. **Isolation**: Use setup/teardown to maintain clean state
4. **Avoid Hard Coding**: Use TestDataProvider for test data
5. **Single Assertion Focus**: Each test should focus on one behavior
6. **No Sleep**: Use wait helpers instead of Thread.Sleep()
7. **Descriptive Assertions**: Use assertion messages to explain failures
