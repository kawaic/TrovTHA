using System.Collections.Generic;
using Common.Domain;

namespace Common.Repository
{
    public class InMemoryItemRepository : IItemRepository
    {
        private readonly Dictionary<int, Item> itemList = new Dictionary<int, Item>();

        public InMemoryItemRepository()
        {
            //Add default items
            itemList[itemList.Count] = new Item {Id = itemList.Count, Name = "Apple", Price = 1, Description = "Gala apple."};
            itemList[itemList.Count] = new Item {Id = itemList.Count, Name = "Orange", Price = 1, Description = "Sunkist orange."};
            itemList[itemList.Count] = new Item {Id = itemList.Count, Name = "Ice Cream", Price = 5, Description = "Chocolate ice cream."};
            itemList[itemList.Count] = new Item {Id = itemList.Count, Name = "Carton of Eggs", Price = 1, Description = "A dozen eggs."};
        }


        public IEnumerable<Item> GetAllItems()
        {
            return itemList.Values;
        }

    }
}
