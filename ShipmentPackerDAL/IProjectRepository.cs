using System;
using System.Collections.Generic;
using ShipmentPackerDAL.Entities;

namespace ShipmentPackerDAL
{
    public interface IProjectRepository
    {
        //C - Create
        Project Create(Project project);

        //R - Read
        List<Project> GetAll();
        IEnumerable<Project> GetAllById(List<int> ids);

        Project Get(int Id);

        //U - Update
        //No update for Repository, it will be a task for the Unit of Work

        //D - Delete
        Project Delete(int Id);
    }
}
