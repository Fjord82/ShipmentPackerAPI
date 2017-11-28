using System;
using ShipmentPackerDAL;
using ShipmentPackerDAL.Repositories;

namespace Test.Mock.DAL
{
    public class MockUnitOfWork : IUnitOfWork
    {

        public IProjectRepository ProjectRepository { get; internal set; }

        private MockContext Context;

        public MockUnitOfWork()
        {
            Context = new MockContext();
            Context.Database.EnsureCreated();
            ProjectRepository = new MockProjectRepository(Context);
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
            Context.Database.EnsureDeleted();
            Context.Database.EnsureCreated();
        }

    }
}
