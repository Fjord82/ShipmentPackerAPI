using System;
using System.Collections.Generic;
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
            throw new NotImplementedException();
        }

        public PackingList Get(int Id)
        {
            throw new NotImplementedException();
        }

        public List<PackingList> GetAll()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<PackingList> GetAllById(List<int> ids)
        {
            throw new NotImplementedException();
        }
    }
}
