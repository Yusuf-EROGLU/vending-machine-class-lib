namespace VendingMachine
{
    public abstract class VMItem 
    {
        public ItemType Type { get; set; }
        public int Id { get; set; }
        public string Title { get; set; }
        public int Price { get; set; }
        public int Stock { get; set; }
    }
}