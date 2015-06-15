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
    public class ItemsController : ApiController
    {
        private IInventoryRepository _repo;

        public ItemsController(IInventoryRepository repo)
        {
            _repo = repo;
        }
        [Route("api/v1/items")]
        public IEnumerable<Item> Get()
        {
            return _repo.GetItems();
        }

        [Route("api/v1/items/{id}")]
        public Item Get(int id)
        {
            return _repo.GetItems().SingleOrDefault(p => p.Id == id);
        }

        // POST api/<controller>
        public void Post([FromBody]string value)
        {
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }
}