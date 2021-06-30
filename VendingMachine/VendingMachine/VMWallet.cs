using System.Collections.Generic;
using System.Linq;

namespace VendingMachine
{
    public class VMWallet : IVendingMachineWallet
    {
        public List<Coin> CoinsInSafe;
        public List<Coin> PendingCoins;

        public VMWallet() : this(new List<Coin>(), new List<Coin>())
        {
        }

        public VMWallet(List<Coin> coinsInSafe, List<Coin> pendingCoins)
        {
            CoinsInSafe = coinsInSafe;
            PendingCoins = pendingCoins;
        }

        public void SetCurrency(List<Coin> initialCurrency)
        {
            CoinsInSafe.AddRange(initialCurrency);
        }

        public void AddPendingCoin(Coin coin)
        {
            PendingCoins.Add(coin);
        }

        public void AddPendingCoin(List<Coin> coins)
        {
            PendingCoins.AddRange(coins);
        }

        public int GetPendingCurrency() => PendingCoins.Sum(x => x.Quantity);

        public void SpendCurrency(int quantity)
        {
            //this is a bad vending machine that spends customer's change for Critical Ops premium cases
            PendingCoins = new List<Coin>();
        }
    }
}