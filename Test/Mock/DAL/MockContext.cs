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

        public DbSet<Project> Projects { get; set; }
    }
}
