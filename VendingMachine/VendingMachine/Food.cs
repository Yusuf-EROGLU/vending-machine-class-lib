namespace VendingMachine
{
    public class Food : VMItem, IFood, IConsumable
    {
        public Food()
        {
        }

        public Food(int ıd, string title, int price, int stock) : base(ıd, title, price, stock)
        {
            Type = ItemType.Food;
        }
    }
}