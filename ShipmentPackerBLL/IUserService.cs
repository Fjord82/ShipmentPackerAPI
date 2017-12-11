using System;
using System.Collections.Generic;
using ShipmentPackerBLL.BusinessObjects;

namespace ShipmentPackerBLL
{
    public interface IUserService
    {

        //C - Create
        UserBO Create(UserBO user);

        //R - Read
        List<UserBO> GetAll();
        UserBO Get(int Id);

        //U - Update
        UserBO Update(UserBO user);

        //D - Delete
        UserBO Delete(int Id);
    }
}
