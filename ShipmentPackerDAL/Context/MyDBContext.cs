using System;
using Microsoft.EntityFrameworkCore;
using ShipmentPackerDAL.Entities;

namespace ShipmentPackerDAL.Context
{
    public class MyDBContext : DbContext
    {
        static DbContextOptions<MyDBContext> options =
            new DbContextOptionsBuilder<MyDBContext>()
            .UseInMemoryDatabase("TheDB")
                .Options;

        //For Local host
        //public MyDBContext() : base(options)
        //{

        //}

        //For Azure Deployment
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(@"Server=tcp:shipmentpacker.database.windows.net,1433;Initial Catalog=ShipmentPackerDB;Persist Security Info=False;User ID=NotMyProblem;Password=SuperSecretPassword1;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
            }
        }

        public DbSet<Project> Projects { get; set; }
        //public DbSet<PackingList> PackingLists { get; set; }
   }
}
