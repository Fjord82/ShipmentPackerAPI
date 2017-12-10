using System;
using System.Collections.Generic;
using System.Linq;
using ShipmentPackerDAL;
using ShipmentPackerDAL.Entities;

namespace Test.Mock.DAL
{
    public class MockUserRepository : IUserRepository
    {
        private MockContext _context;

        public MockUserRepository(MockContext context)
        {
            _context = context;
        }

        public User Create(User user)
        {
            _context.Users.Add(user);
            return user;
        }

        public User Delete(int Id)
        {
            var user = Get(Id);
            _context.Users.Remove(user);
            return user;
        }

        public User Get(int Id)
        {
            return _context.Users.FirstOrDefault(u => u.Id == Id);
        }

        public List<User> GetAll()
        {
            return _context.Users.ToList();
        }

        public IEnumerable<User> GetAllById(List<int> ids)
        {
            if (ids == null)
                return null;
            return _context.Users.Where(u => ids.Contains(u.Id));
        }
    }
}
