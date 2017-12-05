using System;
using System.Collections.Generic;
using ShipmentPackerBLL.BusinessObjects;
using ShipmentPackerDAL;

namespace ShipmentPackerBLL.Services
{
    public class ItemService : IItemService
    {
        public IDALFacade _facade { get; set; }

        public ItemService(IDALFacade facade)
        {
        }

        public ItemBO Create(ItemBO item)
        {
            throw new NotImplementedException();
        }

        public ItemBO Delete(int Id)
        {
            throw new NotImplementedException();
        }

        public ItemBO Get(int Id)
        {
            throw new NotImplementedException();
        }

        public List<ItemBO> GetAll()
        {
            throw new NotImplementedException();
        }

        public ItemBO Update(ItemBO item)
        {
            throw new NotImplementedException();
        }
    }
}
