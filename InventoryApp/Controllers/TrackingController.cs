using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using InventoryApp.Data;
using InventoryApp.Models;

namespace InventoryApp.Controllers
{
    public class TrackingController : ApiController
    {
        private IInventoryRepository _repo;

         public TrackingController(IInventoryRepository repo)
        {
            _repo = repo;
        }

        // GET api/tracking
        [Route("api/v1/tracking")]
        public IEnumerable<Tracking> Get()
        {
            return _repo.GetTrackings();
        }

        [Route("api/v1/tracking/inventoryItem/{inventoryId}")]
        public IEnumerable<Tracking> GetTrackingsForInventoryItem(int inventoryId)
        {
            return _repo.GetTrackings().Where(p => p.InventoryItemId == inventoryId);
        }
    }
}