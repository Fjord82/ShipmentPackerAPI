using System;
using System.Collections.Generic;
using ShipmentPackerDAL.Entities;

namespace ShipmentPackerDAL
{
    public interface IColliListRepository
    {

        //C - Create
        ColliList Create(ColliList colliList);

        //R - Read
        List<ColliList> GetAll();
        IEnumerable<ColliList> GetAllById(List<int> ids);

        ColliList Get(int Id);

        //U - Update
        //No update for Repository, it will be a task for the Unit of Work

        //D - Delete
        ColliList Delete(int Id);
    }
}
