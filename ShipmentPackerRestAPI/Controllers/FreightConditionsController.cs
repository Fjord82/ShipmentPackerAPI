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
    public class FreightConditionsController : Controller
    {
        BLLFacade _facade = new BLLFacade();

        // GET: api/values
        [HttpGet]
        public IActionResult Get()
        {
            var condition = _facade.FreightConditionService.GetAll();
            if (condition == null)
            {
                return StatusCode(404, "No freight infos in DB.");
            }

            return Ok(condition);
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var condition = _facade.FreightConditionService.Get(id);
            if (condition == null)
            {
                return StatusCode(404, "No freight info found.");
            }

            return Ok(condition);
        }

        // POST api/values
        [HttpPost]
        public IActionResult Post([FromBody]FreightConditionBO condition)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(_facade.FreightConditionService.Create(condition));
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]FreightConditionBO condition)
        {
            if (id != condition.Id)
            {
                return BadRequest("Path ID does not match freight condition ID in JSON object.");
            }
            try
            {
                var updatedCondition = _facade.FreightConditionService.Update(condition);
                if (updatedCondition == null)
                {
                    return StatusCode(404, "No freight condition found with that ID");
                }
                return Ok(updatedCondition);
            }
            catch (Exception e)
            {
                return StatusCode(404, e.Message + "/n" + e.StackTrace);
            }
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var deletedCondition = _facade.FreightConditionService.Delete(id);
            if (deletedCondition == null)
            {
                return StatusCode(404, "No freight condition found with that ID");
            }

            return Ok(deletedCondition);
        }
    }
}
