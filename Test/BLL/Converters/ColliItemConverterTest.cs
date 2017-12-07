using System;
using System.Collections.Generic;
using ShipmentPackerBLL.BusinessObjects;
using ShipmentPackerBLL.Converters;
using ShipmentPackerDAL.Entities;
using Xunit;

namespace Test.BLL.Converters
{
    public class ColliItemConverterTest
    {
        ColliItemConverter _conv;
        List<ColliItemBO> colliItemBOs;
        List<ColliItem> colliItems;

        public ColliItemConverterTest()
        {
            _conv = new ColliItemConverter();
            colliItemBOs = new List<ColliItemBO>();
            colliItemBOs.Add(new ColliItemBO()
            {
                Id = 15,
                ColliListId = 1,
                ItemId = 2,
                Count = 50
            });

            colliItemBOs.Add(new ColliItemBO()
            {
                Count = 0
            });

            colliItemBOs.Add(new ColliItemBO());

            colliItems = new List<ColliItem>();
            colliItems.Add(new ColliItem()
            {
                Id = 15,
                ColliListId = 1,
                ItemId = 2,
                Count = 50
            });

            colliItems.Add(new ColliItem()
            {
                Count = 0
            });

            colliItems.Add(new ColliItem());
        }

        [Fact]
        public void ConvertColliItemBOPassTest()
        {
            foreach (var BO in colliItemBOs)
            {
                var colliItem = _conv.ConvertBO(BO);
                Assert.NotNull(colliItem);
                Assert.Equal(BO.ColliListId, colliItem.ColliListId);
                Assert.Equal(BO.ItemId, colliItem.ItemId);
                Assert.Equal(BO.Count, colliItem.Count);
                Assert.Equal(BO.Id, colliItem.Id);
            }
        }

        [Fact]
        public void ConvertColliItemBOFailTest()
        {
            var packItem = _conv.ConvertBO(null);

            Assert.Null(packItem);
        }

        [Fact]
        public void ConvertColliItemPassTest()
        {
            foreach (var entity in colliItems)
            {
                var colliItemBO = _conv.Convert(entity);
                Assert.NotNull(colliItemBO);
                Assert.Equal(entity.ColliListId, colliItemBO.ColliListId);
                Assert.Equal(entity.ItemId, colliItemBO.ItemId);
                Assert.Equal(entity.Count, colliItemBO.Count);
                Assert.Equal(entity.Id, colliItemBO.Id);
            }
        }

        [Fact]
        public void ConvertColliItemFailTest()
        {
            var colliItemBO = _conv.Convert(null);

            Assert.Null(colliItemBO);
        }
    }
}
