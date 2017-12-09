using System;
using ShipmentPackerDAL.Context;
using ShipmentPackerDAL.Repositories;

namespace ShipmentPackerDAL.UOW
{
    public class UnitOfWork : IUnitOfWork
    {

        public IProjectRepository ProjectRepository { get; internal set; }
        public IPackingListRepository PackingListRepository { get; internal set; }
        public IColliListRepository ColliListRepository { get; internal set; }
        public IItemRepository ItemRepository { get; internal set; }
        public IPackItemRepository PackItemRepository { get; internal set; }
        public IColliItemRepository ColliItemRepository { get; internal set; }
        public IFreightConditionRepository FreightConditionRepository { get; internal set; }

        private MyDBContext Context;

        public UnitOfWork()
        {
            Context = new MyDBContext();
            Context.Database.EnsureCreated();
            ProjectRepository = new ProjectRepository(Context);
            PackingListRepository = new PackingListRepository(Context);
            ColliListRepository = new ColliListRepository(Context);
            ItemRepository = new ItemRepository(Context);
            PackItemRepository = new PackItemRepository(Context);
            ColliItemRepository = new ColliItemRepository(Context);
            FreightConditionRepository = new FreightConditionRepository(Context);
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
