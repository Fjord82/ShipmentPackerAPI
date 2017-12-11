using System;
using System.Collections.Generic;
using ShipmentPackerBLL.BusinessObjects;

namespace ShipmentPackerBLL
{
    public interface IPackItemService
    {

        //C - Create
        PackItemBO Create(PackItemBO packItem);
        List<PackItemBO> CreateList(List<PackItemBO> packItems);

        //R - Read
        List<PackItemBO> GetAll();
        PackItemBO Get(int Id);

        //U - Update
        PackItemBO Update(PackItemBO packItem);
        List<PackItemBO> UpdateList(List<PackItemBO> PackItems);

        //D - Delete
        PackItemBO Delete(int Id);
    }
}
