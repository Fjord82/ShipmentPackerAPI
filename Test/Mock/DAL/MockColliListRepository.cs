using System;
using System.Collections.Generic;
using System.Linq;
using ShipmentPackerDAL;
using ShipmentPackerDAL.Entities;

namespace Test.Mock.DAL
{
    public class MockColliListRepository : IColliListRepository
    {
        private MockContext _context;

        public MockColliListRepository(MockContext context)
        {
            _context = context;
        }

        public ColliList Create(ColliList colliList)
        {
            _context.ColliLists.Add(colliList);
            return colliList;
        }

        public ColliList Delete(int Id)
        {
            var colliList = Get(Id);
            _context.ColliLists.Remove(colliList);
            return colliList;
        }

        public ColliList Get(int Id)
        {
            return _context.ColliLists.FirstOrDefault(cl => cl.Id == Id);
        }

        public List<ColliList> GetAll()
        {
            return _context.ColliLists.ToList();
        }

        public IEnumerable<ColliList> GetAllById(List<int> ids)
        {
            return _context.ColliLists.Where(cl => ids.Contains(cl.Id));
        }
    }
}
