using System;
using System.Collections.Generic;
using System.Linq;
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
            if(packItem == null)
            {
                return null;
            }

            using(var uow = _facade.UnitOfWork)
            {
                var createdPackItem = uow.PackItemRepository.Create(_conv.ConvertBO(packItem));
                uow.Complete();
                return _conv.Convert(createdPackItem);
            }

        }

        public PackItemBO Delete(int Id)
        {
            throw new NotImplementedException();
        }

        public PackItemBO Get(int Id)
        {
            if (Id < 1)
            {
                return null;
            }

            using (var uow = _facade.UnitOfWork)
            {
                var packItem = _conv.Convert(uow.PackItemRepository.Get(Id));

                uow.Complete();
                return packItem;
            }
        }

        public List<PackItemBO> GetAll()
        {
            using (var uow = _facade.UnitOfWork)
            {
                return uow.PackItemRepository.GetAll().Select(pi => _conv.Convert(pi)).ToList();
            }
        }

        public PackItemBO Update(PackItemBO packItem)
        {
            throw new NotImplementedException();
        }
    }
}
