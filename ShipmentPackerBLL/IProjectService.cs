using System;
using System.Collections.Generic;
using ShipmentPackerBLL.BusinessObjects;

namespace ShipmentPackerBLL
{
    public interface IProjectService
    {

        //C - Create
        ProjectBO Create(ProjectBO project);

        //R - Read
        List<ProjectBO> GetAll();
        ProjectBO Get(int Id);
    }
}
