﻿using System;
using System.Collections.Generic;
using System.Linq;
using ShipmentPackerDAL.Context;
using ShipmentPackerDAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace ShipmentPackerDAL.Repositories
{
    public class ProjectRepository : IProjectRepository
    {
        MyDBContext _context;

        public ProjectRepository(MyDBContext context)
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
    }
}
