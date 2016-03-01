using System.Collections.Generic;
using System.Web.Http;
using Common.Domain;
using Common.Repository;

namespace TrovTHA.Controllers
{
    [RoutePrefix("api/Item")]
    public class ItemController : ApiController
    {
        private readonly IItemRepository itemRepository;

        public ItemController(IItemRepository itemRepository)
        {
            this.itemRepository = itemRepository;
        }

        // GET api/Item
        public IEnumerable<Item> Get()
        {
            return itemRepository.FindAll();
        }

        // GET api/Item/5
        public Item Get(int id)
        {
            return itemRepository.FindById(id);
        }
    }
}
