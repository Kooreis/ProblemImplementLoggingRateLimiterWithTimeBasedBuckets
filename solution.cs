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