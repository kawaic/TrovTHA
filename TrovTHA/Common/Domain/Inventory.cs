namespace Common.Domain
{
    public class Inventory : BaseDomain
    {
        public Item Item { get; set; }
        public int NumberInStock { get; set; }
        public int ReOrderLevel { get; set; }
        public string Location { get; set; }

        public bool HasEnoughStockFor(Purchase purchase)
        {
            return NumberInStock >= purchase.Quantity;
        }
    }
}
