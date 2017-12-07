using System;
using System.Collections.Generic;
using System.Linq;
using ShipmentPackerDAL.Context;
using ShipmentPackerDAL.Entities;

namespace ShipmentPackerDAL.Repositories
{
    public class ColliItemRepository : IColliItemRepository
    {
       
        MyDBContext _context;

        public ColliItemRepository(MyDBContext context)
        {
            _context = context;
        }

        public ColliItem Create(ColliItem colliItem)
        {
            _context.ColliItems.Add(colliItem);
            return colliItem;
        }

        public ColliItem Delete(int Id)
        {
            var colliItemToDelete = Get(Id);
            _context.ColliItems.Remove(colliItemToDelete);
            return colliItemToDelete;
        }

        public ColliItem Get(int Id)
        {
            return _context.ColliItems.FirstOrDefault(ci => ci.Id == Id);
        }

        public List<ColliItem> GetAll()
        {
            return _context.ColliItems.ToList();
        }

        public IEnumerable<ColliItem> GetAllById(List<int> ids)
        {
            if (ids == null)
                return null;
            return _context.ColliItems.Where(ci => ids.Contains(ci.Id));
        }
    }
}
