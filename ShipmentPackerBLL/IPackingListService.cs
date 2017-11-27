using System;
using ShipmentPackerBLL.BusinessObjects;

namespace ShipmentPackerBLL
{
    public interface IPackingListService
    {


        //C - Create
        PackingListBO Create(PackingListBO packingList);
    }
}
