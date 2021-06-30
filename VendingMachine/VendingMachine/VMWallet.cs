using System.Collections.Generic;
using System.Linq;

namespace VendingMachine
{
    public class VMWallet : IVendingMachineWallet
    {
        public List<Coin> CoinsInSafe;
        public List<Coin> PendingCoins;

        private IVendingMachineLogger Logger { get; set; }

        public VMWallet() : this(new List<Coin>(), new List<Coin>(),
            ServiceLocator.Current.Get<IVendingMachineLogger>())
        {
        }

        public VMWallet(List<Coin> coinsInSafe, List<Coin> pendingCoins)
        {
            CoinsInSafe = coinsInSafe;
            PendingCoins = pendingCoins;
        }

        public VMWallet(List<Coin> coinsInSafe, List<Coin> pendingCoins, IVendingMachineLogger logger)
        {
            CoinsInSafe = coinsInSafe;
            PendingCoins = pendingCoins;
            Logger = logger;
        }

        public void SetCurrency(List<Coin> initialCurrency)
        {
            if (initialCurrency == null)
            {
                Logger.DebugLog("Wallet Initialize With no Coin");
                return;
            }

            var currency = initialCurrency.Sum(x => x.Quantity);
            Logger.DebugLog("Wallet Initialize With" + currency + "Coin");
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
        public int GetInSafeCurrency() => CoinsInSafe.Sum(x => x.Quantity);

        public void SpendCurrency(int quantity)
        {
            //this is a bad vending machine that spends customer's change for Critical Ops premium cases
            CoinsInSafe.AddRange(PendingCoins);
            PendingCoins = new List<Coin>();
        }
    }
}