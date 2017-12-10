using System;
using System.Collections.Generic;
using ShipmentPackerDAL.Entities;

namespace ShipmentPackerDAL
{
    public interface IUserRepository
    {

        //C - Create
        User Create(User user);

        //R - Read
        List<User> GetAll();
        IEnumerable<User> GetAllById(List<int> ids);

        User Get(int Id);

        //U - Update
        //No update for Repository, it will be a task for the Unit of Work

        //D - Delete
        User Delete(int Id);
    }
}
