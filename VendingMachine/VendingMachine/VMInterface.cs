using System.Collections.Generic;

namespace VendingMachine
{
    public class VMInterface : IVendingMachineInterface
    {
        public IVendingMachineInventory Inventory { get; set; }
        public IVendingMachineWallet Wallet { get; set; }

        public void InitializeInterface()
        {
        }

        public void InsertCoin(Coin coin)
        {
        }

        public void InsertCoin(List<Coin> coin)
        {
        }

        public void BuyItem(int itemId)
        {
        }

        public void PriceInquiry()
        {
        }
    }
}