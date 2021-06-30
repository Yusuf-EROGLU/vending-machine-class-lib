using System.Collections.Generic;

namespace VendingMachine
{
    public class VMInterface : IVendingMachineInterface
    {
        public IVendingMachineInventory Inventory { get; set; }

        public IVendingMachineWallet Wallet { get; set; }

        public IVendingMachineLogger Logger { get; set; }

        public VMInterface()/* : this(
            ServiceLocator.Current.Get<IVendingMachineInventory>(),
            ServiceLocator.Current.Get<IVendingMachineWallet>(),
            ServiceLocator.Current.Get<IVendingMachineLogger>())*/
        {
        }

        private VMInterface(IVendingMachineInventory inventory, IVendingMachineWallet wallet,
            IVendingMachineLogger logger)
        {
            Inventory = inventory;
            Wallet = wallet;
            Logger = logger;
        }

        public void SetWallet(IVendingMachineWallet wallet)
        {
            Wallet = wallet;
        }
        public void SetInventory(IVendingMachineInventory inventory)
        {
            Inventory = inventory;
        }

        public void SetLogger(IVendingMachineLogger logger)
        {
            Logger = logger;
        }
        
        public void InsertCoin(Coin coin)
        {
            Wallet.AddPendingCoin(coin);
            Logger.DebugLog("Coin Inserted");
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
                Logger.DebugLog("item purchased");
            }
            catch (NotInInventory notInInventory)
            {
                Logger.ErrorLog(notInInventory.Message);
                throw;
            }
            catch (NotEnoughCurrencyException notEnoughCurrencyException)
            {
                Logger.ErrorLog(notEnoughCurrencyException.Message);
                throw;
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