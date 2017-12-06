using System;
using System.ComponentModel.DataAnnotations;
using ShipmentPackerBLL.BusinessObjects;
using Xunit;

namespace Test.BLL.BusinessObjects
{
    public class ItemBOTest
    {
        static ItemBO item = new ItemBO();


        [Fact]
        public void ValidateItemNameFailTest()
        {
            Assert.Null(item.ItemName);

            var result = Validator.TryValidateProperty(item.ItemName, new ValidationContext(item) { MemberName = "ItemName" }, null);

            Assert.False(result);
        }


        [Fact]
        public void ValidateItemNamePassTest()
        {
            item.ItemName = "Cylinder";

            Assert.Equal("Cylinder", item.ItemName);

            var result = Validator.TryValidateProperty(item.ItemName, new ValidationContext(item) { MemberName = "ItemName" }, null);
            Assert.True(result);
            reset();
        }

        [Fact]
        public void ValidateDimensionFailTest()
        {
            Assert.Null(item.Dimension);

            var result = Validator.TryValidateProperty(item.Dimension, new ValidationContext(item) { MemberName = "Dimension" }, null);

            Assert.False(result);
        }


        [Fact]
        public void ValidateDimensionPassTest()
        {
            item.Dimension = "1.0";

            Assert.Equal("1.0", item.Dimension);

            var result = Validator.TryValidateProperty(item.Dimension, new ValidationContext(item) { MemberName = "Dimension" }, null);
            Assert.True(result);
            reset();
        }

        [Fact]
        public void ValidateWeightFailTest()
        {
            Assert.Equal(0, item.Weight);

            var result = Validator.TryValidateProperty(item.Weight, new ValidationContext(item) { MemberName = "Weight" }, null);

            Assert.True(result);
        }


        [Fact]
        public void ValidateWeightPassTest()
        {
            item.Weight = 1.0;

            Assert.Equal(1.0, item.Weight);

            var result = Validator.TryValidateProperty(item.Weight, new ValidationContext(item) { MemberName = "Weight" }, null);
            Assert.True(result);
            reset();
        }

        [Fact]
        public void ValidateIsActiveTest()
        {
            Assert.False(item.DangerousGoods);

            item.DangerousGoods = true;

            Assert.True(item.DangerousGoods);

            reset();
        }

        public void reset()
        {
            item = new ItemBO();
        }
    }
}
