namespace PlaywrightTests.Utilities;

public static class WaitHelpers
{
    public static async Task WaitUntilAsync(Func<Task<bool>> condition, int timeoutMs = 5000, int delayMs = 100)
    {
        var stopwatch = System.Diagnostics.Stopwatch.StartNew();
        
        while (stopwatch.ElapsedMilliseconds < timeoutMs)
        {
            try
            {
                if (await condition())
                    return;
            }
            catch
            {
                // Continue waiting
            }

            await Task.Delay(delayMs);
        }

        throw new TimeoutException($"Condition not met within {timeoutMs}ms");
    }

    public static async Task<T> WaitForResultAsync<T>(Func<Task<T>> operation, int timeoutMs = 5000, int delayMs = 100)
    {
        var stopwatch = System.Diagnostics.Stopwatch.StartNew();
        
        while (stopwatch.ElapsedMilliseconds < timeoutMs)
        {
            try
            {
                var result = await operation();
                if (result != null)
                    return result;
            }
            catch
            {
                // Continue waiting
            }

            await Task.Delay(delayMs);
        }

        throw new TimeoutException($"Operation did not return result within {timeoutMs}ms");
    }
}
