using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ShipmentPackerBLL.BusinessObjects
{
    public class PackingListBO
    {
        public int Id { get; set; }

        [Required]
        public string PackingName { get; set; }

        [Required]
        public string CreatorName { get; set; }

        [Required]
        public string DeliveryAddress { get; set; }

        [Required]
        public string DeliveryDate { get; set; }

        [Required]
        public string ItemType { get; set; }

        [Required]
        public string FreightType { get; set; }

        public bool IsActive { get; set; }

        public List<int> ProjectIds { get; set; }
        public List<ProjectBO> Projects { get; set; }

        public List<int> ColliListIds { get; set; }
        public List<ColliListBO> ColliLists { get; set; }

        public List<int> PackItemsIds { get; set; }
        public List<PackItemBO> PackItems { get; set; }
    }
}
