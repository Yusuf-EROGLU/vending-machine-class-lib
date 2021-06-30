namespace VendingMachine
{
    public interface IVendingMachineItem
    {
         ItemType Type { get; set; }
         int Id { get; set; }
         string Title { get; set; }
         int Price { get; set; }
         int Stock { get; set; }
    }
}