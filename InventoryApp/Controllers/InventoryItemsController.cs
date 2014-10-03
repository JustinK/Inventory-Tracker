using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using InventoryApp.Data;
using InventoryApp.Models;

namespace InventoryApp.Controllers
{
    public class InventoryItemsController : ApiController
    {
        private IInventoryRepository _repo;

        public InventoryItemsController(IInventoryRepository repo)
        {
            _repo = repo;
        }
        // GET api/v1/inventoryitems
        public IEnumerable<InventoryItem> Get()
        {
            try
            {
                var items = _repo.GetInventoryItems().OrderByDescending(t => t.DateAdded).Take(50);
                return items;
            }
            catch (Exception ex)
            {
                
                Debug.WriteLine(ex);
            }
            return new List<InventoryItem>();

        }

        // GET api/v1/inventoryitems/5
        public InventoryItem Get(int id)
        {
            return _repo.GetInventoryItemById(id);
        }

        // POST api/<controller>
        public HttpResponseMessage Post([FromBody]InventoryItem inventoryItem)
        {
            if (_repo.AddInventoryItem(inventoryItem) && _repo.Save())
            {
                return Request.CreateResponse(HttpStatusCode.Created, inventoryItem);
            }
            return Request.CreateResponse(HttpStatusCode.BadRequest);
        }

        // PUT api/v1/inventoryitems/5
        public HttpResponseMessage Put(int id, [FromBody]InventoryItem inventoryItem)
        {
            inventoryItem.DateModified = DateTime.Now;
            if (_repo.UpdateInventoryItem(inventoryItem) && _repo.Save())
            {
                return Request.CreateResponse(HttpStatusCode.Accepted, inventoryItem);
            }
            return Request.CreateResponse(HttpStatusCode.BadRequest);
        }

        // DELETE api/v1/inventoryitems/5
        public HttpResponseMessage Delete(int id)
        {
            return Request.CreateResponse(HttpStatusCode.BadRequest);
        }
    }
}