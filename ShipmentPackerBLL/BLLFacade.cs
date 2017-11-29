using ShipmentPackerBLL.Services;
using ShipmentPackerDAL;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShipmentPackerBLL
{
    public class BLLFacade
    {
        public IProjectService ProjectService
        {
            // Totally testing stuff
            get { return new ProjectService(new DALFacade()); }
        }
    }
}
