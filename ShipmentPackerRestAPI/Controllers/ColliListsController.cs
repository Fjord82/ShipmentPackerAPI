using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShipmentPackerBLL.BusinessObjects;
using ShipmentPackerBLL;
using Microsoft.AspNetCore.Cors;

namespace ShipmentPackerRestAPI.Controllers
{
    [EnableCors("MyPolicy")]
    [Produces("application/json")]
    [Route("api/ColliLists")]
    public class ColliListsController : Controller
    {
        BLLFacade facade = new BLLFacade();

        // GET: api/ColliLists
        [HttpGet]
        public IActionResult Get()
        {
            var colliLists = facade.ColliListService.GetAll();
            if (colliLists == null)
            {
                return StatusCode(404, "No colli lists in DB.");
            }

            return Ok(colliLists);
        }

        // GET: api/ColliLists/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var colliList = facade.ColliListService.Get(id);
            if (colliList == null)
            {
                return StatusCode(404, "No colli list found.");
            }

            return Ok(colliList);
        }
        
        // POST: api/ColliLists
        [HttpPost]
        public IActionResult Post([FromBody]ColliListBO colliList)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(facade.ColliListService.Create(colliList));
        }
        
        // PUT: api/ColliLists/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]ColliListBO colliList)
        {
            if (id != colliList.Id)
            {
                return BadRequest("Path ID does not match colli list ID in JSON object.");
            }
            try
            {
                var updatedColliList = facade.ColliListService.Update(colliList);
                if (updatedColliList == null)
                {
                    return StatusCode(404, "No colli list found with that ID");
                }
                return Ok(updatedColliList);
            }
            catch (Exception e)
            {
                return StatusCode(404, e.Message);
            }
        }
        
        // DELETE: api/ColliList/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var deletedColliList = facade.ColliListService.Delete(id);
            if (deletedColliList == null)
            {
                return StatusCode(404, "No colli list found with that ID");
            }

            return Ok(deletedColliList);
        }
    }
}
