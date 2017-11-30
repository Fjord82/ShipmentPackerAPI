using System;
using System.ComponentModel.DataAnnotations;
using ShipmentPackerBLL.BusinessObjects;
using Xunit;

namespace Test.BLL.BusinessObjects
{
    public class PackingListBOTest
    {
        static PackingListBO packingList = new PackingListBO();

        [Fact]
        public void ValidateItemNameFailTest()
        {
            Assert.Null(packingList.ItemType);

            var result = Validator.TryValidateProperty(packingList.ItemType, new ValidationContext(packingList) { MemberName = "ItemType" }, null);

            Assert.False(result);
        }


        [Fact]
        public void ValidateItemNamePassTest()
        {
            packingList.ItemType = "Cylinder";

            Assert.Equal("Cylinder", packingList.ItemType);

            var result = Validator.TryValidateProperty(packingList.ItemType, new ValidationContext(packingList) { MemberName = "ItemType" }, null);
            Assert.True(result);
            reset();
        }

        [Fact]
        public void ValidateFreightTypeFailTest()
        {
            Assert.Null(packingList.FreightType);

            var result = Validator.TryValidateProperty(packingList.FreightType, new ValidationContext(packingList) { MemberName = "FreightType" }, null);

            Assert.False(result);
        }


        [Fact]
        public void ValidateFreightTypePassTest()
        {
            packingList.FreightType = "Road";

            Assert.Equal("Road", packingList.FreightType);

            var result = Validator.TryValidateProperty(packingList.FreightType, new ValidationContext(packingList) { MemberName = "FreightType" }, null);
            Assert.True(result);
            reset();
        }

        [Fact]
        public void ValidateProjectPassTest()
        {
            packingList.Project = 1;

            Assert.NotEqual(0, packingList.Project);
            Assert.Equal(1, packingList.Project);

            reset();
        }

        [Fact]
        public void ValidateProjectFailTest()
        {
            Assert.Equal(0, packingList.Project);
        }

        public void reset()
        {
            packingList = new PackingListBO();
        }
    }
}
