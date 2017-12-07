using System;
using System.ComponentModel.DataAnnotations;

namespace ShipmentPackerBLL.BusinessObjects
{
    public class ColliItemBO
    {
        public int Id { get; set; }

        [Required]
        public int ColliListId { get; set; }

        [Required]
        public int ItemId { get; set; }

        public int Count { get; set; }
    }
}
