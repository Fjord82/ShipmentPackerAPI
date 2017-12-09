using System;
using System.Collections.Generic;
using System.Linq;
using ShipmentPackerDAL;
using ShipmentPackerDAL.Entities;

namespace Test.Mock.DAL
{
    public class MockFreightConditionRepository : IFreightConditionRepository
    {
        MockContext _context;

        public MockFreightConditionRepository(MockContext context)
        {
            _context = context;
        }

        public FreightCondition Create(FreightCondition condition)
        {
            _context.FreightConditions.Add(condition);
            return condition;
        }

        public FreightCondition Delete(int Id)
        {
            var conditionToDelete = Get(Id);
            _context.FreightConditions.Remove(conditionToDelete);
            return conditionToDelete;
        }

        public FreightCondition Get(int Id)
        {
            return _context.FreightConditions.FirstOrDefault(fc => fc.Id == Id);
        }

        public List<FreightCondition> GetAll()
        {
            return _context.FreightConditions.ToList();
        }

        public IEnumerable<FreightCondition> GetAllById(List<int> ids)
        {
            if (ids == null)
                return null;

            return _context.FreightConditions.Where(i => ids.Contains(i.Id));
        }
    }
}
