using System.Collections.Generic;
using Common.Domain;

namespace Common.Repository
{
    public interface IItemRepository
    {
        IEnumerable<Item> FindAll();

        Item FindById(int id);
    }
}
