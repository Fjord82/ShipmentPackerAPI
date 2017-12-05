using System;
using System.Collections.Generic;
using ShipmentPackerDAL.Entities;

namespace ShipmentPackerDAL
{
    public interface IItemRepository
    {

        //C - Create
        Item Create(Item item);

        //R - Read
        List<Item> GetAll();
        IEnumerable<Item> GetAllById(List<int> ids);

        Item Get(int Id);

        //U - Update
        //No update for Repository, it will be a task for the Unit of Work

        //D - Delete
        Item Delete(int Id);
    }
}
