using System.Collections.Generic;
using System.Web.Http;
using Common.Domain;
using Common.Repository;

namespace TrovTHA.Controllers
{
    /// <summary>
    /// Inventory controller for managing inventory resource api/inventories
    /// </summary>
    [RoutePrefix("api/inventories")]
    public class InventoryController : ApiController
    {
        private readonly IInventoryRepository repository;

        public InventoryController(IInventoryRepository repository)
        {
            this.repository = repository;
        }

        // GET api/items]
        /// <summary>
        /// Gets the list of all inventories
        /// </summary>
        /// <returns></returns>
        [Route("")]
        public IEnumerable<Inventory> Get()
        {
            return repository.FindAll();
        }

    }
}
