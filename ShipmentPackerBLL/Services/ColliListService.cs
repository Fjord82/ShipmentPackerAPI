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

        public ColliListService(IDALFacade facade)
        {
            _facade = facade;
            _conv = new ColliListConverter();
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
            throw new NotImplementedException();
        }

        public ColliListBO Get(int Id)
        {
            if (Id < 1)
            {
                return null;
            }

            using (var uow = _facade.UnitOfWork)
            {
                var colliList = uow.ColliListRepository.Get(Id);
                uow.Complete();
                return _conv.Convert(colliList);
            }
        }

        public List<ColliListBO> GetAll()
        {
            using (var uow = _facade.UnitOfWork)
            {
                return uow.ColliListRepository.GetAll().Select(cl => _conv.Convert(cl)).ToList();
            }
        }

        public ColliListBO Update(ColliListBO project)
        {
            throw new NotImplementedException();
        }
    }
}
