
namespace Common.Domain
{
    /// <summary>
    /// Base class implementation of a domain
    /// </summary>
    public abstract class BaseDomain : IDomain
    {
        public string DomainId { get; set; }
    }
}
