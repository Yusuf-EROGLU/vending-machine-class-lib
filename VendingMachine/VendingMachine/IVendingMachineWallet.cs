using System.Collections.Generic;

namespace VendingMachine
{
    public interface IVendingMachineWallet
    {
        void SetCurrency(List<Coin> initialCurrency);
        void AddPendingCoin(Coin coin);
        void AddPendingCoin(List<Coin> coins);
        int GetPendingCurrency();
        void SpendCurrency(int quantity);
    }
}