using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ShipmentPackerBLL.BusinessObjects
{
    public class ProjectBO
    {
        public int Id { get; set; }

        [Required]
        public string ProjectName { get; set; }

        [Required]
        public string CreatorName { get; set; }

        [Required]
        public string CustomerName { get; set; }

        public bool IsActive { get; set; }

        public List<int> PackingListIds { get; set; }
        public List<PackingListBO> PackingLists { get; set; }

    }
}
