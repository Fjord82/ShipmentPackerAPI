﻿using System;
namespace ShipmentPackerDAL.Entities
{
    public class PackingList
    {
        public int Id { get; set; }

        public string PackingName { get; set; }

        public string CreatorName { get; set; }

        public string DeliveryAddress { get; set; }

        public string DeliveryDate { get; set; }

        public string ItemType { get; set; }

        public string FreightType { get; set; }

        public bool IsActive { get; set; }
    }
}
