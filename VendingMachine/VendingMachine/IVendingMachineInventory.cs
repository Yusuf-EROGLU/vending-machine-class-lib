using System.Collections.Generic;

namespace VendingMachine
{
    public interface IVendingMachineInventory
    {
        void SetUpInventory(Catalogue catalogue);
        void AddItem(VMItem item);
        void AddItem(List<VMItem> items);
    }
}