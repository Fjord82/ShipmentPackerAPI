using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ShipmentPackerBLL.BusinessObjects
{
    public class ItemBO
    {
        public int Id { get; set; }

        [Required]
        public string ItemName { get; set; }

        [Required]
        public string Dimension { get; set; }

        [Required]
        public double Weight { get; set; }

        [Required]
        public bool DangerousGoods { get; set; }

        public List<int> PackItemsIds { get; set; }
        public List<PackItemBO> PackItems { get; set; }

        public List<int> ColliItemsIds { get; set; }
        public List<ColliItemBO> ColliItems { get; set; }

    }
}
