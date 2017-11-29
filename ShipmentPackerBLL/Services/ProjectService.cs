using System;
using System.Collections.Generic;
using System.Linq;
using ShipmentPackerBLL.BusinessObjects;
using ShipmentPackerBLL.Converters;
using ShipmentPackerDAL;

namespace ShipmentPackerBLL.Services
{
    public class ProjectService : IProjectService
    {
        public IDALFacade _facade { get; set; }
        ProjectConverter _conv;

        public ProjectService(IDALFacade facade)
        {
            _facade = facade;
            _conv = new ProjectConverter();

        }

        public ProjectBO Create(ProjectBO project)
        {
            if(project == null)
            {
                return null;
            }

            using (var uow = _facade.UnitOfWork)
            {
                var createdProject = uow.ProjectRepository.Create(_conv.ConvertBO(project));
                uow.Complete();
                return _conv.Convert(createdProject);
            }
        }

        public ProjectBO Get(int Id)
        {
            if(Id < 1)
            {
                return null;
            }

            using(var uow = _facade.UnitOfWork)
            {
                var project = uow.ProjectRepository.Get(Id);
                uow.Complete();
                return _conv.Convert(project);
            }
        }

        public List<ProjectBO> GetAll()
        {
            using(var uow = _facade.UnitOfWork)
            {
                return uow.ProjectRepository.GetAll().Select(p => _conv.Convert(p)).ToList();
            }
        }


        public ProjectBO Delete(int Id)
        {
            if (Id < 1)
            {
                return null;
            }
            using (var uow = _facade.UnitOfWork)
            {

                var project = Get(Id);
                if (project == null)
                {
                    return null;
                }
                project = _conv.Convert(uow.ProjectRepository.Delete(Id));
                uow.Complete();
                return project;
            }
        }

        public ProjectBO Update(ProjectBO project)
        {
            throw new NotImplementedException();
        }

        
    }
}
