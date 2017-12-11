using System;
using System.Collections.Generic;

namespace ShipmentPackerDAL.Entities
{
    public class ColliList
    {
        public int Id { get; set; }

        public string ItemType { get; set; }

        public string FreightType { get; set; }

        public string Dimensions { get; set; }

        public string Worker { get; set; }

        public string ProjectName { get; set; }

        public double NetWeight { get; set; }

        public double TotalWeight { get; set; }

        public bool IsActive { get; set; }

        public List<PackingColliList> PackingLists { get; set; }
        public List<ColliItem> ColliItems { get; set; }
    }
}
