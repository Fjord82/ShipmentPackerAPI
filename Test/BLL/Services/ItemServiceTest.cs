using System;
using ShipmentPackerBLL.BusinessObjects;
using ShipmentPackerBLL.Services;
using Test.Mock.DAL;

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

        public ItemBO getItemMock()
        {
            ItemBO item = new ItemBO()
            {
                ItemName = "Bottle",
                DangerousGoods = true
            };

            return item;
        }


        private void clearDb()
        {
            service._facade.UnitOfWork.clearDb();
        }
    }
}
