using System;
using System.Collections.Generic;
using ShipmentPackerBLL.BusinessObjects;

namespace ShipmentPackerBLL
{
    public interface IItemService
    {

        //C - Create
        ItemBO Create(ItemBO item);

        //R - Read
        List<ItemBO> GetAll();
        ItemBO Get(int Id);

        //U - Update
        ItemBO Update(ItemBO item);

        //D - Delete
        ItemBO Delete(int Id);
    }
}
