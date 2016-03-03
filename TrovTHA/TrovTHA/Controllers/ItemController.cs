using System.Collections.Generic;
using System.Web.Http;
using Common.Domain;
using Common.Repository;

namespace TrovTHA.Controllers
{
    /// <summary>
    /// Item controller for managing item resource api/items
    /// </summary>
    [RoutePrefix("api/items")]
    public class ItemController : ApiController
    {
        private readonly IItemRepository itemRepository;

        public ItemController(IItemRepository itemRepository)
        {
            this.itemRepository = itemRepository;
        }

        // GET api/items
        /// <summary>
        /// Gets the list of all items
        /// </summary>
        /// <returns></returns>
        [Route("")]
        public IEnumerable<Item> Get()
        {
            return itemRepository.FindAll();
        }


        // GET api/items/5
        /// <summary>
        /// gets a single itme by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Route("{id}")]
        public Item Get(string id)
        {
            return itemRepository.FindById(id);
        }
    }
}
