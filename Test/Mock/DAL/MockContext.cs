using System;
using System.Collections.Generic;
using ShipmentPackerDAL.Entities;

namespace Test.Mock.DAL
{
    public class MockContext
    {
        public List<Project> Projects;

        public MockContext()
        {
            Projects = new List<Project>();
        }
    }
}
