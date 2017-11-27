using System;
using System.Collections.Generic;
using ShipmentPackerDAL;
using ShipmentPackerDAL.Entities;

namespace Test.Mock.DAL
{
    public class MockProjectRepository : IProjectRepository
    {
        private MockContext _context;

        public MockProjectRepository(MockContext context)
        {
            _context = context;
        }

        public Project Create(Project project)
        {
            _context.Projects.Add(project);
            return project;
        }

        public Project Delete(int Id)
        {
            throw new NotImplementedException();
        }

        public Project Get(int Id)
        {
            throw new NotImplementedException();
        }

        public List<Project> GetAll()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Project> GetAllById(List<int> ids)
        {
            throw new NotImplementedException();
        }
    }
}
