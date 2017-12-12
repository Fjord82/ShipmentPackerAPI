using System;
using System.Collections.Generic;

namespace ShipmentPackerBLL.BusinessObjects
{
    public class FreightConditionBO
    {
        public int Id { get; set; }

        public string DangerousGoodsNumber { get; set; }

        public string DangerousGoodsName { get; set; }

        public List<int> ItemIds { get; set; }
        public List<ItemBO> Items { get; set; }
    }
}
