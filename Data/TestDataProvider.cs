namespace PlaywrightTests.Data;

public static class TestDataProvider
{
    public static class Users
    {
        public static readonly TestUser ValidUser = new()
        {
            Username = "validuser",
            Password = "ValidPassword123!",
            Email = "validuser@example.com",
            Role = "User"
        };

        public static readonly TestUser AdminUser = new()
        {
            Username = "adminuser",
            Password = "AdminPassword123!",
            Email = "adminuser@example.com",
            Role = "Admin"
        };

        public static readonly TestUser InvalidUser = new()
        {
            Username = "invaliduser",
            Password = "WrongPassword",
            Email = "invalid@example.com",
            Role = "User"
        };
    }
}
