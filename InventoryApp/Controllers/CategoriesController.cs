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
    public class CategoriesController : ApiController
    {
         private IInventoryRepository _repo;

         public CategoriesController(IInventoryRepository repo)
        {
            _repo = repo;
        }

        // GET api/<controller>
        [Route("api/v1/categories")]
        public IEnumerable<Category> Get()
        {
            return _repo.GetCategories();
        }

        [Route("api/v1/categories/{id}")]
        public string Get(int id)
        {
            return "value";
        }

        [Route("api/v1/categories/{categoryId}/items")]
        public IEnumerable<Item> GetItemsForCategory(int categoryId)
        {
            return _repo.GetItemsByCategory(categoryId);
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