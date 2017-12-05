using System;
using ShipmentPackerBLL.BusinessObjects;
using ShipmentPackerBLL.Services;
using Test.Mock.DAL;
using Xunit;

namespace Test.BLL.Services
{
    public class ItemServiceTest
    {
        ItemService service;
        MockFacade facade;

        public ItemServiceTest()
        {
            facade = new MockFacade();
            service = new ItemService(facade);
        }

        [Fact]
        public void CreatePassTest()
        {
            try
            {
                clearDb();
                var item = getItemMock();
                var newItem = service.Create(item);

                Assert.True(newItem.Id > 0);
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
            var newItem = service.Create(null);

            Assert.Null(newItem);

            clearDb();
        }


        public ItemBO getItemMock()
        {
            ItemBO item = new ItemBO()
            {
                ItemName = "Bottle",
                DangerousGoods = false
            };

            return item;
        }


        private void clearDb()
        {
            service._facade.UnitOfWork.clearDb();
        }
    }
}
