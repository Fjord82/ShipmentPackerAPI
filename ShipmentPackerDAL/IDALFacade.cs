using System;
using ShipmentPackerDAL.UOW;

namespace ShipmentPackerDAL
{
    public interface IDALFacade
    {
        IUnitOfWork UnitOfWork { get; }
    }

}