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

        public List<int> PackingLists { get; set; }

    }
}
