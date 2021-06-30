using System;

namespace VendingMachine
{
    public class NotInInventory : Exception
    {
        public NotInInventory()
            : base()
        {
        }

        public NotInInventory(String message)
            : base(message)

        {
        }

        public NotInInventory(String message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}