using ShipmentPackerDAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShipmentPackerDAL.JoinEntities
{
    public class ProjectPackingList
    {
        public int ProjectID { get; set; }
        public Project Project { get; set;}

        public int PackingListID { get; set; }
        public PackingList PackingList { get; set; }
    }
}
