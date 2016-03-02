using System.Collections.Generic;
using Common.Domain;

namespace Common.Repository
{
    public interface IInventoryRepository
    {
        IEnumerable<Inventory> FindAll();
        Inventory FindById(string id);
    }
}
