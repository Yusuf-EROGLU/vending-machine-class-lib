using System.Collections.Generic;

namespace VendingMachine
{
    /// <summary>
    /// Catalogue that can define group of ıtem can be used for quick setup of Vending Machine
    /// </summary>
    public struct Catalogue
    {
        public List<IDrink> DrinkItems { get; set; }
        public List<IFood> FoodItems { get; set; }
        public List<IWeapon> WeaponItems { get; set; }
        public int Id { get; set; }
        
    }
}