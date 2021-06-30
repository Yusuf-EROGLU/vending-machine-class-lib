using System;

namespace VendingMachine
{
    public class NotEnoughCurrencyException : Exception
    {
        public NotEnoughCurrencyException()
            : base()
        {
        }

        public NotEnoughCurrencyException(String message)
            : base(message)
        {
        }

        public NotEnoughCurrencyException(String message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}