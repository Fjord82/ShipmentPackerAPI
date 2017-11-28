using System;
using ShipmentPackerBLL.BusinessObjects;
using ShipmentPackerBLL.Services;
using Test.Mock.DAL;
using Xunit;

namespace Test.BLL.Services
{
    public class ColliListServiceTest
    {
        ColliListService service;


        public ColliListServiceTest()
        {
            service = new ColliListService(new MockFacade());
        }

        [Fact]
        public void CreatePassTest()
        {
            ColliListBO colliList = new ColliListBO()
            {
                ItemType = "ImportantItem",
                FreightType = "Mega tough"
            };
            var newColliList = service.Create(colliList);

            Assert.True(newColliList.Id > 0);
        }

        [Fact]
        public void CreateFailTest()
        {
            var newColliList = service.Create(null);

            Assert.Null(newColliList);
        }
    }
}
