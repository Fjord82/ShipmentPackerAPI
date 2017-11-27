using System;
using ShipmentPackerDAL.UOW;

namespace ShipmentPackerDAL
{
    public class DALFacade : IDALFacade
    {
        public IUnitOfWork UnitOfWork
        {
            get
            {
                return new UnitOfWork();
            }
        }

    }
}
