using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using ShipmentPackerBLL;
using ShipmentPackerBLL.BusinessObjects;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ShipmentPackerRestAPI.Controllers
{
    [EnableCors("MyPolicy")]
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class UsersController : Controller
    {
        BLLFacade _facade = new BLLFacade();

        // GET: api/users
        [HttpGet]
        public IActionResult Get()
        {
            var user = _facade.UserService.GetAll();
            if (user == null)
            {
                return StatusCode(404, "No users in DB.");
            }

            return Ok(user);
        }

        // GET api/users/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var user = _facade.UserService.Get(id);
            if (user == null)
            {
                return StatusCode(404, "No user info found.");
            }

            return Ok(user);
        }

        // POST api/users
        [HttpPost]
        public IActionResult Post([FromBody]UserBO user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(_facade.UserService.Create(user));
        }

        // PUT api/users/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]UserBO user)
        {
            if (id != user.Id)
            {
                return BadRequest("Path ID does not match user ID in JSON object.");
            }
            try
            {
                var updatedUser = _facade.UserService.Update(user);
                if (updatedUser == null)
                {
                    return StatusCode(404, "No user found with that ID");
                }
                return Ok(updatedUser);
            }
            catch (Exception e)
            {
                return StatusCode(404, e.Message + "/n" + e.StackTrace);
            }
        }

        // DELETE api/users/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var deletedUser = _facade.UserService.Delete(id);
            if (deletedUser == null)
            {
                return StatusCode(404, "No user found with that ID");
            }

            return Ok(deletedUser);
        }
    }
}
