using System.Collections.Generic;
using System.Web.Http;
using Common.Domain;
using Common.Repository;

namespace TrovTHA.Controllers
{
    [Authorize]
    [RoutePrefix("api/purchases")]
    public class PurchaseController : ApiController
    {
        private readonly IPurchaseRepository repository;

        public PurchaseController(IPurchaseRepository repository)
        {
            this.repository = repository;
        }

        // GET: api/purchases
        [Route("")]
        public IEnumerable<Purchase> Get()
        {
            return repository.FindAll();
        }

        // GET: api/purchases/5
        [Route("{id:int}")]
        public Purchase Get(string id)
        {
            return repository.FindById(id);
        }

        // POST: api/purchases
        [Route("")]
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/purchases/5
        [Route("{id:int}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/purchases/5
        [Route("{id:int}")]
        public void Delete(int id)
        {
        }
    }
}
