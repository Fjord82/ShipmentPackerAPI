using System;
using Xunit;
using ShipmentPackerBLL.Converters;
using ShipmentPackerBLL.BusinessObjects;
using System.Collections.Generic;
using ShipmentPackerDAL.Entities;

namespace Test.BLL.Converters
{
    public class ProjectCoverterTest
    {
        ProjectConverter proConv;
        List<ProjectBO> projectBOs;
        List<Project> projects;

        public ProjectCoverterTest()
        {
            proConv = new ProjectConverter();
            projectBOs = new List<ProjectBO>();
            projectBOs.Add(new ProjectBO()
            {
                Id = 20,
                ProjectName = "ImportantProject",
                CreatorName = "Bobby",
                CustomerName = "Billy",
                FreightType = "Mega tough"
            });

            projectBOs.Add(new ProjectBO()
            {
                ProjectName = "Project Without other info"
            });

            projectBOs.Add(new ProjectBO());

            projects = new List<Project>();
            projects.Add(new Project()
            {
                Id = 20,
                ProjectName = "ImportantProject",
                CreatorName = "Bobby",
                CustomerName = "Billy",
                FreightType = "Mega tough"
            });

            projects.Add(new Project()
            {
                ProjectName = "Project Without other info"
            });

            projects.Add(new Project());


        }

        [Fact]
        public void ConvertProjectBOPassTest()
        {
            foreach (var BO in projectBOs)
            {
                var project = proConv.ConvertBO(BO);
                Assert.NotNull(project);
                Assert.Equal(BO.ProjectName, project.ProjectName);
                Assert.Equal(BO.CreatorName, project.CreatorName);
                Assert.Equal(BO.CustomerName, project.CustomerName);
                Assert.Equal(BO.Id, project.Id);
            }
        }

        [Fact]
        public void ConvertProjectBOFailTest()
        {
            var project = proConv.ConvertBO(null);

            Assert.Null(project);
        }

        [Fact]
        public void ConvertProjectPassTest()
        {
            foreach (var entity in projects)
            {
                var projectBO = proConv.Convert(entity);
                Assert.NotNull(projectBO);
                Assert.Equal(entity.ProjectName, projectBO.ProjectName);
                Assert.Equal(entity.CreatorName, projectBO.CreatorName);
                Assert.Equal(entity.CustomerName, projectBO.CustomerName);
                Assert.Equal(entity.Id, projectBO.Id);
            }
        }

        [Fact]
        public void ConvertProjectFailTest()
        {
            var projectBO = proConv.Convert(null);

            Assert.Null(projectBO);
        }
    }
}
