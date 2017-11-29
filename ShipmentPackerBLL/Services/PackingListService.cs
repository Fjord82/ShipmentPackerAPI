using System;
using System.Collections.Generic;
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
            throw new NotImplementedException();
        }

        public PackingListBO Get(int Id)
        {
            throw new NotImplementedException();
        }

        public PackingListBO Update(PackingListBO packingList)
        {
            throw new NotImplementedException();
        }

        public PackingListBO Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}
