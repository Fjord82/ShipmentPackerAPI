using System;
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

        public bool IsActive { get; set; }
    }
}
