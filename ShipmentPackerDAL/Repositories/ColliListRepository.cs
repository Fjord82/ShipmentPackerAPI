using System;
using System.Collections.Generic;
using ShipmentPackerDAL.Context;
using ShipmentPackerDAL.Entities;

namespace ShipmentPackerDAL.Repositories
{
    public class ColliListRepository : IColliListRepository
    {
        MyDBContext _context;

        public ColliListRepository(MyDBContext context)
        {
            _context = context;
        }

        public ColliList Create(ColliList colliList)
        {
           /* _context.ColliLists.Add(colliList);
            return colliList;*/

            throw new NotImplementedException();
        }

        public ColliList Delete(int Id)
        {
            throw new NotImplementedException();
        }

        public ColliList Get(int Id)
        {
            throw new NotImplementedException();
        }

        public List<ColliList> GetAll()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ColliList> GetAllById(List<int> ids)
        {
            throw new NotImplementedException();
        }
    }
}
