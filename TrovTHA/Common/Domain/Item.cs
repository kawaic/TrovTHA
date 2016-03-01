
namespace Common.Domain
{
    /// <summary>
    /// An Item
    /// </summary>
    public class Item : Domain
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int Price { get; set; }
    }
}
