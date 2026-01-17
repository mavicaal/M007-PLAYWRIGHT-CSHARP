namespace PlaywrightTests.Config;

public class PlaywrightSettings
{
    public string BrowserType { get; set; } = "Chromium";
    public bool Headless { get; set; } = true;
    public int SlowMo { get; set; } = 0;
    public int Timeout { get; set; } = 30000;
    public int NavigationTimeout { get; set; } = 30000;
}
