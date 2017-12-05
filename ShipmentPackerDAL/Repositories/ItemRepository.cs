using System;
using System.Collections.Generic;
using ShipmentPackerDAL.Context;
using ShipmentPackerDAL.Entities;

namespace ShipmentPackerDAL.Repositories
{
    public class ItemRepository : IItemRepository
    {
        MyDBContext _context;

        public ItemRepository(MyDBContext context)
        {
            _context = context;
        }

        public Item Create(Item item)
        {
            throw new NotImplementedException();
        }

        public Item Delete(int Id)
        {
            throw new NotImplementedException();
        }

        public Item Get(int Id)
        {
            throw new NotImplementedException();
        }

        public List<Item> GetAll()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Item> GetAllById(List<int> ids)
        {
            throw new NotImplementedException();
        }
    }
}
