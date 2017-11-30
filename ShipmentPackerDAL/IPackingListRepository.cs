using System;
using System.Collections.Generic;
using ShipmentPackerDAL.Entities;

namespace ShipmentPackerDAL
{
    public interface IPackingListRepository
    {

        //C - Create
        PackingList Create(PackingList packingList);

        //R - Read
        List<PackingList> GetAll();
        IEnumerable<PackingList> GetAllById(List<int> ids);

        PackingList Get(int Id);

        //U - Update
        //No update for Repository, it will be a task for the Unit of Work

        //D - Delete
        PackingList Delete(int Id);
    }
}
