using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace VendingMachine.Tests
{
    [TestFixture]
    public class VMInterfaceTests
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
            _vendingMachine.SetupVendingMachine(_catalogue1);
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

        [Test]
        public void InsertCoin_WithSingleCoin_AddPendingWallet()
        {
            var coin = new Coin(10);
            _vendingMachine.Interface.InsertCoin(coin);
            var pendingCurrency = _vendingMachine.Wallet.GetPendingCurrency();
            Assert.True(coin.Quantity == pendingCurrency);
        }

        [Test]
        public void InsertCoin_WithCoins_AddPendingWallet()
        {
            var coin1 = new Coin(50);
            var coin2 = new Coin(100);
            List<Coin> coins = new List<Coin>();
            coins.Add(coin1);
            coins.Add(coin2);

            _vendingMachine.Interface.InsertCoin(coins);
            var pendingCurrency = _vendingMachine.Wallet.GetPendingCurrency();
            var insertedCoinQuantity = coins.Sum(x => x.Quantity);
            Assert.True(insertedCoinQuantity == pendingCurrency);
        }

        [Test]
        public void BuyItem_ItemNotInInventory_TrowsNotInInventoryException()
        {
            var coin = new Coin(100);
            _vendingMachine.Interface.InsertCoin(coin);
            Assert.Throws<NotInInventory>(() => _vendingMachine.Interface.BuyItem(10));
        } 
        [Test]
        public void BuyItem_CanNotAffordItem_TrowsNotEnoughCurrencyException()
        {
            var coin = new Coin(30);
            _vendingMachine.Interface.InsertCoin(coin);
            Assert.Throws<NotEnoughCurrencyException>(() => _vendingMachine.Interface.BuyItem(3));
        }
    }
}