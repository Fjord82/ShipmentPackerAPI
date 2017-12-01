using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShipmentPackerBLL;
using ShipmentPackerDAL;

namespace ShipmentPackerRestAPI.Controllers
{
    [Produces("application/json")]
    [Route("api/Reset")]
    public class ResetController : Controller
    {
        DALFacade facade = new DALFacade();
        // POST: api/Reset
        [HttpPost]
        public void Post([FromBody]string value)
        {
            if (value.Equals("FixDatDbDaddy"))
            {
                facade.UnitOfWork.clearDb();
            }
        }
    }
}
