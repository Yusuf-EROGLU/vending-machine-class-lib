namespace VendingMachine
{
    public class Weapon : VMItem, IWeapon
    {
        public Weapon()
        {
        }

        public Weapon(int ıd, string title, int price, int stock) : base(ıd, title, price, stock)
        {
            Type = ItemType.Weapon;
        }
    }
}