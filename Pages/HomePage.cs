using Microsoft.Playwright;
using NUnit.Framework;
using PlaywrightTests.Drivers;
using PlaywrightTests.Config;

namespace PlaywrightTests.Pages;

public class HomePage : BasePage, IHomePage

{
    private readonly ConfigurationManager _configManager = new();
    //Title Selector

    private const string HomeTitle = "UI Test Automation Playground";

    // Locator Properties
    private ILocator HomeLink => GetLinkLocator("Home");
    private ILocator ResourcesLink => GetLinkLocator("Resources");
    private ILocator DynamicIdLink => GetLinkLocator("Dynamic ID");
    private ILocator ClassAttributeLink => GetLinkLocator("Class Attribute");
    private ILocator HiddenLayersLink => GetLinkLocator("Hidden Layers");
    private ILocator LoadDelayLink => GetLinkLocator("Load Delay");
    private ILocator AjaxDataLink => GetLinkLocator("AJAX Data");
    private ILocator ClientSideDelayLink => GetLinkLocator("Client Side Delay");
    private ILocator ClickLink => GetLinkLocator("Click");
    private ILocator TextInputLink => GetLinkLocator("Text Input");
    private ILocator ScrollbarsLink => GetLinkLocator("Scrollbars");
    private ILocator DynamicTableLink => GetLinkLocator("Dynamic Table");
    private ILocator VerifyTextLink => GetLinkLocator("Verify Text");
    private ILocator ProgressBarLink => GetLinkLocator("Progress Bar");
    private ILocator VisibilityLink => GetLinkLocator("Visibility");
    private ILocator SampleAppLink => GetLinkLocator("Sample App");
    private ILocator MouseOverLink => GetLinkLocator("Mouse Over");
    private ILocator NonBreakingSpaceLink => GetLinkLocator("Non-Breaking Space");
    private ILocator OverlappedElementLink => GetLinkLocator("Overlapped Element");
    private ILocator ShadowDOMLink => GetLinkLocator("Shadow DOM");
    private ILocator AlertsLink => GetLinkLocator("Alerts");
    private ILocator FileUploadLink => GetLinkLocator("File Upload");
    private ILocator PageHeading => GetHeadingLocator(HomeTitle);

    public HomePage(IPage page) : base(page)
    {
    }

    public async Task ValidateElementsVissibility()
    {
        Assert.That(await HomeLink.IsVisibleAsync(), Is.True, "Home link should be visible");
        Assert.That(await ResourcesLink.IsVisibleAsync(), Is.True, "Resources link should be visible");
        Assert.That(await DynamicIdLink.IsVisibleAsync(), Is.True, "Dynamic ID link should be visible");
        Assert.That(await ClassAttributeLink.IsVisibleAsync(), Is.True, "Class Attribute link should be visible");
        Assert.That(await HiddenLayersLink.IsVisibleAsync(), Is.True, "Hidden Layers link should be visible");
        Assert.That(await LoadDelayLink.IsVisibleAsync(), Is.True, "Load Delay link should be visible");
        Assert.That(await AjaxDataLink.IsVisibleAsync(), Is.True, "AJAX Data link should be visible");
        Assert.That(await ClientSideDelayLink.IsVisibleAsync(), Is.True, "Client Side Delay link should be visible");
        Assert.That(await ClickLink.IsVisibleAsync(), Is.True, "Click link should be visible");
        Assert.That(await TextInputLink.IsVisibleAsync(), Is.True, "Text Input link should be visible");
        Assert.That(await ScrollbarsLink.IsVisibleAsync(), Is.True, "Scrollbars link should be visible");
        Assert.That(await DynamicTableLink.IsVisibleAsync(), Is.True, "Dynamic Table link should be visible");
        Assert.That(await VerifyTextLink.IsVisibleAsync(), Is.True, "Verify Text link should be visible");
        Assert.That(await ProgressBarLink.IsVisibleAsync(), Is.True, "Progress Bar link should be visible");
        Assert.That(await VisibilityLink.IsVisibleAsync(), Is.True, "Visibility link should be visible");
        Assert.That(await SampleAppLink.IsVisibleAsync(), Is.True, "Sample App link should be visible");
        Assert.That(await MouseOverLink.IsVisibleAsync(), Is.True, "Mouse Over link should be visible");
        Assert.That(await NonBreakingSpaceLink.IsVisibleAsync(), Is.True, "Non-Breaking Space link should be visible");
        Assert.That(await OverlappedElementLink.IsVisibleAsync(), Is.True, "Overlapped Element link should be visible");
        Assert.That(await ShadowDOMLink.IsVisibleAsync(), Is.True, "Shadow DOM link should be visible");
        Assert.That(await AlertsLink.IsVisibleAsync(), Is.True, "Alerts link should be visible");
        Assert.That(await PageHeading.IsVisibleAsync(), Is.True, "Page heading should be visible");
    }

    public async Task LogoutAsync()
    {
        Logger.Information("Logging out from home page");
        await Task.CompletedTask;
    }

    public async Task NavigateToHomeAsync()
    {
        var fullUrl = $"{_configManager.ApplicationSettings.BaseUrl}/home";
        await GotoAsync(fullUrl);
    }
}
