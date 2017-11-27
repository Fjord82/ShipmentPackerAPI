using System;
using ShipmentPackerDAL;

namespace Test.Mock.DAL
{
    public class MockUnitOfWork : IUnitOfWork
    {

        public IProjectRepository ProjectRepository { get; internal set; }

        private MockContext _context;

        public MockUnitOfWork()
        {
            _context = new MockContext();
            _context.Database.EnsureCreated();
            ProjectRepository = new MockProjectRepository(_context);
        }


        public int Complete()
        {
            return _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
