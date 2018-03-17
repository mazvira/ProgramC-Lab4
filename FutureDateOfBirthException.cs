using System;

namespace Lab4
{
    class FutureDateOfBirthException : Exception
    {
        public FutureDateOfBirthException(string message) : base(message)
        {
        }
    }
}
