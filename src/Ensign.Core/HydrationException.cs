using System;

namespace EnsignLib.Core
{
    public class HydrationException : Exception
    {
        public HydrationException(string message, string attemptedString)
            :base(message)
        {
            AttemptedString = attemptedString;
        }

        public string AttemptedString { get; private set; }
    }
}
