using System;
using System.Collections.Generic;
using System.Linq;
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
            if (Id < 1)
            {
                return null;
            }
            using (var uow = _facade.UnitOfWork)
            {

                var colliItem = Get(Id);
                if (colliItem == null)
                {
                    return null;
                }
                colliItem = _conv.Convert(uow.ColliItemRepository.Delete(Id));
                uow.Complete();
                return colliItem;
            }
        }

        public ColliItemBO Get(int Id)
        {
            if (Id < 1)
            {
                return null;
            }

            using (var uow = _facade.UnitOfWork)
            {
                var colliItem = _conv.Convert(uow.ColliItemRepository.Get(Id));

                uow.Complete();
                return colliItem;
            }
        }

        public List<ColliItemBO> GetAll()
        {
            using (var uow = _facade.UnitOfWork)
            {
                return uow.ColliItemRepository.GetAll().Select(pi => _conv.Convert(pi)).ToList();
            }
        }

        public ColliItemBO Update(ColliItemBO colliItem)
        {
            throw new NotImplementedException();
        }
    }
}
