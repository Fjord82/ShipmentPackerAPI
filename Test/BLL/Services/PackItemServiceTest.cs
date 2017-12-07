using System;
using System.Collections.Generic;
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


        [Fact]
        public void ReadPassTest()
        {
            try
            {
                var packItem = getPackItemMock();
                var newPackItem = service.Create(packItem);

                var createdPackItem = service.Get(newPackItem.Id);
                Assert.Equal(newPackItem.PackingListId, createdPackItem.PackingListId);
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
                var entityPackItem = service.Get(i);

                Assert.Null(entityPackItem);
            }
            clearDb();
        }

        [Fact]
        public void GetAllPassTest()
        {
            try
            {
                List<PackItemBO> createdPackItems = new List<PackItemBO>();
                for (int i = 0; i < 2; i++)
                {
                    var packItem = getPackItemMock();
                    var newPackItem = service.Create(packItem);
                    createdPackItems.Add(newPackItem);
                }

                var packItemList = service.GetAll();
                Assert.Equal(createdPackItems.Count, packItemList.Count);
                Assert.Equal(createdPackItems.ToString(), packItemList.ToString());
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
                var newPackItem = getPackItemMock();
                newPackItem = service.Create(newPackItem);
                var deletedPackItem = service.Delete(newPackItem.Id);

                var checkPackItem = service.Get(deletedPackItem.Id);

                Assert.Null(checkPackItem);
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
                var entityPackItem = service.Delete(i);

                Assert.Null(entityPackItem);
            }
            clearDb();
        }

        [Fact]
        public void UpdatePassTest()
        {
            try
            {
                var originalPackItem = getPackItemMock();
                originalPackItem = service.Create(originalPackItem);

                var newPackItem = new PackItemBO();
                newPackItem.Id = originalPackItem.Id;
                newPackItem.PackingListId = originalPackItem.PackingListId;
                newPackItem.ItemId = originalPackItem.ItemId;
                newPackItem.Count = originalPackItem.Count;
                newPackItem.PackingListId = 5;
                newPackItem = service.Update(newPackItem);

                var updatedPackItem = service.Get(originalPackItem.Id);

                Assert.Equal(originalPackItem.Id, newPackItem.Id);

                Assert.Equal(5, newPackItem.PackingListId);

                Assert.Equal(newPackItem.PackingListId, updatedPackItem.PackingListId);

                Assert.NotEqual(originalPackItem.PackingListId, newPackItem.PackingListId);
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
            var originalPackItem = getPackItemMock();
            originalPackItem = service.Create(originalPackItem);
            var newPackItem = originalPackItem;
            newPackItem.Id++;
            newPackItem = service.Update(newPackItem);

            var nullItem = service.Update(null);

            Assert.Null(nullItem);
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
