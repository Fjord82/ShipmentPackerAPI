using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using ShipmentPackerDAL.Context;
using ShipmentPackerDAL.Entities;

namespace ShipmentPackerDAL.Repositories
{
    public class FreightConditionRepository : IFreightConditionRepository
    {
        MyDBContext _context;

        public FreightConditionRepository(MyDBContext context)
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
            return _context.FreightConditions
                           .Include(fc => fc.Items)
                           .FirstOrDefault(fc => fc.Id == Id);
        }

        public List<FreightCondition> GetAll()
        {
            return _context.FreightConditions
                           .Include(fc => fc.Items)
                           .ToList();
        }

        public IEnumerable<FreightCondition> GetAllById(List<int> ids)
        {
            if (ids == null)
                return null;
            return _context.FreightConditions.Where(fc => ids.Contains(fc.Id));
        }
    }
}
