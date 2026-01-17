# Data

This folder contains test data models and providers.

## TestUser.cs

Model representing a test user with authentication credentials.

**Properties:**

- `Username` - User's login username
- `Password` - User's login password
- `Email` - User's email address
- `Role` - User's role/permission level

## TestDataProvider.cs

Centralized provider for all test data used across tests.

**Organization:**

- Static classes for different data categories
- Read-only instances of commonly used data

**Usage:**

```csharp
var user = TestDataProvider.Users.ValidUser;
var product = TestDataProvider.Products.ValidProduct;
```

## Best Practices

1. **Centralize Test Data**: Keep all test data in one place
2. **Reuse Common Data**: Create instances for frequently used data
3. **Organize by Category**: Group related data in nested static classes
4. **Meaningful Names**: Use descriptive names (ValidUser, InvalidEmail, etc.)
5. **Type Safety**: Use strong typing for test data
6. **Document Defaults**: Document what each test data represents

## Adding New Test Data

1. Create a model class if it doesn't exist
2. Add data to appropriate category in `TestDataProvider`
3. Update documentation with usage examples
4. Ensure data is realistic but not sensitive
