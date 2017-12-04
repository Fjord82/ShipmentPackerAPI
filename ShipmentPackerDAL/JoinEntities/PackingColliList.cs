using ShipmentPackerDAL.Entities;

namespace ShipmentPackerDAL.Entities
{
    public class PackingColliList
    {
        public int PackingListID { get; set; }
        public PackingList PackingList { get; set; }

        public int ColliListID { get; set; }
        public ColliList ColliList { get; set; }
    }
}
