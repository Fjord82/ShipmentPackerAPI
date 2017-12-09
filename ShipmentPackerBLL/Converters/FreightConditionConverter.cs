using System;
using ShipmentPackerBLL.BusinessObjects;
using ShipmentPackerDAL.Entities;

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
                DangerousGoodsName = conditionBO.DangerousGoodsName

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
                DangerousGoodsName = condition.DangerousGoodsName
            };
        }
    }
}
