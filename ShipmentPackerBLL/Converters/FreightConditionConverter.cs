using System;
using System.Linq;
using ShipmentPackerBLL.BusinessObjects;
using ShipmentPackerDAL.Entities;
using ShipmentPackerDAL.JoinEntities;

namespace ShipmentPackerBLL.Converters
{
    public class FreightConditionConverter
    {
        public FreightConditionConverter()
        {
        }

        public FreightCondition ConvertBO(FreightConditionBO conditionBO)
        {
            if (conditionBO == null)
            {
                return null;
            }
            return new FreightCondition()
            {
                Id = conditionBO.Id,
                DangerousGoodsNumber = conditionBO.DangerousGoodsNumber,
                DangerousGoodsName = conditionBO.DangerousGoodsName,

                Items = conditionBO.ItemIds?.Select(iID => new ItemFreightCondition()
                {
                    ItemID = iID,
                    FreightConditionID = conditionBO.Id
                }).ToList()
            };
        }

        public FreightConditionBO Convert(FreightCondition condition)
        {
            if (condition == null)
            {
                return null;
            }
            return new FreightConditionBO()
            {
                Id = condition.Id,
                DangerousGoodsNumber = condition.DangerousGoodsNumber,
                DangerousGoodsName = condition.DangerousGoodsName,

                ItemIds = condition.Items?.Select(ic => ic.ItemID).ToList()
            };
        }
    }
}
