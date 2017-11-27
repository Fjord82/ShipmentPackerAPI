using System;
using ShipmentPackerBLL.BusinessObjects;

namespace ShipmentPackerBLL
{
    public interface IProjectService
    {

        //C - Create
        ProjectBO Create(ProjectBO project);
    }
}
