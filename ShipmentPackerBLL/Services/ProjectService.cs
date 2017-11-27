using System;
using ShipmentPackerBLL.BusinessObjects;
using ShipmentPackerBLL.Converters;
using ShipmentPackerDAL;

namespace ShipmentPackerBLL.Services
{
    public class ProjectService : IProjectService
    {
        IDALFacade _facade;
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
    }
}
