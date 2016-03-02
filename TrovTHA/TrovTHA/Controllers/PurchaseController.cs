using System.Collections.Generic;
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

        // POST: api/purchases
        [Route("")]
        public IHttpActionResult Post(Purchase model)
        {
            var userId = User.Identity.GetUserId();
            model.UserId = userId;
            repository.Save(model);
            return Ok();
        }

    }
}
