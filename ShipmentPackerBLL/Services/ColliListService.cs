﻿using System;
using ShipmentPackerBLL.BusinessObjects;
using ShipmentPackerBLL.Converters;
using ShipmentPackerDAL;

namespace ShipmentPackerBLL.Services
{
    public class ColliListService : IColliListService
    {
        IDALFacade _facade;
        ColliListConverter _conv;

        public ColliListService(IDALFacade facade)
        {
            _facade = facade;
            _conv = new ColliListConverter();
        }

        public ColliListBO Create(ColliListBO colliList)
        {
            /*if (colliList == null)
            {
                return null;
            }

            using (var uow = _facade.UnitOfWork)
            {
                var createdColliList = uow.ProjectRepository.Create(_conv.ConvertBO(colliList));
                uow.Complete();
                return _conv.Convert(createdColliList);
            }*/

            throw new NotImplementedException();
        }
    }
}
