using NUnit.Framework;
using PlaywrightTests.Config;
using PlaywrightTests.Pages;

namespace PlaywrightTests.Tests;

[TestFixture]
public class HomePageTests : BaseTest
{
    private IHomePage _homePage = null!;
    private readonly ConfigurationManager _configManager = new();

    [SetUp]
    public new async Task SetUp()
    {
        await base.SetUp();
        // Assume user is already logged in, navigate to home page
        await BrowserManager.Page.GotoAsync($"{_configManager.ApplicationSettings.BaseUrl}/home");
        _homePage = new HomePage(BrowserManager.Page);
    }

    [Test]
    public async Task GivenHomePage_WhenNavigatingToThePage_ThenElementsAreVisible()
    {
        await _homePage.ValidateElementsVissibility();
    }
}
