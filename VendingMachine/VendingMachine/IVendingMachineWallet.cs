using System.Collections.Generic;

namespace VendingMachine
{
    public interface IVendingMachineWallet
    {
        void SetCurrency(List<Coin> initialCurrency);
    }
}