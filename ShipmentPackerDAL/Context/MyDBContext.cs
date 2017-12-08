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
        public MyDBContext() : base(options)
        {

        }

        //For Azure Deployment
        /*protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(@"Server=tcp:shipmentpacker.database.windows.net,1433;Initial Catalog=ShipmentPackerDB;Persist Security Info=False;User ID=NotMyProblem;Password=SuperSecretPassword1;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
            }
        }*/

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Project and PackingList relation
            modelBuilder.Entity<ProjectPackingList>()
                        .HasKey(ppl => new { ppl.ProjectID, ppl.PackingListID });

            modelBuilder.Entity<ProjectPackingList>()
                        .HasOne(p => p.Project)
                        .WithMany(ppl => ppl.PackingLists)
                        .HasForeignKey(p => p.ProjectID);

            modelBuilder.Entity<ProjectPackingList>()
                        .HasOne(ppl => ppl.PackingList)
                        .WithMany(p => p.Projects)
                        .HasForeignKey(ppl => ppl.PackingListID);

            //PackingList and ColliList relation
            modelBuilder.Entity<PackingColliList>()
                        .HasKey(pcl => new { pcl.PackingListID, pcl.ColliListID });

            modelBuilder.Entity<PackingColliList>()
                        .HasOne(p => p.PackingList)
                        .WithMany(pcl => pcl.ColliLists)
                        .HasForeignKey(p => p.PackingListID);

            modelBuilder.Entity<PackingColliList>()
                        .HasOne(pcl => pcl.ColliList)
                        .WithMany(c => c.PackingLists)
                        .HasForeignKey(pcl => pcl.ColliListID);

            //PackingList and Item relation
            /*modelBuilder.Entity<PackItem>()
                        .HasKey(pi => new { pi.PackingListId, pi.ItemId });*/

            /*modelBuilder.Entity<PackItem>()
                        .HasOne(pi => pi.PackingList)
                        .WithMany(pl => pl.PackItems)
                        .HasForeignKey(pi => pi.PackingListId);

            modelBuilder.Entity<PackItem>()
                        .HasOne(pi => pi.Item)
                        .WithMany(i => i.PackItems)
                        .HasForeignKey(pi => pi.ItemId);*/

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Project> Projects { get; set; }
        public DbSet<ColliList> ColliLists { get; set; }
        public DbSet<PackingList> PackingLists { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<PackItem> PackItems { get; set; }
        public DbSet<ColliItem> ColliItems { get; set; }

   }
}
