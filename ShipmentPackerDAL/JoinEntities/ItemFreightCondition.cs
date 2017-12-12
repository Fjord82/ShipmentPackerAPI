using System;
using ShipmentPackerDAL.Entities;

namespace ShipmentPackerDAL.JoinEntities
{
    public class ItemFreightCondition
    {
        public int FreightConditionID { get; set; }
        public FreightCondition FreightCondition { get; set; }

        public int ItemID { get; set; }
        public Item Item { get; set; }
    }
}
