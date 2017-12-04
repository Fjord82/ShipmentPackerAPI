using System;
using System.Collections.Generic;
using System.Linq;
using ShipmentPackerDAL.Context;
using ShipmentPackerDAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace ShipmentPackerDAL.Repositories
{
    public class PackingListRepository : IPackingListRepository
    {
        MyDBContext _context;

        public PackingListRepository(MyDBContext context)
        {
            _context = context;
        }

        public PackingList Create(PackingList packingList)
        {
           _context.PackingLists.Add(packingList);
            return packingList;
        }

        public PackingList Delete(int Id)
        {
            var packList = Get(Id);
            _context.PackingLists.Remove(packList);
            return packList;
        }

        public PackingList Get(int Id)
        {
            return _context.PackingLists
                .Include(pl => pl.Projects)
                .FirstOrDefault(pl => pl.Id == Id);
        }

        public List<PackingList> GetAll()
        {
            return _context.PackingLists
                .Include(pl => pl.Projects)
                .ToList();
        }

        public IEnumerable<PackingList> GetAllById(List<int> ids)
        {
            if (ids == null)
                return null;

            return _context.PackingLists.Where(pl => ids.Contains(pl.Id));
        }
    }
}
