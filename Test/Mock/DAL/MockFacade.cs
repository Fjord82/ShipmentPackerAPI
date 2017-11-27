using System;
using ShipmentPackerDAL;

namespace Test.Mock.DAL
{
    public class MockFacade : IDALFacade
    {
        public IUnitOfWork UnitOfWork
        {
            get
            {
                return new MockUnitOfWork();
            }
        }
    }
}
