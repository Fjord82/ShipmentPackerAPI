using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ShipmentPackerBLL.BusinessObjects
{
    public class ColliListBO
    {
        public int Id { get; set; }

        [Required]
        public string ItemType { get; set; }

        [Required]
        public string FreightType { get; set; }

        public string Dimensions { get; set; }

        public string Worker { get; set; }

        public string ProjectName { get; set; }

        public double NetWeight { get; set; }

        public double TotalWeight { get; set; }

        public bool IsActive { get; set; }

        public List<int> PackingListIds { get; set; }
        public List<PackingListBO> PackingLists { get; set; }
    }
}
