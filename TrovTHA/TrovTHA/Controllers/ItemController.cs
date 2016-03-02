using System.Collections.Generic;
using System.Web.Http;
using Common.Domain;
using Common.Repository;

namespace TrovTHA.Controllers
{
    [RoutePrefix("api/items")]
    public class ItemController : ApiController
    {
        private readonly IItemRepository itemRepository;

        public ItemController(IItemRepository itemRepository)
        {
            this.itemRepository = itemRepository;
        }

        // GET api/items]
        [Route("")]
        public IEnumerable<Item> Get()
        {
            return itemRepository.FindAll();
        }

        [Route("{id:int}")]
        // GET api/items/5
        public Item Get(int id)
        {
            return itemRepository.FindById(id);
        }
    }
}
