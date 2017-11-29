using System;
using System.Collections.Generic;
using System.Linq;
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
            return _context.Projects.FirstOrDefault(p => p.Id == Id);

        }

        public List<Project> GetAll()
        {
            return _context.Projects.ToList();
        }

        public IEnumerable<Project> GetAllById(List<int> ids)
        {

            return _context.Projects.Where(p => ids.Contains(p.Id));
        }

    }
}
