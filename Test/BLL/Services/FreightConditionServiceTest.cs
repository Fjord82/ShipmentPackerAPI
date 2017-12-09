using System;
using System.Collections.Generic;
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

        [Fact]
        public void ReadPassTest()
        {
            try
            {
                clearDb();
                var condition = getConditionMock();
                var newCondtion = service.Create(condition);

                var createdCondition = service.Get(newCondtion.Id);
                Assert.Equal(newCondtion.DangerousGoodsName, createdCondition.DangerousGoodsName);
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
                var entityCondition = service.Get(i);

                Assert.Null(entityCondition);
            }
            clearDb();
        }

        [Fact]
        public void GetAllPassTest()
        {
            try
            {
                clearDb();
                List<FreightConditionBO> createdConditions = new List<FreightConditionBO>();
                for (int i = 0; i < 2; i++)
                {
                    var condition = getConditionMock();
                    var newCondition = service.Create(condition);
                    createdConditions.Add(newCondition);
                }

                var conditionList = service.GetAll();
                Assert.Equal(createdConditions.Count, conditionList.Count);
                Assert.Equal(createdConditions.ToString(), conditionList.ToString());
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
