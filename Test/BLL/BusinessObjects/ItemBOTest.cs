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

            Assert.True(result);
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
