using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using ShipmentPackerBLL;
using ShipmentPackerBLL.BusinessObjects;

namespace ShipmentPackerRestAPI.Controllers
{
    [EnableCors("MyPolicy")]
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class ItemsController : Controller
    {
        BLLFacade facade = new BLLFacade();

        // GET: api/items
        [HttpGet]
        public IActionResult Get()
        {
            var item = facade.ItemService.GetAll();
            if (item == null)
            {
                return StatusCode(404, "No items in DB.");
            }

            return Ok(item);
        }

        // GET api/items/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var item = facade.ItemService.Get(id);
            if (item == null)
            {
                return StatusCode(404, "No items found.");
            }

            return Ok(item);
        }

        // POST api/items
        [HttpPost]
        public IActionResult Post([FromBody]ItemBO item)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(facade.ItemService.Create(item));
        }

        // PUT api/items/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]ItemBO item)
        {
            if (id != item.Id)
            {
                return BadRequest("Path ID does not match item ID in JSON object.");
            }
            try
            {
                var updatedItem = facade.ItemService.Update(item);
                if (updatedItem == null)
                {
                    return StatusCode(404, "No item found with that ID");
                }
                return Ok(updatedItem);
            }
            catch (Exception e)
            {
                return StatusCode(404, e.StackTrace + "/n" + e.Message);
            }
        }

        // DELETE api/items/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var deletedItem = facade.ItemService.Delete(id);
            if (deletedItem == null)
            {
                return StatusCode(404, "No item found with that ID");
            }

            return Ok(deletedItem);
        }
    }
}
