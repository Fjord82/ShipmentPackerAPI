using System;
using ShipmentPackerBLL.BusinessObjects;
using ShipmentPackerDAL.Entities;

namespace ShipmentPackerBLL.Converters
{
    public class PackItemConverter
    {
        public PackItemConverter()
        {
        }

        public PackItem ConvertBO(PackItemBO packItemBO)
        {
            if (packItemBO == null)
            {
                return null;
            }
            return new PackItem()
            {
                Id = packItemBO.Id,
                PackingListId = packItemBO.PackingListId,
                ItemId = packItemBO.ItemId,
                Count = packItemBO.Count,
                Packed = packItemBO.Packed
            };
        }

        public PackItemBO Convert(PackItem packItem)
        {
            if (packItem == null)
            {
                return null;
            }
            return new PackItemBO()
            {
                Id = packItem.Id,
                PackingListId = packItem.PackingListId,
                ItemId = packItem.ItemId,
                Count = packItem.Count,
                Packed = packItem.Packed,

                PackingList = new PackingListConverter().Convert(packItem.PackingList),
                Item = new ItemConverter().Convert(packItem.Item)
            };
        }
    }
}
