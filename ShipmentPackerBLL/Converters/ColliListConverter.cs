using System;
using ShipmentPackerBLL.BusinessObjects;
using ShipmentPackerDAL.Entities;

namespace ShipmentPackerBLL.Converters
{
    public class ColliListConverter
    {
        public ColliListConverter()
        {
        }

        public ColliList ConvertBO(ColliListBO colliListBO)
        {
           if (colliListBO == null)
            {
                return null;
            }

            return new ColliList()
            {
                Id = colliListBO.Id,
                ItemType = colliListBO.ItemType,
                FreightType = colliListBO.FreightType
            };
        }

        public ColliListBO Convert(ColliList colliList)
        {
            if (colliList == null)
            {
                return null;
            }

            return new ColliListBO()
            {
                Id = colliList.Id,
                ItemType = colliList.ItemType,
                FreightType = colliList.FreightType
            };
        }
    }
}
