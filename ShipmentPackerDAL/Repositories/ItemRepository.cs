using System;
using System.Collections.Generic;
using System.Linq;
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
            _context.Items.Add(item);
            return item;
        }

        public Item Delete(int Id)
        {
            var itemToDelete = Get(Id);
            _context.Items.Remove(itemToDelete);
            return itemToDelete;
        }

        public Item Get(int Id)
        {
            return _context.Items.FirstOrDefault(i => i.Id == Id);

        }

        public List<Item> GetAll()
        {
            return _context.Items.ToList();
        }

        public IEnumerable<Item> GetAllById(List<int> ids)
        {
            if (ids == null)
                return null;
            return _context.Items.Where(i => ids.Contains(i.Id));
        }
    }
}
