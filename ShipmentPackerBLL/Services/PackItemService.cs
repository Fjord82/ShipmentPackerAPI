using System;
using System.Collections.Generic;
using ShipmentPackerBLL.BusinessObjects;
using ShipmentPackerBLL.Converters;
using ShipmentPackerDAL;

namespace ShipmentPackerBLL.Services
{
    public class PackItemService : IPackItemService
    {
        public IDALFacade _facade { get; set; }
        PackItemConverter _conv;

        public PackItemService(IDALFacade facade)
        {
            _facade = facade;
            _conv = new PackItemConverter();
        }

        public PackItemBO Create(PackItemBO packItem)
        {
            throw new NotImplementedException();
        }

        public PackItemBO Delete(int Id)
        {
            throw new NotImplementedException();
        }

        public PackItemBO Get(int Id)
        {
            throw new NotImplementedException();
        }

        public List<PackItemBO> GetAll()
        {
            throw new NotImplementedException();
        }

        public PackItemBO Update(PackItemBO packItem)
        {
            throw new NotImplementedException();
        }
    }
}
