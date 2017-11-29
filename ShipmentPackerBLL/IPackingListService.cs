using System;
using System.Collections.Generic;
using ShipmentPackerBLL.BusinessObjects;

namespace ShipmentPackerBLL
{
    public interface IPackingListService
    {


        //C - Create
        PackingListBO Create(PackingListBO packingList);

        //R - Read
        List<PackingListBO> GetAll();
        PackingListBO Get(int Id);

        //U - Update
        PackingListBO Update(PackingListBO packingList);

        //D - Delete
        PackingListBO Delete(int id);
    }
}
