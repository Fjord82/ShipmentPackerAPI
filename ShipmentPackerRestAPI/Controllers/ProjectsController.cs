using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Cors;
using ShipmentPackerBLL.BusinessObjects;
using ShipmentPackerBLL;

namespace ShipmentPackerRestAPI.Controllers
{
    [EnableCors("MyPolicy")]
    [Produces("application/json")]
    [Route("api/Projects")]
    public class ProjectsController : Controller
    {
        BLLFacade facade = new BLLFacade();

        // GET: api/Projects
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Projects/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }
        
        // POST: api/Projects
        [HttpPost]
        public IActionResult Post([FromBody]ProjectBO project)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(facade.ProjectService.Create(project));
        }
        
        // PUT: api/Projects/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }
        
        // DELETE: api/Projects/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
