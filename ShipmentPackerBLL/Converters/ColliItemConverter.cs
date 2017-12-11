using System;
using ShipmentPackerBLL.BusinessObjects;
using ShipmentPackerDAL.Entities;

namespace ShipmentPackerBLL.Converters
{
    public class ColliItemConverter
    {
        public ColliItemConverter()
        {
        }

        public ColliItem ConvertBO(ColliItemBO colliItemBO)
        {
            if (colliItemBO == null)
            {
                return null;
            }
            return new ColliItem()
            {
                Id = colliItemBO.Id,
                ColliListId = colliItemBO.ColliListId,
                ItemId = colliItemBO.ItemId,
                Count = colliItemBO.Count

            };
        }

        public ColliItemBO Convert(ColliItem colliItem)
        {
            if (colliItem == null)
            {
                return null;
            }
            return new ColliItemBO()
            {
                Id = colliItem.Id,
                ColliListId = colliItem.ColliListId,
                ItemId = colliItem.ItemId,
                Count = colliItem.Count,

                ColliList = new ColliListConverter().Convert(colliItem.ColliList),
                Item = new ItemConverter().Convert(colliItem.Item)
            };
        }
    }
}
