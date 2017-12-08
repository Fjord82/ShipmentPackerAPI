using System;
using System.Collections.Generic;

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
    }
}
