using System.Collections.Generic;
using Common.Domain;

namespace Common.Repository
{
    /// <summary>
    /// Interface contract for persistance of an item
    /// </summary>
    public interface IItemRepository
    {
        IEnumerable<Item> FindAll();

        Item FindById(string id);
    }
}
