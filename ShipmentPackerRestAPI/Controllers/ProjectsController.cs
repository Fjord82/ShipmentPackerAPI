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
        public IActionResult Get()
        {
            var projects = facade.ProjectService.GetAll();
            if (projects == null)
            {
                return StatusCode(404, "No projects in DB.");
            }

            return Ok(projects);
        }

        // GET: api/Projects/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var project = facade.ProjectService.Get(id);
            if (project == null)
            {
                return StatusCode(404, "No project found.");
            }

            return Ok(project);
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
        public IActionResult Put(int id, [FromBody]ProjectBO project)
        {
            if (id != project.Id)
            {
                return BadRequest("Path ID does not match project ID in JSON object.");
            }
            try
            {
                var updatedProject = facade.ProjectService.Update(project);
                if (updatedProject == null)
                {
                    return StatusCode(404, "No project found with that ID");
                }
                return Ok(updatedProject);
            }
            catch (Exception e)
            {
                return StatusCode(404, e.Message + "/n" + e.StackTrace);
            }
        }
        
        // DELETE: api/Projects/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var deletedProject = facade.ProjectService.Delete(id);
            if (deletedProject == null)
            {
                return StatusCode(404, "No project found with that ID");
            }

            return Ok(deletedProject);
        }
    }
}
