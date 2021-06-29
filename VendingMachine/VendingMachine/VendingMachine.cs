using System.Collections.Concurrent;
using System.Collections.Generic;

namespace VendingMachine
{
    public class VendingMachine
    {
        public int CurrentCatalogueId { get; set; }
        public IVendingMachineInterface Interface { get; set; }
        public IVendingMachineInventory Inventory { get; set; }
        public IVendingMachineWallet Wallet { get; set; }
        public IVendingMachineLogger Logger { get; set; }

        public VendingMachine() : this(
            ServiceLocator.Current.Get<IVendingMachineInventory>(),
            ServiceLocator.Current.Get<IVendingMachineWallet>(),
            ServiceLocator.Current.Get<IVendingMachineInterface>(),
            ServiceLocator.Current.Get<IVendingMachineLogger>())
        {
        }

        public VendingMachine(IVendingMachineInventory inventory, IVendingMachineWallet wallet,
            IVendingMachineInterface vmInterface, IVendingMachineLogger logger)
        {
            Interface = vmInterface;
            Inventory = inventory;
            Wallet = wallet;
            Logger = logger;
        }

        public void SetupVendingMachine(Catalogue catalogue, List<Coin> initialCurrency)
        {
            CurrentCatalogueId = catalogue.Id;
            Inventory.SetUpInventory(catalogue);
            Wallet.SetCurrency(initialCurrency);
        }

        public void OpenInterface()
        {
            Interface.InitializeInterface();
        }

        public void Refill(VMItem item)
        {
            Inventory.AddItem(item);
        }

        public void Refill(List<VMItem> items)
        {
            Inventory.AddItem(items);
        }
    }
}