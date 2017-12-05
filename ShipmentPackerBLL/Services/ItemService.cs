using System;
using System.Collections.Generic;
using ShipmentPackerBLL.BusinessObjects;
using ShipmentPackerBLL.Converters;
using ShipmentPackerDAL;

namespace ShipmentPackerBLL.Services
{
    public class ItemService : IItemService
    {
        public IDALFacade _facade { get; set; }
        ItemConverter _conv;

        public ItemService(IDALFacade facade)
        {
            _facade = facade;
            _conv = new ItemConverter();
        }

        public ItemBO Create(ItemBO item)
        {
            if (item == null)
            {
                return null;
            }

            using(var uow = _facade.UnitOfWork)
            {
                var itemCreated = uow.ItemRepository.Create(_conv.ConvertBO(item));
                uow.Complete();
                return _conv.Convert(itemCreated);
            }
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
