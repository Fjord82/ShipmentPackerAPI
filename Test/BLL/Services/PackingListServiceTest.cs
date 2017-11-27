using System;
using ShipmentPackerBLL.BusinessObjects;
using ShipmentPackerBLL.Services;
using Test.Mock.DAL;
using Xunit;

namespace Test.BLL.Services
{
    public class PackingListServiceTest
    {
        PackingListService service;

        public PackingListServiceTest()
        {
            service = new PackingListService(new MockFacade());
        }

        [Fact]
        public void CreatePassTest()
        {
            PackingListBO packingList = new PackingListBO()
            {
                ItemType = "Cylinder",
                FreightType = "Mega tough"
            };
            var newPackingList = service.Create(packingList);

            Assert.True(newPackingList.Id > 0);
        }

        [Fact]
        public void CreateFailTest()
        {
            var newPackingList = service.Create(null);

            Assert.Null(newPackingList);
        }

    }
}
