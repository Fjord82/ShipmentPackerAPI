﻿using System;
using ShipmentPackerBLL.BusinessObjects;
using ShipmentPackerDAL.Entities;

namespace ShipmentPackerBLL.Converters
{
    public class ProjectConverter
    {
        public ProjectConverter()
        {
        }

        public Project ConvertBO(ProjectBO projectBO)
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
                IsActive = projectBO.IsActive
            };
        }

        public ProjectBO Convert(Project project)
        {
            if (project == null)
            {
                return null;
            }
            return new ProjectBO()
            {
                Id = project.Id,
                ProjectName = project.ProjectName,
                CreatorName = project.CreatorName,
                CustomerName = project.CustomerName,
                IsActive = project.IsActive
                                      
            };
        }
    }
}
