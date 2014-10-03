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
    public class LocationsController : ApiController
    {
        private IInventoryRepository _repo;

        public LocationsController(IInventoryRepository repo)
        {
            _repo = repo;
        }
        // GET api/<controller>
        public IEnumerable<Location> Get()
        {
            return _repo.GetLocations();
        }

        // GET api/<controller>/5
        public string Get(int id)
        {
            return "value";
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