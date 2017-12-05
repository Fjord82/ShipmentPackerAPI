using System;
using System.Collections.Generic;
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

        [Fact]
        public void ReadPassTest()
        {
            try
            {
                clearDb();
                var item = getItemMock();
                var newItem = service.Create(item);

                var createdItem = service.Get(newItem.Id);
                Assert.Equal(newItem.ItemName, createdItem.ItemName);
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
        public void ReadFailTest()
        {
            for (int i = -2; i < 1; i++)
            {
                var entityItem = service.Get(i);

                Assert.Null(entityItem);
            }
            clearDb();
        }

        [Fact]
        public void GetAllPassTest()
        {
            try
            {
                clearDb();
                List<ItemBO> createdItems = new List<ItemBO>();
                for (int i = 0; i < 2; i++)
                {
                    var item = getItemMock();
                    var newItem = service.Create(item);
                    createdItems.Add(newItem);
                }

                var itemList = service.GetAll();
                Assert.Equal(createdItems.Count, itemList.Count);
                Assert.Equal(createdItems.ToString(), itemList.ToString());
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
