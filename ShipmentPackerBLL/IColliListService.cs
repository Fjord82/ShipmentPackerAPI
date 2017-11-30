using System;
using System.Collections.Generic;
using ShipmentPackerBLL.BusinessObjects;

namespace ShipmentPackerBLL
{
    public interface IColliListService
    {
        //C - Create
        ColliListBO Create(ColliListBO colliList);

        //R - Read
        List<ColliListBO> GetAll();
        ColliListBO Get(int Id);

        //U - Update
        ColliListBO Update(ColliListBO project);

        //D - Delete
        ColliListBO Delete(int Id);
    }
}
