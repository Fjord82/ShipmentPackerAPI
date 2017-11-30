﻿using System;
using System.Collections.Generic;
using System.Linq;
using ShipmentPackerBLL.BusinessObjects;
using ShipmentPackerBLL.Converters;
using ShipmentPackerDAL;

namespace ShipmentPackerBLL.Services
{
    public class PackingListService : IPackingListService
    {
        public IDALFacade _facade { get; set; }
        PackingListConverter _conv;

        public PackingListService(IDALFacade facade)
        {
            _facade = facade;
            _conv = new PackingListConverter();
        }

        public PackingListBO Create(PackingListBO packingList)
        {
             if(packingList == null)
             {
                 return null;
             }

             using(var uow = _facade.UnitOfWork)
             {
                 var createdPackingList = uow.PackingListRepository.Create(_conv.ConvertBO(packingList));
                 uow.Complete();
                 return _conv.Convert(createdPackingList);
             }
        }

        public List<PackingListBO> GetAll()
        {
            using (var uow = _facade.UnitOfWork)
            {
                return uow.PackingListRepository.GetAll().Select(pl => _conv.Convert(pl)).ToList();
            }
        }

        public PackingListBO Get(int Id)
        {
            if (Id < 1)
            {
                return null;
            }

            using (var uow = _facade.UnitOfWork)
            {
                var packingList = uow.PackingListRepository.Get(Id);
                uow.Complete();
                return _conv.Convert(packingList);
            }
        }

        public PackingListBO Update(PackingListBO packingList)
        {
            if (packingList == null)
                return null;

            using (var uow = _facade.UnitOfWork)
            {
                var packingListEnt = uow.PackingListRepository.Get(packingList.Id);

                if (packingListEnt == null)
                    return null;

                var packingListUpdated = _conv.ConvertBO(packingList);

                packingListEnt.Id = packingListUpdated.Id;
                packingListEnt.ItemType = packingListUpdated.ItemType;
                packingListEnt.FreightType = packingListUpdated.FreightType;

                uow.Complete();
                return _conv.Convert(packingListEnt);
            }
        }

        public PackingListBO Delete(int Id)
        {
            if (Id < 1)
            {
                return null;
            }
            using (var uow = _facade.UnitOfWork)
            {

                var packingList = Get(Id);
                if (packingList == null)
                {
                    return null;
                }
                packingList = _conv.Convert(uow.PackingListRepository.Delete(Id));
                uow.Complete();
                return packingList;
            }
        }
    }
}
