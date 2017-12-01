﻿using System;
using ShipmentPackerBLL.BusinessObjects;
using ShipmentPackerDAL.Entities;
using System.Linq;
using ShipmentPackerDAL.JoinEntities;

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
                PackingName = packingListBO.PackingName,
                CreatorName = packingListBO.CreatorName,
                DeliveryAddress = packingListBO.DeliveryAddress,
                DeliveryDate = packingListBO.DeliveryDate,
                ItemType = packingListBO.ItemType,
                FreightType = packingListBO.FreightType,
                Projects = packingListBO.ProjectIds?.Select(pID => new ProjectPackingList()
                {
                    ProjectID = pID,
                    PackingListID = packingListBO.Id
                }).ToList()
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
                PackingName = packingList.PackingName,
                CreatorName = packingList.CreatorName,
                DeliveryAddress = packingList.DeliveryAddress,
                DeliveryDate = packingList.DeliveryDate,
                ItemType = packingList.ItemType,
                FreightType = packingList.FreightType,
                ProjectIds = packingList.Projects?.Select(p => p.ProjectID).ToList()
            };
        }
    }
}
