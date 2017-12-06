using System;
using System.Collections.Generic;
using System.Linq;
using ShipmentPackerDAL;
using ShipmentPackerDAL.Entities;

namespace Test.Mock.DAL
{
    public class MockPackItemRepository : IPackItemRepository
    {
        private MockContext _context;

        public MockPackItemRepository(MockContext context)
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
            var packItem = Get(Id);
            _context.PackItems.Remove(packItem);
            return packItem;
        }

        public PackItem Get(int Id)
        {
            return _context.PackItems.FirstOrDefault(pi => pi.Id == Id);
        }

        public List<PackItem> GetAll()
        {
            return _context.PackItems.ToList();
        }

        public IEnumerable<PackItem> GetAllById(List<int> ids)
        {
            if (ids == null)
                return null;

            return _context.PackItems.Where(pi => ids.Contains(pi.Id));
        }
    }
}
