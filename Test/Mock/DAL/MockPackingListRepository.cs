using System;
using System.Collections.Generic;
using System.Linq;
using ShipmentPackerDAL;
using ShipmentPackerDAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace Test.Mock.DAL
{
    public class MockPackingListRepository : IPackingListRepository
    {
        private MockContext _context;

        public MockPackingListRepository(MockContext context)
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
                           .Include(pl => pl.ColliLists)
                .FirstOrDefault(pl => pl.Id == Id);
        }

        public List<PackingList> GetAll()
        {
            return _context.PackingLists
                .Include(pl => pl.Projects)
                           .Include(pl => pl.ColliLists)
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
