using Microsoft.Playwright;
using NUnit.Framework;
using PlaywrightTests.Drivers;
using PlaywrightTests.Config;

namespace PlaywrightTests.Pages;

public class AutoWaitPage : BasePage, IAutoWaitPage

{
    private readonly ConfigurationManager _configManager = new();
    //Title Selector

    private const string HomeTitle = "UI Test Automation Playground";

    private const ILocator InputSelectElementType = Page.GetByLabel("Choose an element type:").SelectOptionAsync(new[] { "input" });
    private const ILocator ButtonSelectElementType = Page.GetByLabel("Choose an element type:").SelectOptionAsync(new[] { "Button" });
    private const ILocator TextAreaSelectElementType = Page.GetByLabel("Choose an element type:").SelectOptionAsync(new[] { "Textarea" });
    private const ILocator SelectBoxSelectElementType = Page.GetByLabel("Choose an element type:").SelectOptionAsync(new[] { "Select" });
    private const ILocator LabelSelectElementType = Page.GetByLabel("Choose an element type:").SelectOptionAsync(new[] { "Label" });

    private const ILocator Seconds3Button = Page.GetByRole(AriaRole.Button, new() { Name = "Apply 3s" });
    private const ILocator Seconds5Button = Page.GetByRole(AriaRole.Button, new() { Name = "Apply 5s" });

    private const ILocator Seconds10Button = Page.GetByRole(AriaRole.Button, new() { Name = "Apply 10s" });

    private const ILocator ButtonButton = Page.GetByRole(AriaRole.Button, new() { Name = "Button" });

    private const ILocator TargetInputLocator = Page.Locator("#target");

    private const ILocator LabelText = Page.GetByText("This is a Label");
    private const ILocator VisibleOption = Page.GetByRole(AriaRole.Option, new() { Name = "Visible" });
    private const ILocator EnabledOption = Page.GetByRole(AriaRole.Option, new() { Name = "Enabled" });
    private const ILocator EditableOption = Page.GetByRole(AriaRole.Option, new() { Name = "Editable" });
    private const ILocator OnTopOption = Page.GetByRole(AriaRole.Option, new() { Name = "On Top" });
    private const ILocator NonZeroSizeOption = Page.GetByRole(AriaRole.Option, new() { Name = "Non Zero Size" });

    // Locator Properties
    private ILocator Title => Page.Locator("h1");

    public AutoWaitPage(IPage page) : base(page)
    {
    }


    public async Task ChooseLabelOptionAsync()
    {
        await LabelSelectElementType.ClickAsync();
    }

    public async Task ChooseButtonOptionAsync()
    {
        await ButtonSelectElementType.ClickAsync();
    }

    public async Task ChooseInputOptionAsync()
    {
        await InputSelectElementType.ClickAsync();
    }

    public async Task ChooseTextAreaOptionAsync()
    {
        await TextAreaSelectElementType.ClickAsync();
    }

    public async Task CheckVisibleOnlyOptionAsync()
    {
        await VisibleOption.CheckAsync();
        await EnabledOption.UncheckAsync();
        await EditableOption.UncheckAsync();
        await OnTopOption.UncheckAsync();
        await NonZeroSizeOption.UncheckAsync();
    }

    public async Task CheckEnabledOnlyOptionAsync()
    {
        await VisibleOption.UncheckAsync();
        await EnabledOption.CheckAsync();
        await EditableOption.UncheckAsync();
        await OnTopOption.UncheckAsync();
        await NonZeroSizeOption.UncheckAsync();
    }

    public async Task CheckEditableOnlyOptionAsync()
    {
        await VisibleOption.UncheckAsync();
        await EnabledOption.UncheckAsync();
        await EditableOption.CheckAsync();
        await OnTopOption.UncheckAsync();
        await NonZeroSizeOption.UncheckAsync();
    }

    public async Task CheckOnTopOnlyOptionAsync()
    {
        await VisibleOption.UncheckAsync();
        await EnabledOption.UncheckAsync();
        await EditableOption.UncheckAsync();
        await OnTopOption.CheckAsync();
        await NonZeroSizeOption.UncheckAsync();
    }

    public async Task CheckNonZeroSizeOnlyOptionAsync()
    {
        await VisibleOption.UncheckAsync();
        await EnabledOption.UncheckAsync();
        await EditableOption.UncheckAsync();
        await OnTopOption.UncheckAsync();
        await NonZeroSizeOption.CheckAsync();
    }

    public async Task ClickSeconds3OptionAsync()
    {
        await Seconds3Button.ClickAsync();
    }

    public async Task ClickSeconds3OptionAsync()
    {
        await Seconds3Button.ClickAsync();
    }

    public async Task ClickSeconds5OptionAsync()
    {
        await Seconds5Button.ClickAsync();
    }
    public async Task ClickSeconds10OptionAsync()
    {
        await Seconds10Button.ClickAsync();
    }

    public async Task ValidateTargetInputVisibilityAsync()
    {
        await Expect(TargetInputLocator).ToBeVisibleAsync();
    }

    public async Task ValidateLabelTextVisibilityAsync()
    {
        await Expect(LabelText).ToBeVisibleAsync();
    }

    public async Task ValidateButtonButtonVisibilityAsync()
    {
        await Expect(ButtonButton).ToBeVisibleAsync();
    }

    public async Task ValidateTargetInputEnabledAsync()
    {
        await Expect(TargetInputLocator).ToBeEnabledAsync();
    }

    public async Task ValidateLabelTextEnabledAsync()
    {
        await Expect(LabelText).ToBeEnabledAsync();
    }

    public async Task ValidateButtonEnabledAsync()
    {
        await Expect(ButtonButton).ToBeEnabledAsync();
    }

    public async Task ValidateTargetInputEditableAsync()
    {
        await Expect(TargetInputLocator).ToBeEditableAsync();
    }

    public async Task ValidateLabelTextEditableAsync()
    {
        await Expect(LabelText).ToBeEditableAsync();
    }

    public async Task ValidateButtonEditableAsync()
    {
        await Expect(ButtonButton).ToBeEditableAsync();
    }

    public async Task NavigateToAutoWaitAsync()
    {
        var fullUrl = $"{_configManager.ApplicationSettings.BaseUrl}/autowait";
        await GotoAsync(fullUrl);
    }
}