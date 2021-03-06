﻿using System;
using System.Linq;
using ShipmentPackerBLL.BusinessObjects;
using ShipmentPackerDAL.Entities;
using ShipmentPackerDAL.JoinEntities;

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
                DangerousGoods = itemBO.DangerousGoods,
                Dimension = itemBO.Dimension,
                Weight = itemBO.Weight,

                PackItems = itemBO.PackItemsIds?.Select(piID => new PackItem()
                {
                    ItemId = itemBO.Id
                                                 
                }).ToList(),

                ColliItems = itemBO.ColliItems?.Select(ciID => new ColliItem()
                {
                    ItemId = itemBO.Id

                }).ToList(),

                FreightConditions = itemBO.FreightConditionIds?.Select(fcID => new ItemFreightCondition()
                {
                    FreightConditionID = fcID,
                    ItemID = itemBO.Id
                }).ToList()

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
                DangerousGoods = item.DangerousGoods,
                Dimension = item.Dimension,
                Weight = item.Weight,

                PackItemsIds = item.PackItems?.Select(pi => pi.Id).ToList(),
                ColliItemsIds = item.ColliItems?.Select(ci => ci.Id).ToList(),
                FreightConditionIds = item.FreightConditions?.Select(fc => fc.FreightConditionID).ToList()
            };
        }
    }
}
