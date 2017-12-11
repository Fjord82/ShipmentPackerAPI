using System;
using System.Collections.Generic;
using ShipmentPackerDAL.JoinEntities;

namespace ShipmentPackerDAL.Entities
{
    public class FreightCondition
    {
        public int Id { get; set; } 

        public string DangerousGoodsNumber { get; set; }

        public string DangerousGoodsName { get; set; }

        public List<ItemFreightCondition> Items { get; set; } 
    }
}
