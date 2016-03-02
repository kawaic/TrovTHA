using Common.Domain;

namespace Common.Repository
{
    public class ItemRepository : BaseInMemoryRepository<Item>, IItemRepository
    {
        public ItemRepository()
        {
            ObjectMother.GetTestItems().ForEach(x => Save(x));
        }
    }
}
