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


        public ProjectServiceTest()
        {
            service = new ProjectService(new MockFacade());
        }

        [Fact]
        public void CreatePassTest()
        {
            ProjectBO project = new ProjectBO()
            {
                ProjectName = "ImportantProject",
                CreatorName = "Bobby",
                CustomerName = "Billy",
                FreightType = "Mega tough"
            };
            var newProject = service.Create(project);

            Assert.True(newProject.Id > 0);
        }

        [Fact]
        public void CreateFailTest()
        {
            var newProject = service.Create(null);

            Assert.Null(newProject);
        }
    }
}
