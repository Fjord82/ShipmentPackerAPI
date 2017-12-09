using System;
using System.Collections.Generic;
using ShipmentPackerBLL.BusinessObjects;
using ShipmentPackerBLL.Converters;
using ShipmentPackerDAL.Entities;
using Xunit;

namespace Test.BLL.Converters
{
    public class FreightConditionConverterTest
    {
        FreightConditionConverter _conv;
        List<FreightConditionBO> conditionBOs;
        List<FreightCondition> conditions;

        public FreightConditionConverterTest()
        {
            _conv = new FreightConditionConverter();
            conditionBOs = new List<FreightConditionBO>();
            conditionBOs.Add(new FreightConditionBO()
            {
                Id = 15,
                DangerousGoodsNumber = "1200",
                DangerousGoodsName = "Pressured-Cylinder"
            });

            conditionBOs.Add(new FreightConditionBO()
            {
                DangerousGoodsName = "Goods Without definition"
            });

            conditionBOs.Add(new FreightConditionBO());

            conditions = new List<FreightCondition>();
            conditions.Add(new FreightCondition()
            {
                Id = 15,
                DangerousGoodsNumber = "1200",
                DangerousGoodsName = "Pressured-Cylinder"
            });

            conditions.Add(new FreightCondition()
            {
                DangerousGoodsName = "Goods Without definition"
            });

            conditions.Add(new FreightCondition());
        }

        [Fact]
        public void ConvertItemBOPassTest()
        {
            foreach (var BO in conditionBOs)
            {
                var condition = _conv.ConvertBO(BO);
                Assert.NotNull(condition);
                Assert.Equal(BO.DangerousGoodsNumber, condition.DangerousGoodsNumber);
                Assert.Equal(BO.DangerousGoodsNumber, condition.DangerousGoodsNumber);
                Assert.Equal(BO.Id, condition.Id);
            }
        }

        [Fact]
        public void ConvertItemBOFailTest()
        {
            var condition = _conv.ConvertBO(null);

            Assert.Null(condition);
        }

        [Fact]
        public void ConvertItemPassTest()
        {
            foreach (var entity in conditions)
            {
                var conditionBO = _conv.Convert(entity);
                Assert.NotNull(conditionBO);
                Assert.Equal(entity.DangerousGoodsNumber, conditionBO.DangerousGoodsNumber);
                Assert.Equal(entity.DangerousGoodsName, conditionBO.DangerousGoodsName);
                Assert.Equal(entity.Id, conditionBO.Id);
            }
        }

        [Fact]
        public void ConvertItemFailTest()
        {
            var conditionBO = _conv.Convert(null);

            Assert.Null(conditionBO);
        }
    }
}
