using System;
using System.Collections.Generic;
using ShipmentPackerBLL.BusinessObjects;
using ShipmentPackerBLL.Converters;
using ShipmentPackerDAL;

namespace ShipmentPackerBLL.Services
{
    public class ColliItemService : IColliItemService
    {
        public IDALFacade _facade;
        ColliItemConverter _conv;

        public ColliItemService(IDALFacade facade)
        {
            _facade = facade;
            _conv = new ColliItemConverter();
        }

        public ColliItemBO Create(ColliItemBO colliItem)
        {
            throw new NotImplementedException();
        }

        public ColliItemBO Delete(int Id)
        {
            throw new NotImplementedException();
        }

        public ColliItemBO Get(int Id)
        {
            throw new NotImplementedException();
        }

        public List<ColliItemBO> GetAll()
        {
            throw new NotImplementedException();
        }

        public ColliItemBO Update(ColliItemBO colliItem)
        {
            throw new NotImplementedException();
        }
    }
}
