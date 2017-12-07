using System;
using System.Collections.Generic;
using ShipmentPackerDAL.Entities;

namespace ShipmentPackerDAL
{
    public interface IColliItemRepository
    {

        //C - Create
        ColliItem Create(ColliItem colliItem);

        //R - Read
        List<ColliItem> GetAll();
        IEnumerable<ColliItem> GetAllById(List<int> ids);

        ColliItem Get(int Id);

        //U - Update
        //No update for Repository, it will be a task for the Unit of Work

        //D - Delete
        ColliItem Delete(int Id);

    }
}
