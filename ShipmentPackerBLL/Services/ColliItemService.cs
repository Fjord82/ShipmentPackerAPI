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
            if(colliItem == null)
            {
                return null;
            }

            using(var uow = _facade.UnitOfWork)
            {
                var createdColliItem = uow.ColliItemRepository.Create(_conv.ConvertBO(colliItem));
                uow.Complete();
                return _conv.Convert(createdColliItem);
            }
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
