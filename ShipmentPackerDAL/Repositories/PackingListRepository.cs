using System;
using System.Collections.Generic;
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
           /* _context.PackingLists.Add(packingList);
            return packingList;*/

            throw new NotImplementedException();
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
