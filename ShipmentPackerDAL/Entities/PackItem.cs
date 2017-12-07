using System;
namespace ShipmentPackerDAL.Entities
{
    public class PackItem
    {
        public int Id { get; set; }

        public int PackingListId { get; set; }

        public int ItemId { get; set; }

        public int Count { get; set; }

    }
}
