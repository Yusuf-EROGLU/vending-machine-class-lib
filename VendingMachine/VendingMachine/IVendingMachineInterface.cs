using System.Collections.Generic;

namespace VendingMachine
{
    public interface IVendingMachineInterface
    {
        void InsertCoin(Coin coin);

        void InsertCoin(List<Coin> coin);

        void BuyItem(int itemId);

    }
}