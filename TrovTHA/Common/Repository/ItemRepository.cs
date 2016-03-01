using Common.Domain;

namespace Common.Repository
{
    public class ItemRepository : BaseInMemoryRepository<Item>, IItemRepository
    {

        public ItemRepository()
        {
            int seq = 0;
            //Add default items
            Save(new Item {Id = ++seq, Name = "Apple", Price = 1, Description = "Gala apple."});
            Save(new Item {Id = ++seq, Name = "Orange", Price = 1, Description = "Sunkist orange."});
            Save(new Item {Id = ++seq, Name = "Ice Cream", Price = 5, Description = "Chocolate ice cream."});
            Save(new Item {Id = ++seq, Name = "Carton of Eggs", Price = 1, Description = "A dozen eggs."});
        }

    }
}
