﻿using System;
using ShipmentPackerDAL.Context;
using ShipmentPackerDAL.Repositories;

namespace ShipmentPackerDAL.UOW
{
    public class UnitOfWork : IUnitOfWork
    {

        public IProjectRepository ProjectRepository { get; internal set; }
        public IPackingListRepository PackingListRepository { get; internal set; }
        public IColliListRepository ColliListRepository { get; internal set; }

        private MyDBContext Context;

        public UnitOfWork()
        {
            Context = new MyDBContext();
            Context.Database.EnsureCreated();
            ProjectRepository = new ProjectRepository(Context);
            PackingListRepository = new PackingListRepository(Context);
            ColliListRepository = new ColliListRepository(Context);
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
