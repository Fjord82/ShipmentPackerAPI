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

        [Fact]
        public void DeletePassTest()
        {
            try
            {
                clearDb();
                var newCondition = getConditionMock();
                newCondition = service.Create(newCondition);
                var deletedCondition = service.Delete(newCondition.Id);

                var checkCondition = service.Get(deletedCondition.Id);

                Assert.Null(checkCondition);
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
                var entityCondition = service.Delete(i);

                Assert.Null(entityCondition);
            }
            clearDb();
        }

        [Fact]
        public void UpdatePassTest()
        {
            try
            {
                clearDb();
                var originalCondition = getConditionMock();
                originalCondition = service.Create(originalCondition);

                var newCondition = new FreightConditionBO();
                newCondition.Id = originalCondition.Id;
                newCondition.DangerousGoodsNumber = originalCondition.DangerousGoodsNumber;
                newCondition.DangerousGoodsName = originalCondition.DangerousGoodsName;
                newCondition.DangerousGoodsName = "Pressured-Cylinder";
                newCondition = service.Update(newCondition);

                var updatedCondition = service.Get(originalCondition.Id);

                Assert.Equal(originalCondition.Id, newCondition.Id);

                Assert.Equal("Pressured-Cylinder", newCondition.DangerousGoodsName);

                Assert.Equal(newCondition.DangerousGoodsName, updatedCondition.DangerousGoodsName);

                Assert.NotEqual(originalCondition.DangerousGoodsName, newCondition.DangerousGoodsName);
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
            var originalCondition = getConditionMock();
            originalCondition = service.Create(originalCondition);
            var newCondition = originalCondition;
            newCondition.Id++;
            newCondition = service.Update(newCondition);

            var nullCondition = service.Update(null);

            Assert.Null(nullCondition);
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
