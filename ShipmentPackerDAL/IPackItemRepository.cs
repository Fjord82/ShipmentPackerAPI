using System;
using System.Collections.Generic;
using ShipmentPackerDAL.Entities;

namespace ShipmentPackerDAL
{
    public interface IPackItemRepository
    {
        //C - Create
        PackItem Create(PackItem packItem);

        //R - Read
        List<PackItem> GetAll();
        IEnumerable<PackItem> GetAllById(List<int> ids);

        PackItem Get(int Id);

        //U - Update
        //No update for Repository, it will be a task for the Unit of Work

        //D - Delete
        PackItem Delete(int Id);
    }
}
