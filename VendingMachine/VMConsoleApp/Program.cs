using System.Collections.Generic;
using VendingMachine;

namespace VMConsoleApp
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            VendingMachine.VendingMachine vm = new VendingMachine.VendingMachine();
            var ct = InitializeCatalogue();
            vm.SetupVendingMachine(ct);
            vm.Interface.InsertCoin(new Coin(1000));
            vm.Interface.BuyItem(1);
        }

        private static Catalogue InitializeCatalogue()
        {
            Catalogue ct = new Catalogue();
            ct.DrinkItems = new List<IDrink>();
            ct.FoodItems = new List<IFood>();
            ct.WeaponItems = new List<IWeapon>();
            ct.DrinkItems.Add(new Drink(1, "juice", 100, 1));
            ct.FoodItems.Add(new Food(2, "meat", 100, 1));
            ct.WeaponItems.Add(new Weapon(3, "Gun", 1500, 1));
            return ct;
        }
    }
}