using System;
using System.Collections.Generic;
using ShipmentPackerDAL.JoinEntities;

namespace ShipmentPackerDAL.Entities
{
    public class Item
    {
        public int Id { get; set; }

        public string ItemName { get; set; }

        public string Dimension { get; set; }

        public double Weight { get; set; }

        public bool DangerousGoods { get; set; }

        public List<PackItem> PackItems { get; set; }
        public List<ColliItem> ColliItems { get; set; }

        public List<ItemFreightCondition> FreightConditions { get; set; }

    }
}
