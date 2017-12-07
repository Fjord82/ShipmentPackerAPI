using System;
using System.Collections.Generic;
using ShipmentPackerBLL.BusinessObjects;

namespace ShipmentPackerBLL
{
    public interface IColliItemService
    {
        //C - Create
        ColliItemBO Create(ColliItemBO colliItem);

        //R - Read
        List<ColliItemBO> GetAll();
        ColliItemBO Get(int Id);

        //U - Update
        ColliItemBO Update(ColliItemBO colliItem);

        //D - Delete
        ColliItemBO Delete(int Id);
    }
}
