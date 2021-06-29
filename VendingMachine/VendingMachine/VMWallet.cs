using System.Collections.Generic;

namespace VendingMachine
{
    public class VMWallet : IVendingMachineWallet
    {
        public List<Coin> CoinsInSafe;
        public List<Coin> PendingCoins;

        public void SetCurrency(List<Coin> initialCurrency)
        {
            CoinsInSafe.AddRange(initialCurrency);
        }
    }
}