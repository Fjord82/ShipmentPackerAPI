using System;
namespace ShipmentPackerDAL.Entities
{
    public class PackingList
    {
        public int Id { get; set; }

        public string ItemType { get; set; }

        public string FreightType { get; set; }
    }
}
