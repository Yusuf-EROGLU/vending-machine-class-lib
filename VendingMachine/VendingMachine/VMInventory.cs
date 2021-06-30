using System;
using System.Collections.Generic;
using System.Linq;

namespace VendingMachine
{
    public class VMInventory : IVendingMachineInventory
    {
        public List<IDrink> DrinkItems { get; set; }

        public List<IFood> FoodItems { get; set; }

        public List<IWeapon> WeaponItems { get; set; }

        public List<IVendingMachineItem> MasterItemList
        {
            get
            {
                var masterList = new List<IVendingMachineItem>();
                masterList.AddRange(DrinkItems);
                masterList.AddRange(FoodItems);
                masterList.AddRange(WeaponItems);
                return masterList;
            }
        }


        public VMInventory()  /*:this(
            ServiceLocator.Current.Get<List<IDrink>>(),
            ServiceLocator.Current.Get<List<IFood>>(),
            ServiceLocator.Current.Get<List<IWeapon>>()
        )*/
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

        public bool IsInInventory(int itemId) => MasterItemList.Exists(x => x.Id == itemId);


        public int ReturnPrice(int itemId)
        {
            return MasterItemList.FirstOrDefault(x=> x.Id == itemId).Price;
        }

        public void TakeOutOfInventory(int itemId)
        {
            var itemType = MasterItemList.FirstOrDefault(x=> x.Id == itemId).Type;

            switch (itemType)
            {
                case ItemType.Drink:
                    DrinkItems.FirstOrDefault(x => x.Id.Equals(itemId) && x.Stock > 0).Stock--;
                    break;
                case ItemType.Food:
                    FoodItems.FirstOrDefault(x => x.Id.Equals(itemId) && x.Stock > 0).Stock--;
                    break;
                case ItemType.Weapon:
                    WeaponItems.FirstOrDefault(x => x.Id.Equals(itemId) && x.Stock > 0).Stock--;
                    break;
            }
        }
    }
}