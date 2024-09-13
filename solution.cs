Here is a simple implementation of a logging rate limiter using time-based buckets in C#. This implementation uses a Dictionary to store the timestamps of the logs and a TimeSpan to define the time window for the rate limit.

```C#
using System;
using System.Collections.Generic;

public class RateLimiter
{
    private Dictionary<string, DateTime> logs = new Dictionary<string, DateTime>();
    private TimeSpan timeWindow;

    public RateLimiter(TimeSpan timeWindow)
    {
        this.timeWindow = timeWindow;
    }

    public bool ShouldLog(string message)
    {
        DateTime now = DateTime.Now;

        if (logs.ContainsKey(message))
        {
            DateTime lastLogTime = logs[message];

            if (now - lastLogTime <= timeWindow)
            {
                return false;
            }
        }

        logs[message] = now;
        return true;
    }
}

class Program
{
    static void Main(string[] args)
    {
        RateLimiter rateLimiter = new RateLimiter(TimeSpan.FromSeconds(10));

        while (true)
        {
            string message = Console.ReadLine();

            if (rateLimiter.ShouldLog(message))
            {
                Console.WriteLine(message);
            }
        }
    }
}
```

In this code, the `RateLimiter` class is responsible for managing the rate limiting. It stores the timestamps of the logs in a Dictionary and uses a TimeSpan to define the time window for the rate limit.

The `ShouldLog` method checks if a message should be logged. If the message has been logged within the time window, it returns false. Otherwise, it updates the timestamp of the message and returns true.

The `Main` method creates a `RateLimiter` with a time window of 10 seconds and then enters a loop where it reads messages from the console. If the `RateLimiter` says that a message should be logged, it writes the message to the console.