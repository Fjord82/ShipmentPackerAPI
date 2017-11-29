using System;
using System.Collections.Generic;
using System.Linq;
using ShipmentPackerDAL;
using ShipmentPackerDAL.Entities;

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
            return _context.PackingLists.FirstOrDefault(pl => pl.Id == Id);
        }

        public List<PackingList> GetAll()
        {
            return _context.PackingLists.ToList();
        }

        public IEnumerable<PackingList> GetAllById(List<int> ids)
        {
            return _context.PackingLists.Where(pl => ids.Contains(pl.Id));
        }
    }
}
