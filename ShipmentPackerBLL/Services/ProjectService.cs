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
        PackingListConverter _convPL;

        public ProjectService(IDALFacade facade)
        {
            _facade = facade;
            _conv = new ProjectConverter();
            _convPL = new PackingListConverter();

        }

        public ProjectBO Create(ProjectBO project)
        {
            if (project == null)
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
            if (Id < 1)
            {
                return null;
            }

            using (var uow = _facade.UnitOfWork)
            {
                var project = _conv.Convert(uow.ProjectRepository.Get(Id));
                if (project != null)
                {
                    project.PackingLists = uow.PackingListRepository.GetAllById(project.PackingListIds)
                        .Select(pl => _convPL.Convert(pl))
                        .ToList();
                }
                uow.Complete();
                return project;
            }
        }

        public List<ProjectBO> GetAll()
        {
            using (var uow = _facade.UnitOfWork)
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
            if (project == null)
                return null;

            using (var uow = _facade.UnitOfWork)
            {
                var projectEnt = uow.ProjectRepository.Get(project.Id);

                if (projectEnt == null)
                    return null;

                var projectUpdated = _conv.ConvertBO(project);

                projectEnt.Id = projectUpdated.Id;
                projectEnt.ProjectName = projectUpdated.ProjectName;
                projectEnt.CreatorName = projectUpdated.CreatorName;
                projectEnt.CustomerName = projectUpdated.CustomerName;
                projectEnt.IsActive = projectUpdated.IsActive;

                if (projectUpdated.PackingLists != null)
                {
                    projectEnt.PackingLists.RemoveAll(
                        p => !projectUpdated.PackingLists.Exists(
                            pu => pu.PackingListID == p.PackingListID &&
                            pu.ProjectID == p.ProjectID));

                    projectUpdated.PackingLists.RemoveAll(
                        p => projectEnt.PackingLists.Exists(
                            pu => pu.PackingListID == p.PackingListID &&
                            pu.ProjectID == p.ProjectID));

                    projectEnt.PackingLists.AddRange(
                        projectUpdated.PackingLists);
                }

                uow.Complete();
                return _conv.Convert(projectEnt);
            }
        }

    }
}
