using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShipmentPackerBLL;
using ShipmentPackerDAL;

namespace ShipmentPackerRestAPI.Controllers
{
    [EnableCors("MyPolicy")]
    [Produces("application/json")]
    [Route("api/Reset")]
    public class ResetController : Controller
    {
        DALFacade facade = new DALFacade();
        // POST: api/Reset
        [HttpPost("{value}")]
        public IActionResult Post(string value)
        {
            if (value.Equals("FixDatDbDaddy"))
            {
                facade.UnitOfWork.clearDb();
                return Ok("DB reset.");
            }
            else
                return BadRequest("What's the magic word?");
        }
    }
}
