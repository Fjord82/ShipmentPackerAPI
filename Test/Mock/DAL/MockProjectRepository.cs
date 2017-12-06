using System;
using System.Collections.Generic;
using System.Linq;
using ShipmentPackerDAL;
using ShipmentPackerDAL.Entities;
using Microsoft.EntityFrameworkCore;

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
            //_context.Projects.Add(project);
            //project = getProjectMock();
            List<Project> projects = new List<Project>();
            projects.Add(project);

            return project;
        }

        public Project Delete(int Id)
        {
            var proj = Get(Id);
           _context.Projects.Remove(proj);
            return proj;
        }

        public Project Get(int Id)
        {
            return _context.Projects
                .Include(p => p.PackingLists)
                .FirstOrDefault(p => p.Id == Id);
        }

        public List<Project> GetAll()
        {
            return _context.Projects
                .Include(p => p.PackingLists)
                .ToList();
        }

        public IEnumerable<Project> GetAllById(List<int> ids)
        {
            if (ids == null)
                return null;
            return _context.Projects.Where(p => ids.Contains(p.Id));
        }

        /*public Project getProjectMock()
        {
            Project project = new Project()
            {
                //Id = 1,
                ProjectName = "ImportantProject",
                CreatorName = "Bobby",
                CustomerName = "Billy"
            };

            return project;
        }*/

    }
}
