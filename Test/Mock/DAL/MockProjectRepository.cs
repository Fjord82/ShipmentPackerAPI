using System;
using System.Collections.Generic;
using ShipmentPackerDAL;
using ShipmentPackerDAL.Entities;

namespace Test.Mock.DAL
{
    public class MockProjectRepository : IProjectRepository
    {
        private MockContext _context;
        private int _Id = 0;


        public MockProjectRepository(MockContext context)
        {
            _context = context;
        }

        public Project Create(Project project)
        {
            var newProject = project;
            newProject.Id = _Id;
            _Id++;
            _context.Projects.Add(newProject);
            return newProject;
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
