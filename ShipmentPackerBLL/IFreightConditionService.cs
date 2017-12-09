using System;
using System.Collections.Generic;
using ShipmentPackerBLL.BusinessObjects;

namespace ShipmentPackerBLL
{
    public interface IFreightConditionService
    {

        //C - Create
        FreightConditionBO Create(FreightConditionBO condition);

        //R - Read
        List<FreightConditionBO> GetAll();
        FreightConditionBO Get(int Id);

        //U - Update
        FreightConditionBO Update(FreightConditionBO condition);

        //D - Delete
        FreightConditionBO Delete(int Id);
    }
}
