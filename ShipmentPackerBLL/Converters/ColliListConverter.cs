using System;
using System.Linq;
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
                FreightType = colliListBO.FreightType,
                IsActive = colliListBO.IsActive,
                Dimensions = colliListBO.Dimensions,
                NetWeight = colliListBO.NetWeight,
                TotalWeight = colliListBO.TotalWeight,
                ProjectName = colliListBO.ProjectName,
                Worker = colliListBO.Worker,

                PackingLists = colliListBO.PackingListIds?.Select(pID => new PackingColliList()
                {
                    PackingListID = pID,
                    ColliListID = colliListBO.Id
                }).ToList()
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
                FreightType = colliList.FreightType,
                IsActive = colliList.IsActive,
                Dimensions = colliList.Dimensions,
                NetWeight = colliList.NetWeight,
                TotalWeight = colliList.TotalWeight,
                ProjectName = colliList.ProjectName,
                Worker = colliList.Worker,

                PackingListIds = colliList.PackingLists?.Select(p => p.PackingListID).ToList()
            };
        }
    }
}
