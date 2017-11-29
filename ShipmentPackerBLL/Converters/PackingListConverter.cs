using System;
using ShipmentPackerBLL.BusinessObjects;
using ShipmentPackerDAL.Entities;

namespace ShipmentPackerBLL.Converters
{
    public class PackingListConverter
    {
        public PackingListConverter()
        {
        }

        public PackingList ConvertBO(PackingListBO packingListBO)
        {
            if (packingListBO == null)
            {
                return null;
            }
            return new PackingList()
            {
                Id = packingListBO.Id,
                ItemType = packingListBO.ItemType,
                FreightType = packingListBO.FreightType
            };
        }

        public PackingListBO Convert(PackingList packingList)
        {
            if (packingList == null)
            {
                return null;
            }
            return new PackingListBO()
            {
                Id = packingList.Id,
                ItemType = packingList.ItemType,
                FreightType = packingList.FreightType
            };
        }
    }
}
