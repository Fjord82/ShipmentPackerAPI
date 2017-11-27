using System;
using ShipmentPackerBLL.BusinessObjects;
using ShipmentPackerDAL.Entities;

namespace ShipmentPackerBLL.Converters
{
    public class ProjectConverter
    {
        public ProjectConverter()
        {
        }

        public Project Convert(ProjectBO projectBO)
        {
            if(projectBO == null)
            {
                return null;
            }
            return new Project()
            {
                Id = projectBO.Id,
                ProjectName = projectBO.ProjectName,
                CreatorName = projectBO.CreatorName,
                CustomerName = projectBO.CustomerName,
                FreightType = projectBO.FreightType
            };
        }
    }
}
