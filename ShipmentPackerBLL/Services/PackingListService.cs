using System;
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
        ProjectConverter _conv;
        PackingListConverter _convPL;
        ColliListConverter _convCL;
        PackItemConverter _convPI;
        ItemConverter _convI;

        public PackingListService(IDALFacade facade)
        {
            _facade = facade;
            _convPL = new PackingListConverter();
            _conv = new ProjectConverter();
            _convCL = new ColliListConverter();
            _convPI = new PackItemConverter();
            _convI = new ItemConverter();
        }

        public PackingListBO Create(PackingListBO packingList)
        {
            if (packingList == null)
            {
                return null;
            }

            using (var uow = _facade.UnitOfWork)
            {
                var createdPackingList = uow.PackingListRepository.Create(_convPL.ConvertBO(packingList));
                uow.Complete();
                return _convPL.Convert(createdPackingList);
            }
        }

        public List<PackingListBO> GetAll()
        {
            using (var uow = _facade.UnitOfWork)
            {
                return uow.PackingListRepository.GetAll().Select(pl => _convPL.Convert(pl)).ToList();
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
                var packingList = _convPL.Convert(uow.PackingListRepository.Get(Id));
                if (packingList != null)
                {
                    packingList.Projects = uow.ProjectRepository.GetAllById(packingList.ProjectIds)
                        .Select(p => _conv.Convert(p))
                        .ToList();

                    packingList.ColliLists = uow.ColliListRepository.GetAllById(packingList.ColliListIds)
                        .Select(cl => _convCL.Convert(cl))
                        .ToList();

                    packingList.PackItems = uow.PackItemRepository.GetAllById(packingList.PackItemsIds)
                        .Select(pi => _convPI.Convert(pi))
                        .ToList();

                }
                uow.Complete();
                return packingList;
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

                var packingListUpdated = _convPL.ConvertBO(packingList);

                packingListEnt.Id = packingListUpdated.Id;
                packingListEnt.PackingName = packingListUpdated.PackingName;
                packingListEnt.CreatorName = packingListUpdated.CreatorName;
                packingListEnt.DeliveryAddress = packingListUpdated.DeliveryAddress;
                packingListEnt.DeliveryDate = packingListUpdated.DeliveryDate;
                packingListEnt.ItemType = packingListUpdated.ItemType;
                packingListEnt.FreightType = packingListUpdated.FreightType;
                packingListEnt.IsActive = packingListUpdated.IsActive;

                if (packingListUpdated != null)
                {
                    //Related to Project relation
                    packingListEnt.Projects.RemoveAll(
                        pu => !packingListUpdated.Projects.Exists(
                            p => p.ProjectID == pu.ProjectID &&
                            p.PackingListID == pu.PackingListID));

                    packingListUpdated.Projects.RemoveAll(
                        pu => packingListEnt.Projects.Exists(
                            p => p.ProjectID == pu.ProjectID &&
                            p.PackingListID == pu.PackingListID));

                    packingListEnt.Projects.AddRange(
                        packingListUpdated.Projects);

                    //Related to ColliList
                    packingListEnt.ColliLists.RemoveAll(
                        pu => !packingListUpdated.ColliLists.Exists(
                            p => p.ColliListID == pu.ColliListID &&
                            p.PackingListID == pu.PackingListID));

                    packingListUpdated.ColliLists.RemoveAll(
                        pu => packingListEnt.ColliLists.Exists(
                            p => p.ColliListID == pu.ColliListID &&
                            p.PackingListID == pu.PackingListID));

                    packingListEnt.ColliLists.AddRange(
                        packingListUpdated.ColliLists);

                }

                uow.Complete();
                return _convPL.Convert(packingListEnt);
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
                packingList = _convPL.Convert(uow.PackingListRepository.Delete(Id));
                uow.Complete();
                return packingList;
            }
        }
    }
}
