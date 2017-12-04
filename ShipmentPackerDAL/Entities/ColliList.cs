using System;
using System.Collections.Generic;

namespace ShipmentPackerDAL.Entities
{
    public class ColliList
    {
        public int Id { get; set; }

        public string ItemType { get; set; }

        public string FreightType { get; set; }

        public bool IsActive { get; set; }

        public List<PackingColliList> PackingLists { get; set; }
    }
}
