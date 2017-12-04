using System;
using System.Collections.Generic;
using System.Linq;
using ShipmentPackerBLL.BusinessObjects;
using ShipmentPackerBLL.Converters;
using ShipmentPackerDAL;

namespace ShipmentPackerBLL.Services
{
    public class ColliListService : IColliListService
    {
        public IDALFacade _facade { get; set; }
        ColliListConverter _conv;
        PackingListConverter _convPL;

        public ColliListService(IDALFacade facade)
        {
            _facade = facade;
            _conv = new ColliListConverter();
            _convPL = new PackingListConverter();
        }

        public ColliListBO Create(ColliListBO colliList)
        {
            if (colliList == null)
            {
                return null;
            }

            using (var uow = _facade.UnitOfWork)
            {
                var createdColliList = uow.ColliListRepository.Create(_conv.ConvertBO(colliList));
                uow.Complete();
                return _conv.Convert(createdColliList);
            }
        }

        public ColliListBO Delete(int Id)
        {
            if (Id < 1)
            {
                return null;
            }
            using (var uow = _facade.UnitOfWork)
            {
                var colliList = Get(Id);
                if (colliList == null)
                {
                    return null;
                }
                colliList = _conv.Convert(uow.ColliListRepository.Delete(Id));
                uow.Complete();
                return colliList;
            }
        }

        public ColliListBO Get(int Id)
        {
            if (Id < 1)
            {
                return null;
            }

            using (var uow = _facade.UnitOfWork)
            {
                var colliList = _conv.Convert(uow.ColliListRepository.Get(Id));
                if(colliList != null)
                {
                    colliList.PackingLists = uow.PackingListRepository.GetAllById(colliList.PackingListIds)
                        .Select(pl => _convPL.Convert(pl))
                        .ToList();
                }
                uow.Complete();
                return colliList;
            }
        }

        public List<ColliListBO> GetAll()
        {
            using (var uow = _facade.UnitOfWork)
            {
                return uow.ColliListRepository.GetAll().Select(cl => _conv.Convert(cl)).ToList();
            }
        }

        public ColliListBO Update(ColliListBO colliList)
        {
            if (colliList == null)
                return null;

            using (var uow = _facade.UnitOfWork)
            {
                var colliListEnt = uow.ColliListRepository.Get(colliList.Id);

                if (colliListEnt == null)
                    return null;

                var colliListUpdated = _conv.ConvertBO(colliList);

                colliListEnt.Id = colliListUpdated.Id;
                colliListEnt.ItemType = colliListUpdated.ItemType;
                colliListEnt.FreightType = colliListUpdated.FreightType;
                colliListEnt.IsActive = colliListUpdated.IsActive;

                if (colliListUpdated.PackingLists != null)
                {
                    colliListEnt.PackingLists.RemoveAll(
                        cl => !colliListUpdated.PackingLists.Exists(
                            pu => pu.PackingListID == cl.PackingListID &&
                            pu.ColliListID == cl.ColliListID));

                    colliListUpdated.PackingLists.RemoveAll(
                        p => colliListEnt.PackingLists.Exists(
                            pu => pu.PackingListID == p.PackingListID &&
                            pu.ColliListID == p.ColliListID));

                    colliListEnt.PackingLists.AddRange(
                        colliListUpdated.PackingLists);
                }

                uow.Complete();
                return _conv.Convert(colliListEnt);
            }
        }
    }
}
