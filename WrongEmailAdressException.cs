using System;

namespace Lab4
{
    class WrongEmailAdressException : Exception
    {
        public WrongEmailAdressException(string message) : base(message)
        {
        }
    }
}
