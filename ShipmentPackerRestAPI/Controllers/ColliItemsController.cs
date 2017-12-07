using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ShipmentPackerBLL;
using ShipmentPackerBLL.BusinessObjects;

namespace ShipmentPackerRestAPI.Controllers
{
    [Route("api/[controller]")]
    public class ColliItemsController : Controller
    {
        BLLFacade _facade = new BLLFacade();

        // GET: api/ColliItems
        [HttpGet]
        public IActionResult Get()
        {
            var colliItem = _facade.ColliItemService.GetAll();
            if (colliItem == null)
            {
                return StatusCode(404, "No colliItems in DB.");
            }
            return Ok(colliItem);
        }

        // GET api/colliItems/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var colliItem = _facade.ColliItemService.Get(id);
            if (colliItem == null)
            {
                return StatusCode(404, "No colliItems found.");
            }
            return Ok(colliItem);
        }

        // POST api/ColliItems
        [HttpPost]
        public IActionResult Post([FromBody]ColliItemBO colliItem)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(_facade.ColliItemService.Create(colliItem));
        }

        // PUT api/ColliItems/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]ColliItemBO colliItem)
        {
            if (id != colliItem.Id)
            {
                return BadRequest("Path ID does not match colliItem ID in JSON object.");
            }
            try
            {
                var updatedColliItem = _facade.ColliItemService.Update(colliItem);
                if (updatedColliItem == null)
                {
                    return StatusCode(404, "No colliItem found with that ID");
                }
                return Ok(updatedColliItem);
            }
            catch (InvalidOperationException e)
            {
                return StatusCode(404, e.Message);
            }
        }

        // DELETE api/colliItems/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var deletedColliItem = _facade.ColliItemService.Delete(id);
            if (deletedColliItem == null)
            {
                return StatusCode(404, "No colliItem found with that ID");
            }
            return Ok(deletedColliItem);
        }
    }
}
