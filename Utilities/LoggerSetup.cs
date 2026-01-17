using Serilog;
using Serilog.Events;

namespace PlaywrightTests.Utilities;

public static class LoggerSetup
{
    public static void ConfigureLogging(string logPath = "Reports/Logs")
    {
        if (!Directory.Exists(logPath))
            Directory.CreateDirectory(logPath);

        Log.Logger = new LoggerConfiguration()
            .MinimumLevel.Information()
            .WriteTo.Console(outputTemplate: "[{Timestamp:HH:mm:ss} {Level:u3}] {Message:lj}{NewLine}{Exception}")
            .WriteTo.File(
                path: Path.Combine(logPath, $"log_{DateTime.Now:yyyy-MM-dd_HH-mm-ss}.txt"),
                outputTemplate: "[{Timestamp:HH:mm:ss} {Level:u3}] {Message:lj}{NewLine}{Exception}",
                rollingInterval: RollingInterval.Day,
                retainedFileCountLimit: 7)
            .CreateLogger();
    }

    public static void CloseAndFlush()
    {
        Log.CloseAndFlush();
    }
}
