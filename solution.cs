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