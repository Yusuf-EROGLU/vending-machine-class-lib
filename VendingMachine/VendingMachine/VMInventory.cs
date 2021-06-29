using System;
using System.Collections.Generic;

namespace VendingMachine
{
    public class VMInventory :IVendingMachineInventory
    {
        public List<Drink> DrinkItems { get; set; }
        public List<Food> FoodItems { get; set; }
        public List<Weapon> WeaponItems { get; set; }

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