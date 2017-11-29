using System.Collections.Generic;
using ShipmentPackerBLL.BusinessObjects;
using ShipmentPackerBLL.Services;
using Test.Mock.DAL;
using Xunit;

namespace Test.BLL.Services
{
    public class PackingListServiceTest
    {
        PackingListService service;
        MockFacade facade;

        public PackingListServiceTest()
        {
            facade = new MockFacade();
            service = new PackingListService(facade);
        }

        [Fact]
        public void CreatePassTest()
        {

            var packingList = getPackingListMock();
            var newPackingList = service.Create(packingList);

            Assert.True(newPackingList.Id > 0);

            clearDb();
        }

        [Fact]
        public void CreateFailTest()
        {
            var newPackingList = service.Create(null);

            Assert.Null(newPackingList);

            clearDb();
        }


        [Fact]
        public void ReadPassTest()
        {
            var packingList = getPackingListMock();
            var newPackingList = service.Create(packingList);

            var createdPackingList = service.Get(newPackingList.Id);
            Assert.Equal(newPackingList.ItemType, createdPackingList.ItemType);

            clearDb();
        }

        [Fact]
        public void ReadFailTest()
        {
            for (int i = -2; i < 1; i++)
            {
                var entityPackingList = service.Get(i);

                Assert.Null(entityPackingList);
            }
            clearDb();
        }

        [Fact]
        public void GetAllPassTest()
        {
            List<PackingListBO> createdPackingLists = new List<PackingListBO>();
            for (int i = 0; i < 2; i++)
            {
                var packingList = getPackingListMock();
                var newPackingList = service.Create(packingList);
                createdPackingLists.Add(newPackingList);
            }

            var listOfPackingList = service.GetAll();
            Assert.Equal(createdPackingLists.Count, listOfPackingList.Count);
            Assert.Equal(createdPackingLists.ToString(), listOfPackingList.ToString());

            clearDb();
        }

        [Fact]
        public void DeletePassTest()
        {
            var newPackingList = getPackingListMock();
            newPackingList = service.Create(newPackingList);
            var deletedPackingList = service.Delete(newPackingList.Id);

            var checkPackingList = service.Get(deletedPackingList.Id);

            Assert.Null(checkPackingList);

            clearDb();
        }

        [Fact]
        public void DeleteFailTest()
        {
            for (int i = -2; i < 5; i++)
            {
                var entityPackingList = service.Delete(i);

                Assert.Null(entityPackingList);
            }
            clearDb();
        }

        private PackingListBO getPackingListMock()
        {
            PackingListBO packingList = new PackingListBO()
            {
                ItemType = "Cylinder",
                FreightType = "Mega tough"
            };

            return packingList;
        }

        private void clearDb()
        {
            service._facade.UnitOfWork.clearDb();
        }

    }
}
