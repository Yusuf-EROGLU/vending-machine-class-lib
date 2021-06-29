using System;
using System.Collections.Generic;

namespace VendingMachine
{
    public class VMInventory : IVendingMachineInventory
    {
        public List<IDrink> DrinkItems { get; set; }

        public List<IFood> FoodItems { get; set; }

        public List<IWeapon> WeaponItems { get; set; }

        public VMInventory() : this(
            ServiceLocator.Current.Get<List<IDrink>>(),
            ServiceLocator.Current.Get<List<IFood>>(),
            ServiceLocator.Current.Get<List<IWeapon>>()
        )
        {
        }

        private VMInventory(List<IDrink> drinkItems, List<IFood> foodItems, List<IWeapon> weaponItems)
        {
            DrinkItems = drinkItems;
            FoodItems = foodItems;
            WeaponItems = weaponItems;
        }
        
        public void SetUpInventory(Catalogue catalogue)
        {
            DrinkItems = catalogue.DrinkItems;
            FoodItems = catalogue.FoodItems;
            WeaponItems = catalogue.WeaponItems;
        }

        public void AddItem(VMItem item)
        {
            switch (item.Type)
            {
                case ItemType.Drink:
                    DrinkItems.Add((Drink) item);
                    break;
                case ItemType.Food:
                    FoodItems.Add((Food) item);
                    break;
                case ItemType.Weapon:
                    WeaponItems.Add((Weapon) item);
                    break;
            }
        }

        public void AddItem(List<VMItem> items)
        {
            foreach (var item in items)
            {
                AddItem(item);
            }
        }
    }
}