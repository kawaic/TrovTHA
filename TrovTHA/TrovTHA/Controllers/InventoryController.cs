using System.Collections.Generic;
using System.Web.Http;
using Common.Domain;
using Common.Repository;

namespace TrovTHA.Controllers
{
    [RoutePrefix("api/inventories")]
    public class InventoryController : ApiController
    {
        private readonly IInventoryRepository repository;

        public InventoryController(IInventoryRepository repository)
        {
            this.repository = repository;
        }

        // GET api/items]
        [Route("")]
        public IEnumerable<Inventory> Get()
        {
            return repository.FindAll();
        }

        [Route("{id}")]
        // GET api/inventories/5
        public Inventory Get(string id)
        {
            return repository.FindById(id);
        }
    }
}
