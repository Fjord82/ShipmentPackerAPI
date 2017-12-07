using System;
using System.ComponentModel.DataAnnotations;

namespace ShipmentPackerBLL.BusinessObjects
{
    public class PackItemBO
    {
        public int Id { get; set; }

        [Required]
        public int PackingListId { get; set; }

        [Required]
        public int ItemId { get; set; }

        public int Count { get; set; }
    }
}
