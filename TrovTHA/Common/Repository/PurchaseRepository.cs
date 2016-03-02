using Common.Domain;

namespace Common.Repository
{
    public class PurchaseRepository : BaseInMemoryRepository<Purchase>, IPurchaseRepository
    {
        public PurchaseRepository()
        {
            ObjectMother.GetTestPurchases().ForEach(x => Save(x));
        }
    }
}
