namespace Common.Domain
{
    /// <summary>
    /// The inventory information for an item at a location
    /// </summary>
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
