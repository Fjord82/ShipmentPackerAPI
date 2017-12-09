using System;
using Microsoft.EntityFrameworkCore;
using ShipmentPackerDAL;
using ShipmentPackerDAL.Repositories;

namespace Test.Mock.DAL
{
    public class MockUnitOfWork : IUnitOfWork
    {

        public IProjectRepository ProjectRepository { get; internal set; }

        public IPackingListRepository PackingListRepository { get; internal set; }

        public IColliListRepository ColliListRepository { get; internal set; }

        public IItemRepository ItemRepository { get; internal set; }

        public IPackItemRepository PackItemRepository { get; internal set; }

        public IColliItemRepository ColliItemRepository { get; internal set; }

        public IFreightConditionRepository FreightConditionRepository { get; internal set; }

        private MockContext Context;

        public MockUnitOfWork()
        {
            Context = new MockContext();
            Context.Database.EnsureCreated();
            ProjectRepository = new MockProjectRepository(Context);
            PackingListRepository = new MockPackingListRepository(Context);
            ColliListRepository = new MockColliListRepository(Context);
            ItemRepository = new MockItemRepository(Context);
            PackItemRepository = new MockPackItemRepository(Context);
            ColliItemRepository = new MockColliItemRepository(Context);
            FreightConditionRepository = new MockFreightConditionRepository(Context);
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
            try
            {
                Context.Database.EnsureDeleted();
                Context.Database.EnsureCreated();
            }catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

    }
}
