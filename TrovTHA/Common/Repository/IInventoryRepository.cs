using System.Collections.Generic;
using Common.Domain;

namespace Common.Repository
{
    /// <summary>
    /// Interface contract for persistance of inventory
    /// </summary>
    public interface IInventoryRepository
    {
        IEnumerable<Inventory> FindAll();
        Inventory FindById(string id);
        Inventory FindByItemId(string itemId);
        Inventory Save(Inventory inventory);
    }
}
