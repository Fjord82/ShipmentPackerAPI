using System;
using System.Collections.Generic;
using ShipmentPackerBLL.BusinessObjects;
using ShipmentPackerBLL.Services;
using Test.Mock.DAL;
using Xunit;

namespace Test.BLL.Services
{
    public class ColliListServiceTest
    {
        ColliListService service;
        MockFacade facade;

        public ColliListServiceTest()
        {
            facade = new MockFacade();
            service = new ColliListService(facade);
        }

        [Fact]
        public void CreatePassTest()
        {
            try
            {
                var colliList = getColliListMock();
                var newColliList = service.Create(colliList);

                Assert.True(newColliList.Id > 0);
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
            var newColliList = service.Create(null);

            Assert.Null(newColliList);
        }

        [Fact]
        public void ReadPassTest()
        {
            try
            {
                var colliList = getColliListMock();
                var newColliList = service.Create(colliList);

                var createdCollistList = service.Get(newColliList.Id);
                Assert.Equal(newColliList.ItemType, createdCollistList.ItemType);
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
                var entityColliList = service.Get(i);

                Assert.Null(entityColliList);
            }
            clearDb();
        }

        [Fact]
        public void GetAllPassTest()
        {
            try
            {
                List<ColliListBO> createdColliLists = new List<ColliListBO>();
                for (int i = 0; i < 2; i++)
                {
                    var colliList = getColliListMock();
                    var newColliList = service.Create(colliList);
                    createdColliLists.Add(newColliList);
                }

                var listOfColliList = service.GetAll();
                Assert.Equal(createdColliLists.Count, listOfColliList.Count);
                Assert.Equal(createdColliLists.ToString(), listOfColliList.ToString());
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
                var newColliList = getColliListMock();
                newColliList = service.Create(newColliList);
                var deletedColliList = service.Delete(newColliList.Id);

                var checkColliList = service.Get(deletedColliList.Id);

                Assert.Null(checkColliList);
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
                var entityColliList = service.Delete(i);

                Assert.Null(entityColliList);
            }
            clearDb();
        }

        [Fact]
        public void UpdatePassTest()
        {
            try
            {
                var originalColliList = getColliListMock();
                originalColliList = service.Create(originalColliList);

                var newColliList = new ColliListBO();
                newColliList.Id = originalColliList.Id;
                newColliList.ItemType = originalColliList.ItemType;
                newColliList.FreightType = originalColliList.FreightType;
                newColliList.ItemType = "Light air";
                newColliList = service.Update(newColliList);

                var updatedColliList = service.Get(originalColliList.Id);

                Assert.Equal(originalColliList.Id, newColliList.Id);

                Assert.Equal("Light air", newColliList.ItemType);

                Assert.Equal(newColliList.ItemType, updatedColliList.ItemType);

                Assert.NotEqual(originalColliList.ItemType, newColliList.ItemType);
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
            var originalColliList = getColliListMock();
            originalColliList = service.Create(originalColliList);
            var newColliList = originalColliList;
            newColliList.Id++;
            newColliList = service.Update(newColliList);

            var nullColliList = service.Update(null);

            Assert.Null(nullColliList);
            Assert.Null(newColliList);

        }

        private ColliListBO getColliListMock()
        {
            ColliListBO colliList = new ColliListBO()
            {
                ItemType = "Cylinder",
                FreightType = "Mega tough"
            };

            return colliList;
        }

        private void clearDb()
        {
            service._facade.UnitOfWork.clearDb();
        }
    }
}
