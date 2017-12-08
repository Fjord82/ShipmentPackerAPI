using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using ShipmentPackerDAL.Context;
using ShipmentPackerDAL.Entities;

namespace ShipmentPackerDAL.Repositories
{
    public class PackItemRepository : IPackItemRepository
    {

        MyDBContext _context;

        public PackItemRepository(MyDBContext context)
        {
            _context = context;
        }

        public PackItem Create(PackItem packItem)
        {
            _context.PackItems.Add(packItem);
            return packItem;
        }

        public PackItem Delete(int Id)
        {
            var packItemToDelete = Get(Id);
            _context.PackItems.Remove(packItemToDelete);
            return packItemToDelete;
        }

        public PackItem Get(int Id)
        {
            return _context.PackItems
                           .Include(pi => pi.PackingList)
                           .Include(pi => pi.Item)
                           .FirstOrDefault(pi => pi.Id == Id);
        }

        public List<PackItem> GetAll()
        {
            return _context.PackItems
                           .Include(pi => pi.PackingList)
                           .Include(pi => pi.Item)
                           .ToList();
        }

        public IEnumerable<PackItem> GetAllById(List<int> ids)
        {
            if (ids == null)
                return null;
            return _context.PackItems.Where(pi => ids.Contains(pi.Id));
        }
    }
}
