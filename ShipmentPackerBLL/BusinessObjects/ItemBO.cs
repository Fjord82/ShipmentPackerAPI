using System;
namespace ShipmentPackerBLL.BusinessObjects
{
    public class ItemBO
    {
        public int Id { get; set; }

        public string ItemName { get; set; }

        public bool DangerousGoods { get; set; }
    }
}
