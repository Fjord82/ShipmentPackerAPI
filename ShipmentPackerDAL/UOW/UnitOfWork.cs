using System;
using ShipmentPackerDAL.Context;
using ShipmentPackerDAL.Repositories;

namespace ShipmentPackerDAL.UOW
{
    public class UnitOfWork : IUnitOfWork
    {

        public IProjectRepository ProjectRepository { get; internal set; }

        private MyDBContext Context;

        public UnitOfWork()
        {
            Context = new MyDBContext();
            Context.Database.EnsureCreated();
            ProjectRepository = new ProjectRepository(Context);
        }



        public int Complete()
        {
            return Context.SaveChanges();
        }

        public void Dispose()
        {
            Context.Dispose();
        }

        public void clearDb()
        {
            throw new Exception("Method only for testing purposes.");
        }
    }
}
