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
            if (Id < 1)
            {
                return null;
            }
            using (var uow = _facade.UnitOfWork)
            {

                var packItem = Get(Id);
                if (packItem == null)
                {
                    return null;
                }
                packItem = _conv.Convert(uow.PackItemRepository.Delete(Id));
                uow.Complete();
                return packItem;
            }
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
            if (packItem == null)
                return null;

            using (var uow = _facade.UnitOfWork)
            {
                var packItemEnt = uow.PackItemRepository.Get(packItem.Id);

                if (packItemEnt == null)
                    return null;

                var packItemUpdated = _conv.ConvertBO(packItem);

                packItemEnt.Id = packItemUpdated.Id;
                packItemEnt.PackingListId = packItemUpdated.PackingListId;
                packItemEnt.ItemId = packItemUpdated.ItemId;
                packItemEnt.Count = packItemUpdated.Count;

                uow.Complete();
                return _conv.Convert(packItemEnt);
            }
        }
    }
}
