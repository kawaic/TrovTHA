using System.Collections.Generic;
using System.Web.Http;
using Common.Domain;
using Common.Repository;

namespace TrovTHA.Controllers
{
    [Authorize]
    [RoutePrefix("api/Purchase")]
    public class PurchaseController : ApiController
    {
        private readonly IPurchaseRepository repository;

        public PurchaseController(IPurchaseRepository repository)
        {
            this.repository = repository;
        }

        // GET: api/Purchase
        public IEnumerable<Purchase> Get()
        {
            return repository.FindAll();
        }

        // GET: api/Purchase/5
        public Purchase Get(int id)
        {
            return repository.FindById(id);
        }

        // POST: api/Purchase
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Purchase/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Purchase/5
        public void Delete(int id)
        {
        }
    }
}
