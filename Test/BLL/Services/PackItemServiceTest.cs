using System;
using ShipmentPackerBLL.BusinessObjects;
using ShipmentPackerBLL.Services;
using Test.Mock.DAL;
using Xunit;

namespace Test.BLL.Services
{
    public class PackItemServiceTest
    {
        PackItemService service;
        MockFacade facade;

        public PackItemServiceTest()
        {
            facade = new MockFacade();
            service = new PackItemService(facade);
        }

        [Fact]
        public void CreatePassTest()
        {
            try
            {
                var packItem = getPackItemMock();
                var newPackItem = service.Create(packItem);

                Assert.True(newPackItem.Id > 0);
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
            var newPackItem = service.Create(null);

            Assert.Null(newPackItem);

            clearDb();
        }

        public PackItemBO getPackItemMock()
        {
            PackItemBO packItem = new PackItemBO()
            {
                PackingListId = 1,
                ItemId = 2,
                Count = 50
            };

            return packItem;
        }


        private void clearDb()
        {
            service._facade.UnitOfWork.clearDb();
        }
    }
}
