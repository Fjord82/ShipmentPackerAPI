using System;
namespace ShipmentPackerDAL.Entities
{
    public class Item
    {
        public int Id { get; set; }

        public string ItemName { get; set; }

        public bool DangerousGoods { get; set; }
    }
}
