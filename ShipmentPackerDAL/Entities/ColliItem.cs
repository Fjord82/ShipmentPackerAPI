using System;
namespace ShipmentPackerDAL.Entities
{
    public class ColliItem
    {
        public int Id { get; set; }

        public int ColliListId { get; set; }

        public int ItemId { get; set; }

        public int Count { get; set; }
    }
}
