using System.Collections.Generic;
using Common.Domain;

namespace Common.Repository
{
    /// <summary>
    /// Interface contract for purchase persistance
    /// </summary>
    public interface IPurchaseRepository
    {
        Purchase Save(Purchase purchase);
        IEnumerable<Purchase> FindAll();
        Purchase FindById(string id);
        IEnumerable<Purchase> FindByUserId(string userId);
    }
}
