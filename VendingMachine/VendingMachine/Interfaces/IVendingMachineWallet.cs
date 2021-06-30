using System.Collections.Generic;

namespace VendingMachine
{
    public interface IVendingMachineWallet
    {
        void SetCurrency(List<Coin> initialCurrency);
        void AddPendingCoin(Coin coin);
        void AddPendingCoin(List<Coin> coins);
        int GetPendingCurrency();
        int GetInSafeCurrency();
        void SpendCurrency(int quantity);
        List<Coin> PendingCoins { get; set; }
        List<Coin> CoinsInSafe { get; set; }
    }
}