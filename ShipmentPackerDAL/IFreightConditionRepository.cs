using System;
using System.Collections.Generic;
using ShipmentPackerDAL.Entities;

namespace ShipmentPackerDAL
{
    public interface IFreightConditionRepository
    {
        //C - Create
        FreightCondition Create(FreightCondition condition);

        //R - Read
        List<FreightCondition> GetAll();
        IEnumerable<FreightCondition> GetAllById(List<int> ids);

        FreightCondition Get(int Id);

        //U - Update
        //No update for Repository, it will be a task for the Unit of Work

        //D - Delete
        FreightCondition Delete(int Id);

    }
}
