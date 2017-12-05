using System;
using System.Collections.Generic;
using ShipmentPackerBLL.BusinessObjects;
using ShipmentPackerBLL.Converters;
using ShipmentPackerDAL.Entities;
using Xunit;

namespace Test.BLL.Converters
{
    public class ItemConverterTest
    {
        ItemConverter _conv;
        List<ItemBO> itemBOs;
        List<Item> items;

        public ItemConverterTest()
        {
            _conv = new ItemConverter();
            itemBOs = new List<ItemBO>();
            itemBOs.Add(new ItemBO()
            {
                Id = 15,
                ItemName = "Bottle",
                DangerousGoods = true
            });

            itemBOs.Add(new ItemBO()
            {
                ItemName = "Item Without definition"
            });

            itemBOs.Add(new ItemBO());

            items = new List<Item>();
            items.Add(new Item()
            {
                Id = 15,
                ItemName = "Bottle",
                DangerousGoods = true
            });

            items.Add(new Item()
            {
                ItemName = "Item Without definition"
            });

            items.Add(new Item());
        }

        [Fact]
        public void ConvertItemBOPassTest()
        {
            foreach (var BO in itemBOs)
            {
                var item = _conv.ConvertBO(BO);
                Assert.NotNull(item);
                Assert.Equal(BO.ItemName, item.ItemName);
                Assert.Equal(BO.DangerousGoods, item.DangerousGoods);
                Assert.Equal(BO.Id, item.Id);
            }
        }

        [Fact]
        public void ConvertItemBOFailTest()
        {
            var item = _conv.ConvertBO(null);

            Assert.Null(item);
        }

        [Fact]
        public void ConvertItemPassTest()
        {
            foreach (var entity in items)
            {
                var itemBO = _conv.Convert(entity);
                Assert.NotNull(itemBO);
                Assert.Equal(entity.ItemName, itemBO.ItemName);
                Assert.Equal(entity.DangerousGoods, itemBO.DangerousGoods);
                Assert.Equal(entity.Id, itemBO.Id);
            }
        }

        [Fact]
        public void ConvertItemFailTest()
        {
            var itemBO = _conv.Convert(null);

            Assert.Null(itemBO);
        }
    }
}
