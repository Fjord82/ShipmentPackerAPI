using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ShipmentPackerBLL.BusinessObjects
{
    public class FreightConditionBO
    {
        public int Id { get; set; }

        [Required]
        public string DangerousGoodsNumber { get; set; }

        [Required]
        public string DangerousGoodsName { get; set; }

        public List<int> ItemIds { get; set; }
        public List<ItemBO> Items { get; set; }
    }
}
