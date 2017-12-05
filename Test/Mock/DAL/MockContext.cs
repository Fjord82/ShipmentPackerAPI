using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using ShipmentPackerDAL.Entities;

namespace Test.Mock.DAL
{
    public class MockContext : DbContext
    {
        static DbContextOptions<MockContext> options =
            new DbContextOptionsBuilder<MockContext>()
                .UseInMemoryDatabase("MockDB")
                .Options;

        //For Local host
        public MockContext() : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
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

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Project> Projects { get; set; }
        public DbSet<PackingList> PackingLists { get; set; }
        public DbSet<ColliList> ColliLists { get; set; }
        public DbSet<Item> Items { get; set; }

    }
}
