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
            var colliList = getColliListMock();
            var newColliList = service.Create(colliList);

            Assert.True(newColliList.Id > 0);

            clearDb();
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
            var colliList = getColliListMock();
            var newColliList = service.Create(colliList);

            var createdCollistList = service.Get(newColliList.Id);
            Assert.Equal(newColliList.ItemType, createdCollistList.ItemType);

            clearDb();
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

            clearDb();
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
