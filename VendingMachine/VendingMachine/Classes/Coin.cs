using System.Xml;

namespace VendingMachine
{
    public class Coin
    {
        public Coin(int quantity)
        {
            Quantity = quantity;
        }

        public int Quantity { get; set; }
    }
}