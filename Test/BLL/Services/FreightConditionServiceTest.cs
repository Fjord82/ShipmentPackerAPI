using System;
using ShipmentPackerBLL.BusinessObjects;
using ShipmentPackerBLL.Services;
using Test.Mock.DAL;
using Xunit;

namespace Test.BLL.Services
{
    public class FreightConditionServiceTest
    {
        FreightConditionService service;
        MockFacade facade;

        public FreightConditionServiceTest()
        {
            facade = new MockFacade();
            service = new FreightConditionService(facade);
        }

        [Fact]
        public void CreatePassTest()
        {
            try
            {
                clearDb();
                var condition = getConditionMock();
                var newCondition = service.Create(condition);

                Assert.True(newCondition.Id > 0);
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
            var newCondition = service.Create(null);

            Assert.Null(newCondition);

            clearDb();
        }


        public FreightConditionBO getConditionMock()
        {
            FreightConditionBO condition = new FreightConditionBO()
            {
                DangerousGoodsNumber = "1200",
                DangerousGoodsName = "Pressured-Cylinder"
            };

            return condition;
        }


        private void clearDb()
        {
            service._facade.UnitOfWork.clearDb();
        }
    }
}
