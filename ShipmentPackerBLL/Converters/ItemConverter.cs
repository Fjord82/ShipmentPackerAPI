using System;
using ShipmentPackerBLL.BusinessObjects;
using ShipmentPackerDAL.Entities;

namespace ShipmentPackerBLL.Converters
{
    public class ItemConverter
    {
        public ItemConverter()
        {
        }

        public Item ConvertBO(ItemBO itemBO)
        {
            if (itemBO == null)
            {
                return null;
            }
            return new Item()
            {
                Id = itemBO.Id,
                ItemName = itemBO.ItemName,
                DangerousGoods = itemBO.DangerousGoods

            };
        }

        public ItemBO Convert(Item item)
        {
            if (item == null)
            {
                return null;
            }
            return new ItemBO()
            {
                Id = item.Id,
                ItemName = item.ItemName,
                DangerousGoods = item.DangerousGoods
            };
        }
    }
}
