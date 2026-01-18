using Microsoft.Playwright;

namespace PlaywrightTests.Pages;

interface IAutoWaitPage
{
    Task ValidateButtonVissibility(int seconds);
    Task ValidateTextAreaVissibility(int seconds);
    Task ValidateInputVissibility(int seconds);
    Task ValidateSelectVissibility(int seconds);
    Task ValidateLabelVissibility(int seconds);
    Task ValidateButtonIsEnabledAndEditable(int seconds);
    Task ValidateTextAreaIsEnabledAndEditable(int seconds);
    Task ValidateInputIsEnabledAndEditable(int seconds);
    Task ValidateSelectIsEnabledAndEditable(int seconds);
    Task ValidateLabelIsEnabledAndEditable(int seconds);
    Task LogoutAsync();
    Task NavigateToAutoWaitAsync();
}