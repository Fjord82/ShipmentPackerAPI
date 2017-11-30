using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShipmentPackerBLL;
using ShipmentPackerBLL.BusinessObjects;

namespace ShipmentPackerRestAPI.Controllers
{
    [Produces("application/json")]
    [Route("api/PackingLists")]
    public class PackingListsController : Controller
    {
        BLLFacade facade = new BLLFacade();

        // GET: api/PackingLists
        [HttpGet]
        public IActionResult Get()
        {
            var packingLists = facade.PackingListService.GetAll();
            if (packingLists == null)
            {
                return StatusCode(404, "No packing lists in DB.");
            }

            return Ok(packingLists);
        }

        // GET: api/PackingLists/5
        [HttpGet("{id}", Name = "Get")]
        public IActionResult Get(int id)
        {
            var packingList = facade.PackingListService.Get(id);
            if (packingList == null)
            {
                return StatusCode(404, "No packing list found.");
            }

            return Ok(packingList);
        }
        
        // POST: api/PackingLists
        [HttpPost]
        public IActionResult Post([FromBody]PackingListBO packingList)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(facade.PackingListService.Create(packingList));
        }
        
        // PUT: api/PackingLists/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]PackingListBO packingList)
        {
            if (id != packingList.Id)
            {
                return BadRequest("Path ID does not match packing list ID in JSON object.");
            }
            try
            {
                var updatedPackingList = facade.PackingListService.Update(packingList);
                if (updatedPackingList == null)
                {
                    return StatusCode(404, "No packing list found with that ID");
                }
                return Ok(updatedPackingList);
            }
            catch (InvalidOperationException e)
            {
                return StatusCode(404, e.Message);
            }
        }
        
        // DELETE: api/PackingLists/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var deletedPackingList = facade.PackingListService.Delete(id);
            if (deletedPackingList == null)
            {
                return StatusCode(404, "No packing list found with that ID");
            }

            return Ok(deletedPackingList);
        }
    }
}
