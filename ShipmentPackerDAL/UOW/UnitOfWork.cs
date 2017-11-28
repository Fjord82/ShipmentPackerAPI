using System;
using ShipmentPackerDAL.Context;
using ShipmentPackerDAL.Repositories;

namespace ShipmentPackerDAL.UOW
{
    public class UnitOfWork : IUnitOfWork
    {

        public IProjectRepository ProjectRepository { get; internal set; }

        private MyDBContext _context;

        public UnitOfWork()
        {
            _context = new MyDBContext();
            _context.Database.EnsureCreated();
            ProjectRepository = new ProjectRepository(_context);
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
