using Common.Domain;

namespace Common.Repository
{
    /// <summary>
    /// In memory implementation of item persistance
    /// </summary>
    public class ItemRepository : BaseInMemoryRepository<Item>, IItemRepository
    {
        public ItemRepository()
        {
            ObjectMother.Items.ForEach(x => Save(x));
        }
    }
}
