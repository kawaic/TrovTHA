using System;

namespace Common.Domain
{
    public class Purchase : BaseDomain
    {
        public DateTime DateTime { get; set; }
        public string ItemId { get; set; }
        public string UserId { get; set; }
    }
}
