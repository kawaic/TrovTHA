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
        public const string NotEnoughInventoryWasFound = "Not enough inventory was found.";

        private readonly IPurchaseRepository purchaseRepository;
        private readonly IInventoryRepository inventoryRepository;

        public PurchaseController(IPurchaseRepository purchaseRepository, IInventoryRepository inventoryRepository)
        {
            this.purchaseRepository = purchaseRepository;
            this.inventoryRepository = inventoryRepository;
        }

        // GET: api/purchases for authenticated user
        [Route("")]
        public IEnumerable<Purchase> Get()
        {
            var userId = User.Identity.GetUserId();
            return purchaseRepository.FindByUserId(userId);
        }

        // POST: api/purchases
        [Route("")]
        public IHttpActionResult Post(Purchase purchase)
        {
            var userId = User.Identity.GetUserId();
            purchase.UserId = userId;

            var inventory = inventoryRepository.FindByItemId(purchase.ItemId);
            lock (inventory)
            {
                if (inventory.HasEnoughStockFor(purchase))
                {
                    inventory.NumberInStock = inventory.NumberInStock - purchase.Quantity;
                    inventoryRepository.Save(inventory);
                    purchaseRepository.Save(purchase);
                    return Ok();
                }
            }
            return BadRequest(NotEnoughInventoryWasFound);
        }

    }
}
