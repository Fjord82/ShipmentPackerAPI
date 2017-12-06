using Xunit;
using ShipmentPackerBLL.Services;
using Test.Mock.DAL;
using ShipmentPackerBLL.BusinessObjects;
using System.Collections.Generic;
using System;

namespace Test.BLL.Services
{
   public class ProjectServiceTest
    {

        //ProjectService service;
        //MockFacade facade;

        public ProjectServiceTest()
        {
            //MockFacade facade = new MockFacade();
            //ProjectService service = new ProjectService(facade);
        }

        [Fact]
        public void CreatePassTest()
        {
            MockFacade facade = new MockFacade();
            ProjectService service = new ProjectService(facade);
            try
            {
                var project = getProjectMock();
                var newProject = service.Create(project);

                Assert.True(newProject.Id > 0);
            }
            catch (Exception e)
            {
                Assert.True(false, e.Message);
            }
            finally
            {
                clearDb();
            }
        }

        [Fact]
        public void CreateFailTest()
        {
            MockFacade facade = new MockFacade();
            ProjectService service = new ProjectService(facade);

            var newProject = service.Create(null);

            Assert.Null(newProject);

            clearDb();
        }

        [Fact]
        public void ReadPassTest()
        {
            MockFacade facade = new MockFacade();
            ProjectService service = new ProjectService(facade);
            try
            {
                var project = getProjectMock();
                var newProject = service.Create(project);

                var createdProject = service.Get(newProject.Id);
                Assert.Equal(newProject.CreatorName, createdProject.CreatorName);
            }
            catch (Exception e)
            {
                Assert.True(false, e.Message);
            }
            finally
            {
                clearDb();
            }
        }

        [Fact]
        public void ReadFailTest()
        {
            MockFacade facade = new MockFacade();
            ProjectService service = new ProjectService(facade);
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
            MockFacade facade = new MockFacade();
            ProjectService service = new ProjectService(facade);
            try
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
            } catch(Exception e)
            {
                Assert.True(false, e.Message);
            }
            finally
            {
                clearDb();
            }
        }

        [Fact]
        public void DeletePassTest()
        {
            MockFacade facade = new MockFacade();
            ProjectService service = new ProjectService(facade);
            try
            {
                var newProject = getProjectMock();
                newProject = service.Create(newProject);
                var deletedProject = service.Delete(newProject.Id);

                var checkProject = service.Get(deletedProject.Id);

                Assert.Null(checkProject);
            }
            catch (Exception e)
            {
                Assert.True(false, e.Message);
            }
            finally
            {
                clearDb();
            }
        }

        [Fact]
        public void DeleteFailTest()
        {
            MockFacade facade = new MockFacade();
            ProjectService service = new ProjectService(facade);
            for (int i = -2; i < 5; i++)
            {
                var entityProject = service.Delete(i);

                Assert.Null(entityProject);
            }
            clearDb();
        }

        [Fact]
        public void UpdatePassTest()
        {
            MockFacade facade = new MockFacade();
            ProjectService service = new ProjectService(facade);
            try
            {
                var originalProject = getProjectMock();
                originalProject = service.Create(originalProject);

                var newProject = new ProjectBO();
                newProject.Id = originalProject.Id;
                newProject.ProjectName = originalProject.ProjectName;
                newProject.CustomerName = originalProject.CustomerName;
                newProject.CreatorName = originalProject.CreatorName;
                newProject.CreatorName = "Niels";
                newProject = service.Update(newProject);

                var updatedProject = service.Get(originalProject.Id);

                Assert.Equal(originalProject.Id, newProject.Id);

                Assert.Equal("Niels", newProject.CreatorName);

                Assert.Equal(newProject.CreatorName, updatedProject.CreatorName);

                Assert.NotEqual(originalProject.CreatorName, newProject.CreatorName);
            }
            catch (Exception e)
            {
                Assert.True(false, e.Message);
            }
            finally
            {
                clearDb();
            }
        }

        [Fact]
        public void UpdateFailTest()
        {
            MockFacade facade = new MockFacade();
            ProjectService service = new ProjectService(facade);

            var originalProject = getProjectMock();
            originalProject = service.Create(originalProject);
            var newProject = originalProject;
            newProject.Id++;
            newProject = service.Update(newProject);

            var nullProject = service.Update(null);

            Assert.Null(nullProject);
            Assert.Null(newProject);

            clearDb();
        }


        public ProjectBO getProjectMock()
        {
            ProjectBO project = new ProjectBO()
            {
                Id = 1,
                ProjectName = "ImportantProject",
                CreatorName = "Bobby",
                CustomerName = "Billy"
            };

            return project;
        }


        private void clearDb()
        {
            //service._facade.UnitOfWork.clearDb();
        }
    }
}
