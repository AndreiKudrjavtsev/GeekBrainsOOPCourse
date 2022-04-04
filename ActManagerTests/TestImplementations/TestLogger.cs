using ActManager.Infrastructure.Loggers;
using System.Collections.Generic;

namespace ActManagerTests.TestImplementations;

internal class TestLogger : ILogger
{
    public readonly List<string> LoggedMessages = new List<string>();

    public void Log(string message)
    {
        LoggedMessages.Add(message);
    }
}
