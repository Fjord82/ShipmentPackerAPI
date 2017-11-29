using System;
using System.ComponentModel.DataAnnotations;
using Xunit;
using System.Collections.Generic;
using ShipmentPackerBLL.Services;
using Test.Mock.DAL;
using ShipmentPackerBLL.BusinessObjects;

namespace Test.BLL.Services
{
   public class ProjectServiceTest
    {

        ProjectService service;
        MockFacade facade;

        public ProjectServiceTest()
        {
            facade = new MockFacade();
            service = new ProjectService(facade);
        }

        [Fact]
        public void CreatePassTest()
        {
            var project = getProjectMock();
            var newProject = service.Create(project);

            Assert.True(newProject.Id > 0);

            clearDb();
        }

        [Fact]
        public void CreateFailTest()
        {
            var newProject = service.Create(null);

            Assert.Null(newProject);

            clearDb();
        }

        [Fact]
        public void ReadPassTest()
        {
            var project = getProjectMock();
            var newProject = service.Create(project);

            var createdProject = service.Get(newProject.Id);
            Assert.Equal(newProject.CreatorName, createdProject.CreatorName);

            clearDb();
        }

        [Fact]
        public void ReadFailTest()
        {
            for (int i= -2; i < 1; i++)
            {
                var entityProject = service.Get(i);

                Assert.Null(entityProject);
            }
            clearDb();
        }

        [Fact]
        public void GetAllPassTest()
        {
            List<ProjectBO> createdProjects = new List<ProjectBO>();
            for (int i = 0; i < 2; i++)
            {
                var project = getProjectMock();
                var newProject = service.Create(project);
                createdProjects.Add(newProject);
            }

            var projectList = service.GetAll();
            Assert.Equal(createdProjects.Count, projectList.Count);
            Assert.Equal(createdProjects.ToString(), projectList.ToString());

            clearDb();
        }

        [Fact]
        public void DeletePassTest()
        {
            var newProject = getProjectMock();
            newProject = service.Create(newProject);
            var deletedProject = service.Delete(newProject.Id);

            var checkProject = service.Get(deletedProject.Id);

            Assert.Null(checkProject);

            clearDb(); 
        }

        [Fact]
        public void DeleteFailTest()
        {
            for (int i = -2; i < 5; i++)
            {
                var entityProject = service.Delete(i);

                Assert.Null(entityProject);
            }
            clearDb();
        }


        public ProjectBO getProjectMock()
        {
            ProjectBO project = new ProjectBO()
            {
                ProjectName = "ImportantProject",
                CreatorName = "Bobby",
                CustomerName = "Billy",
                FreightType = "Mega tough"
            };

            return project;
        }

        private void clearDb()
        {
            service._facade.UnitOfWork.clearDb();
        }
    }
}
