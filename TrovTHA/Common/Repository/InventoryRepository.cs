using System.Linq;
using Common.Domain;

namespace Common.Repository
{
    public class InventoryRepository : BaseInMemoryRepository<Inventory>, IInventoryRepository
    {
        public InventoryRepository()
        {
            ObjectMother.Inventories.ForEach(x => Save(x));
        }

        public Inventory FindByItemId(string itemId)
        {
            return FindAll().FirstOrDefault(inventory => inventory.Item.DomainId == itemId);
        }
    }
}
