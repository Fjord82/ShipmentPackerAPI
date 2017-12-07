using System;
using ShipmentPackerBLL.BusinessObjects;
using ShipmentPackerBLL.Services;
using Test.Mock.DAL;
using Xunit;

namespace Test.BLL.Services
{
    public class ColliItemServiceTest
    {
        ColliItemService service;
        MockFacade facade;

        public ColliItemServiceTest()
        {
            facade = new MockFacade();
            service = new ColliItemService(facade);
        }

        [Fact]
        public void CreatePassTest()
        {
            try
            {
                var colliItem = getColliItemMock();
                var newColliItem = service.Create(colliItem);

                Assert.True(newColliItem.Id > 0);
            }
            catch (Exception e)
            {
                Assert.True(false, e.Message);
            }
            finally
            {
                clearDb();
            }
        }

        [Fact]
        public void CreateFailTest()
        {
            var newColliItem = service.Create(null);

            Assert.Null(newColliItem);

            clearDb();
        }

        public ColliItemBO getColliItemMock()
        {
            ColliItemBO colliItem = new ColliItemBO()
            {
                ColliListId = 1,
                ItemId = 2,
                Count = 50
            };

            return colliItem;
        }


        private void clearDb()
        {
            service._facade.UnitOfWork.clearDb();
        }
    }
}
