using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;
using Common.Domain;
using Common.Repository;
using Microsoft.AspNet.Identity;

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

        // GET: api/purchases for authenticated user
        [Route("")]
        public IEnumerable<Purchase> Get()
        {
            var userId = User.Identity.GetUserId();
            return repository.FindByUserId(userId);
        }

        // GET: api/purchases/5
        [Route("{id:int}")]
        public Purchase Get(string id)
        {
            return repository.FindById(id);
        }

        // POST: api/purchases
        [Route("")]
        public IHttpActionResult Post(Purchase model)
        {
            var userId = User.Identity.GetUserId();
            model.UserId = userId;
            repository.Save(model);
            return Ok();
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
