namespace VendingMachine
{
    public abstract class VMItem 
    {
        protected VMItem()
        {
            
        }
        protected VMItem( int ıd, string title, int price, int stock)
        {
            Id = ıd;
            Title = title;
            Price = price;
            Stock = stock;
        }

        public ItemType Type { get; set; }
        public int Id { get; set; }
        public string Title { get; set; }
        public int Price { get; set; }
        public int Stock { get; set; }
    }
}