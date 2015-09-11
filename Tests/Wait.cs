using System;
using System.Diagnostics;
using System.Threading;

namespace Tests
{
    public static class Wait
    {
        public static bool Until(Func<bool> operation, TimeSpan timeout = default(TimeSpan))
        {
            if (timeout == default(TimeSpan))
                timeout = TimeSpan.FromSeconds(15);

            var stopwatch = Stopwatch.StartNew();

            while (operation.Invoke() == false)
            {
                if (stopwatch.Elapsed >= timeout)
                    throw new TimeoutException("Timed out waiting for operation to complete....");

                Thread.Sleep(300);
            }

            return true;
        }
    }
}

