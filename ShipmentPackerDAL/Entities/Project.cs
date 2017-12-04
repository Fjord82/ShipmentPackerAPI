using System.Collections.Generic;

namespace ShipmentPackerDAL.Entities
{
    public class Project
    {
        public int Id { get; set; }

        public string ProjectName { get; set; }

        public string CreatorName { get; set; }

        public string CustomerName { get; set; }

        public bool IsActive { get; set; }

        public List <ProjectPackingList> PackingLists { get; set; }
    }
}
