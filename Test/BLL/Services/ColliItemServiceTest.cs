using System;
using System.Collections.Generic;
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

        [Fact]
        public void ReadPassTest()
        {
            try
            {
                var colliItem = getColliItemMock();
                var newColliItem = service.Create(colliItem);

                var createdColliItem = service.Get(newColliItem.Id);
                Assert.Equal(newColliItem.ColliListId, createdColliItem.ColliListId);
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
                var entityColliItem = service.Get(i);

                Assert.Null(entityColliItem);
            }
            clearDb();
        }

        [Fact]
        public void GetAllPassTest()
        {
            try
            {
                List<ColliItemBO> createdColliItems = new List<ColliItemBO>();
                for (int i = 0; i < 2; i++)
                {
                    var colliItem = getColliItemMock();
                    var newColliItem = service.Create(colliItem);
                    createdColliItems.Add(newColliItem);
                }

                var colliItemList = service.GetAll();
                Assert.Equal(createdColliItems.Count, colliItemList.Count);
                Assert.Equal(createdColliItems.ToString(), colliItemList.ToString());
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
                var newColliItem = getColliItemMock();
                newColliItem = service.Create(newColliItem);
                var deletedColliItem = service.Delete(newColliItem.Id);

                var checkColliItem = service.Get(deletedColliItem.Id);

                Assert.Null(checkColliItem);
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
                var entityColliItem = service.Delete(i);

                Assert.Null(entityColliItem);
            }
            clearDb();
        }

        [Fact]
        public void UpdatePassTest()
        {
            try
            {
                var originalColliItem = getColliItemMock();
                originalColliItem = service.Create(originalColliItem);

                var newColliItem = new ColliItemBO();
                newColliItem.Id = originalColliItem.Id;
                newColliItem.ColliListId = originalColliItem.ColliListId;
                newColliItem.ItemId = originalColliItem.ItemId;
                newColliItem.Count = originalColliItem.Count;
                newColliItem.ColliListId = 5;
                newColliItem = service.Update(newColliItem);

                var updatedColliItem = service.Get(originalColliItem.Id);

                Assert.Equal(originalColliItem.Id, newColliItem.Id);

                Assert.Equal(5, newColliItem.ColliListId);

                Assert.Equal(newColliItem.ColliListId, updatedColliItem.ColliListId);

                Assert.NotEqual(originalColliItem.ColliListId, newColliItem.ColliListId);
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
            var originalColliItem = getColliItemMock();
            originalColliItem = service.Create(originalColliItem);
            var newColliItem = originalColliItem;
            newColliItem.Id++;
            newColliItem = service.Update(newColliItem);

            var nullItem = service.Update(null);

            Assert.Null(nullItem);
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
