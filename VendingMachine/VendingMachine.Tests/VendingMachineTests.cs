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
            Assert.AreEqual(_vendingMachine.CurrentCatalogueId,_catalogue1.Id);
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