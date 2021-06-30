using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace VendingMachine.Tests
{
    [TestFixture]
    public class VendingMachineTests
    {
        private VendingMachine _vendingMachine;
        private Catalogue _catalogue1;
        private List<IDrink> _drinks;
        private List<IFood> _foods;
        private List<IWeapon> _weapons;

        [SetUp]
        public void Setup()
        {
            _vendingMachine = new VendingMachine();
            InitializeItems();
            _catalogue1 = new Catalogue(_drinks, _foods, _weapons, 1);
        }

        [Test]
        public void SetupVendingMachine_SetupWithCatalogue_ReturnsTrueCatalogueId()
        {
            _vendingMachine.SetupVendingMachine(_catalogue1);
            Assert.AreEqual(_vendingMachine.CurrentCatalogueId, _catalogue1.Id);
        }

        [Test]
        public void RefillVendingMachine_WithSingleItem_AddItemToInventory()
        {
            _vendingMachine.Refill(new Drink(5, "coke", 5, 15));
            Assert.True(_vendingMachine.Inventory.IsInInventory(5));
        }

        public void RefillVendingMachine_WithListOfItems_AddItemsToInventory()
        {
            List<VMItem> items = new List<VMItem>();
            var item1 = new Drink(5, "coke", 5, 15);
            var item2 = new Weapon(6, "diggle", 150, 2);
            items.Add(item1);
            items.Add(item2);
            _vendingMachine.Refill(items);
            Assert.True(_vendingMachine.Inventory.IsInInventory(5));
            Assert.Equals(item2, _vendingMachine.Inventory.ReturnItem(item2.Id));
        }


        private void InitializeItems()
        {
            _drinks = new List<IDrink>();
            _drinks.Add(new Drink(1, "juice", 5, 11));

            _foods = new List<IFood>();
            _foods.Add(new Food(2, "cake", 10, 7));

            _weapons = new List<IWeapon>();
            _weapons.Add(new Weapon(3, "Vector", 100, 2));
        }
    }
}