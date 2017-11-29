using System;
using System.Collections.Generic;
using System.Linq;
using ShipmentPackerDAL.Context;
using ShipmentPackerDAL.Entities;

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
            throw new NotImplementedException();
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
