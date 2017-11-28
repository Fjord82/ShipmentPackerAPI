using System;
using ShipmentPackerBLL.BusinessObjects;
using ShipmentPackerBLL.Converters;
using ShipmentPackerDAL;

namespace ShipmentPackerBLL.Services
{
    public class PackingListService : IPackingListService
    {
        IDALFacade _facade;
        PackingListConverter _conv;

        public PackingListService(IDALFacade facade)
        {
            _facade = facade;
            _conv = new PackingListConverter();
        }

        public PackingListBO Create(PackingListBO packingList)
        {
             /*if(packingList == null)
             {
                 return null;
             }

             using(var uow = _facade.UnitOfWork)
             {
                 var createdPackingList = uow.ProjectRepository.Create(_conv.ConvertBO(packingList));
                 uow.Complete();
                 return _conv.Convert(createdPackingList);
             }*/
            throw new NotImplementedException();
        }
    }
}
