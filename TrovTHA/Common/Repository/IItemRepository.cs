using System.Collections.Generic;

namespace Common.Repository
{
    public interface IItemRepository
    {
        IEnumerable<Item> GetAllItems();


    }
}
