using Common.Domain;

namespace Common.Repository
{
    public class InventoryRepository : BaseInMemoryRepository<Inventory>, IInventoryRepository
    {
        public InventoryRepository()
        {
            ObjectMother.Inventories.ForEach(x => Save(x));
        }
    }
}
