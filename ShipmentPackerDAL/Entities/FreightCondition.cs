using System;
namespace ShipmentPackerDAL.Entities
{
    public class FreightCondition
    {
        public int Id { get; set; } 

        public string DangerousGoodsNumber { get; set; }

        public string DangerousGoodsName { get; set; }
    }
}
