using System;
using System.ComponentModel.DataAnnotations;
using ShipmentPackerBLL.BusinessObjects;
using Xunit;

namespace Test.BLL.BusinessObjects
{
    public class ColliListBOTest
    {
        static ColliListBO colliList = new ColliListBO();

        [Fact]
        public void ValidateItemTypeFailTest()
        {
            Assert.Null(colliList.ItemType);

            var result = Validator.TryValidateProperty(colliList.ItemType, new ValidationContext(colliList) { MemberName = "ItemType" }, null);

            Assert.False(result);
        }


        [Fact]
        public void ValidateItemTypePassTest()
        {
            colliList.ItemType = "Basket";

            Assert.Equal("Basket", colliList.ItemType);

            var result = Validator.TryValidateProperty(colliList.ItemType, new ValidationContext(colliList) { MemberName = "ItemType" }, null);
            Assert.True(result);
            reset();
        }


        [Fact]
        public void ValidateFreightTypeFailTest()
        {
            Assert.Null(colliList.FreightType);

            var result = Validator.TryValidateProperty(colliList.FreightType, new ValidationContext(colliList) { MemberName = "FreightType" }, null);

            Assert.False(result);
        }


        [Fact]
        public void ValidateFreightTypePassTest()
        {
            colliList.FreightType = "Sea";

            Assert.Equal("Sea", colliList.FreightType);

            var result = Validator.TryValidateProperty(colliList.FreightType, new ValidationContext(colliList) { MemberName = "FreightType" }, null);
            Assert.True(result);
            reset();
        }

        public void reset()
        {
            colliList = new ColliListBO();
        }
    }
}
