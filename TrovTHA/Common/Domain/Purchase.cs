using System;

namespace Common.Domain
{
    /// <summary>
    /// A purchase order for a quantity of an item 
    /// </summary>
    public class Purchase : BaseDomain
    {
        public DateTime DateTime { get; set; }
        public string ItemId { get; set; }
        public string UserId { get; set; }
        public int Quantity { get; set; }
    }
}
