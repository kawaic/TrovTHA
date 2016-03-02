using System;

namespace Common.Domain
{
    public class Purchase : BaseDomain
    {
        public DateTime DateTime { get; set; }
        public int ItemId { get; set; }

    }
}
