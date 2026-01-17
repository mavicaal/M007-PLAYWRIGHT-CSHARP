using Microsoft.Playwright;

namespace PlaywrightTests.Pages;

public interface IHomePage
{
    Task ValidateElementsVissibility();
    Task LogoutAsync();
    Task NavigateToAsync(string url);
}
