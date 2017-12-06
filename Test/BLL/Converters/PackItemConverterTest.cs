using System;
using System.Collections.Generic;
using ShipmentPackerBLL.BusinessObjects;
using ShipmentPackerBLL.Converters;
using ShipmentPackerDAL.Entities;
using Xunit;

namespace Test.BLL.Converters
{
    public class PackItemConverterTest
    {
        PackItemConverter _conv;
        List<PackItemBO> packItemBOs;
        List<PackItem> packItems;

        public PackItemConverterTest()
        {
            _conv = new PackItemConverter();
            packItemBOs = new List<PackItemBO>();
            packItemBOs.Add(new PackItemBO()
            {
                Id = 15,
                PackingListId = 1,
                ItemId = 2,
                Count = 50
            });

            packItemBOs.Add(new PackItemBO()
            {
                Count = 0
            });

            packItemBOs.Add(new PackItemBO());

            packItems = new List<PackItem>();
            packItems.Add(new PackItem()
            {
                Id = 15,
                PackingListId = 1,
                ItemId = 2,
                Count = 50
            });

            packItems.Add(new PackItem()
            {
                Count = 0
            });

            packItems.Add(new PackItem());
        }

        [Fact]
        public void ConvertPackItemBOPassTest()
        {
            foreach (var BO in packItemBOs)
            {
                var packItem = _conv.ConvertBO(BO);
                Assert.NotNull(packItem);
                Assert.Equal(BO.PackingListId, packItem.PackingListId);
                Assert.Equal(BO.ItemId, packItem.ItemId);
                Assert.Equal(BO.Count, packItem.Count);
                Assert.Equal(BO.Id, packItem.Id);
            }
        }

        [Fact]
        public void ConvertPackItemBOFailTest()
        {
            var packItem = _conv.ConvertBO(null);

            Assert.Null(packItem);
        }

        [Fact]
        public void ConvertPackItemPassTest()
        {
            foreach (var entity in packItems)
            {
                var packItemBO = _conv.Convert(entity);
                Assert.NotNull(packItemBO);
                Assert.Equal(entity.PackingListId, packItemBO.PackingListId);
                Assert.Equal(entity.ItemId, packItemBO.ItemId);
                Assert.Equal(entity.Count, packItemBO.Count);
                Assert.Equal(entity.Id, packItemBO.Id);
            }
        }

        [Fact]
        public void ConvertPackItemFailTest()
        {
            var packItemBO = _conv.Convert(null);

            Assert.Null(packItemBO);
        }
    }
}
