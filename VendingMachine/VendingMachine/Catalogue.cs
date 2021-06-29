using System.Collections.Generic;

namespace VendingMachine
{
    /// <summary>
    /// Catalogue that can define group of ıtem can be used for quick setup of Vending Machine
    /// </summary>
    public struct Catalogue
    {
        public List<Drink> DrinkItems { get; set; }
        public List<Food> FoodItems { get; set; }
        public List<Weapon> WeaponItems { get; set; }
        public int Id { get; set; }
        
    }
}