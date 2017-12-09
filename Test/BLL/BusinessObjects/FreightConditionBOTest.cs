using System;
using System.ComponentModel.DataAnnotations;
using ShipmentPackerBLL.BusinessObjects;
using Xunit;

namespace Test.BLL.BusinessObjects
{
    public class FreightConditionBOTest
    {
        static FreightConditionBO condition = new FreightConditionBO();

        [Fact]
        public void ValidateDangerousGoodsNumberFailTest()
        {
            Assert.Null(condition.DangerousGoodsNumber);

            var result = Validator.TryValidateProperty(condition.DangerousGoodsNumber, new ValidationContext(condition) { MemberName = "DangerousGoodsNumber" }, null);

            Assert.False(result);
        }


        [Fact]
        public void ValidateDangerousGoodsNumberPassTest()
        {
            condition.DangerousGoodsNumber = "1200";

            Assert.Equal("1200", condition.DangerousGoodsNumber);

            var result = Validator.TryValidateProperty(condition.DangerousGoodsNumber, new ValidationContext(condition) { MemberName = "DangerousGoodsNumber" }, null);
            Assert.True(result);
            reset();
        }

        [Fact]
        public void ValidateDangerousGoodsNameFailTest()
        {
            Assert.Null(condition.DangerousGoodsName);

            var result = Validator.TryValidateProperty(condition.DangerousGoodsName, new ValidationContext(condition) { MemberName = "DangerousGoodsName" }, null);

            Assert.False(result);
        }


        [Fact]
        public void ValidateDangerousGoodsNamePassTest()
        {
            condition.DangerousGoodsName = "Pressured-Cylinder";

            Assert.Equal("Pressured-Cylinder", condition.DangerousGoodsName);

            var result = Validator.TryValidateProperty(condition.DangerousGoodsName, new ValidationContext(condition) { MemberName = "DangerousGoodsName" }, null);
            Assert.True(result);
            reset();
        }


        public void reset()
        {
            condition = new FreightConditionBO();
        }
    }
}
