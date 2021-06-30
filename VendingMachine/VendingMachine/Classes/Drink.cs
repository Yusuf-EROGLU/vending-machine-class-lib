namespace VendingMachine
{
    public class Drink : VMItem, IDrink, IConsumable
    {
        public Drink()
        {
        }

        public Drink(int ıd, string title, int price, int stock) : base(ıd, title, price, stock)
        {
            Type = ItemType.Drink;
        }
    }
}