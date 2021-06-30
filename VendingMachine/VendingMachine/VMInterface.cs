using System.Collections.Generic;

namespace VendingMachine
{
    public class VMInterface : IVendingMachineInterface
    {
        public IVendingMachineInventory Inventory { get; set; }

        public IVendingMachineWallet Wallet { get; set; }

        public IVendingMachineLogger Logger { get; set; }

        public VMInterface() : this(
            ServiceLocator.Current.Get<IVendingMachineInventory>(),
            ServiceLocator.Current.Get<IVendingMachineWallet>(),
            ServiceLocator.Current.Get<IVendingMachineLogger>()
        )
        {
        }

        private VMInterface(IVendingMachineInventory ınventory, IVendingMachineWallet wallet,
            IVendingMachineLogger logger)
        {
            Inventory = ınventory;
            Wallet = wallet;
            Logger = logger;
        }

        public void InsertCoin(Coin coin)
        {
            Wallet.AddPendingCoin(coin);
        }

        public void InsertCoin(List<Coin> coins)
        {
            Wallet.AddPendingCoin(coins);
        }

        public void BuyItem(int itemId)
        {
            try
            {
                var pendingCurrency = Wallet.GetPendingCurrency();
                var itemPrice = Inventory.ReturnPrice(itemId);
                ControlValidTrade(itemId, pendingCurrency, itemPrice);

                Wallet.SpendCurrency(itemPrice);
                Inventory.TakeOutOfInventory(itemId);
            }
            catch (NotInInventory notInInventory)
            {
                Logger.DebugLog(notInInventory.Message);
            }
            catch (NotEnoughCurrencyException notEnoughCurrencyException)
            {
                Logger.DebugLog(notEnoughCurrencyException.Message);
            }
        }

        private void ControlValidTrade(int itemId, int pendingCurrency, int itemPrice)
        {
            if (!Inventory.IsInInventory(itemId))
                throw new NotInInventory("item not in inventory");
            if (pendingCurrency < itemPrice)
                throw new NotEnoughCurrencyException("not enough currency");
        }
        
    }
}