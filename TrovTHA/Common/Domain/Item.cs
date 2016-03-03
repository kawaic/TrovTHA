
namespace Common.Domain
{
    /// <summary>
    /// An Item that is available for purchase
    /// </summary>
    public class Item : BaseDomain
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
    }
}
