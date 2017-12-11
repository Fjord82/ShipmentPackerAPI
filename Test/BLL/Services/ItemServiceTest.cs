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

        [Fact]
        public void DeletePassTest()
        {
            try
            {
                var newItem = getItemMock();
                newItem = service.Create(newItem);
                var deletedItem = service.Delete(newItem.Id);

                var checkItem = service.Get(deletedItem.Id);

                Assert.Null(checkItem);
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
        public void DeleteFailTest()
        {
            for (int i = -2; i < 5; i++)
            {
                var entityItem = service.Delete(i);

                Assert.Null(entityItem);
            }
            clearDb();
        }

        [Fact]
        public void UpdatePassTest()
        {
            try
            {
                var originalItem = getItemMock();
                originalItem = service.Create(originalItem);

                var newItem = new ItemBO();
                newItem.Id = originalItem.Id;
                newItem.ItemName = originalItem.ItemName;
                newItem.Dimension = originalItem.Dimension;
                newItem.Weight = originalItem.Weight;
                newItem.DangerousGoods = originalItem.DangerousGoods;
                newItem.ItemName = "Bottle";
                newItem = service.Update(newItem);

                var updatedItem = service.Get(originalItem.Id);

                Assert.Equal(originalItem.Id, newItem.Id);

                Assert.Equal("Bottle", newItem.ItemName);

                Assert.Equal(newItem.ItemName, updatedItem.ItemName);

                Assert.NotEqual(originalItem.ItemName, newItem.ItemName);
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
        public void UpdateFailTest()
        {
            var originalItem = getItemMock();
            originalItem = service.Create(originalItem);
            var newItem = originalItem;
            newItem.Id++;
            newItem = service.Update(newItem);

            var nullItem = service.Update(null);

            Assert.Null(nullItem);
            Assert.Null(newItem);

            clearDb();
        }

        public ItemBO getItemMock()
        {
            ItemBO item = new ItemBO()
            {
                ItemName = "Bottle",
                Dimension = "10.0",
                Weight = 2.0,
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
