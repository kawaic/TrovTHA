using System.Collections.Generic;
using Common.Domain;

namespace Common.Repository
{
    public interface IItemRepository
    {
        IEnumerable<Item> GetAllItems();


    }
}
