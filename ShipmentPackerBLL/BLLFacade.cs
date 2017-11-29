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
            get { return new ProjectService(new DALFacade()); }
        }
    }
}
