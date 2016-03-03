using System.Collections.Generic;
using System.Linq;
using Common.Domain;

namespace Common.Repository
{
    /// <summary>
    /// In memory implementation of purchase persistance
    /// </summary>
    public class PurchaseRepository : BaseInMemoryRepository<Purchase>, IPurchaseRepository
    {
        public PurchaseRepository()
        {
            ObjectMother.Purchases.ForEach(x => Save(x));
        }

        public IEnumerable<Purchase> FindByUserId(string userId)
        {
            return FindAll().Where(purchase => purchase.UserId == userId);
        }
    }
}
