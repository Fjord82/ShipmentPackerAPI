using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
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
    public class PackItemsController : Controller
    {
        BLLFacade _facade = new BLLFacade();

        // GET: api/PackItems
        [HttpGet]
        public IActionResult Get()
        {
            var packItem = _facade.PackItemService.GetAll();
            if(packItem == null)
            {
                return StatusCode(404, "No packItems in DB.");
            }
            return Ok(packItem);
        }

        // GET api/packitems/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var packItem = _facade.PackItemService.Get(id);
            if (packItem == null)
            {
                return StatusCode(404, "No packItems found.");
            }
            return Ok(packItem);
        }

        // POST api/PackItems
        [HttpPost]
        public IActionResult Post([FromBody]PackItemBO packItem)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(_facade.PackItemService.Create(packItem));
        }

        // POST api/PackItems
        [HttpPost("list")]
        public IActionResult Post([FromBody]List<PackItemBO> packItems)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(_facade.PackItemService.CreateList(packItems));
        }

        // PUT api/PackItems/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]PackItemBO packItem)
        {
            if (id != packItem.Id)
            {
                return BadRequest("Path ID does not match packItem ID in JSON object.");
            }
            try
            {
                var updatedPackItem = _facade.PackItemService.Update(packItem);
                if (updatedPackItem == null)
                {
                    return StatusCode(404, "No packItem found with that ID");
                }
                return Ok(updatedPackItem);
            }
            catch (Exception e)
            {
                return StatusCode(404, e.Message + "/n" + e.StackTrace);
            }
        }

        // PUT api/PackItems/5
        [HttpPut("/list")]
        public IActionResult Put([FromBody]List<PackItemBO> packItems)
        {
            if (packItems == null)
            {
                return BadRequest("Update list is empty.");
            }
            try
            {
                var updatedPackItems = _facade.PackItemService.UpdateList(packItems);

                return Ok(updatedPackItems);
            }
            catch (Exception e)
            {
                return StatusCode(404, e.Message + "/n" + e.StackTrace);
            }
        }

        // DELETE api/packItems/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var deletedPackItem = _facade.PackItemService.Delete(id);
            if (deletedPackItem == null)
            {
                return StatusCode(404, "No packItem found with that ID");
            }
            return Ok(deletedPackItem);
        }
    }
}
