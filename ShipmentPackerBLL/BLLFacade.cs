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

        public IPackingListService PackingListService
        {
            get { return new PackingListService(new DALFacade()); }
        }

        public IColliListService ColliListService
        {
            get { return new ColliListService(new DALFacade()); }
        }

        public IItemService ItemService
        {
            get { return new ItemService(new DALFacade()); }
        }

        public IPackItemService PackItemService
        {
            get { return new PackItemService(new DALFacade()); }
        }

        public IColliItemService ColliItemService
        {
            get { return new ColliItemService(new DALFacade()); }
        }

        public IFreightConditionService FreightConditionService
        {
            get { return new FreightConditionService(new DALFacade()); }
        }
    }
}
