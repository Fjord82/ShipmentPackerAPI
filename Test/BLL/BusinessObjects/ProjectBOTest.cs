using System;
using ShipmentPackerBLL.BusinessObjects;
using System.ComponentModel.DataAnnotations;
using Xunit;
using System.Collections.Generic;

namespace Test.BLL.BusinessObjects
{
    public class ProjectBOTest
    {
        static ProjectBO project = new ProjectBO();

        [Fact]
        public void ValidateProjectNameFailTest()
        {
            Assert.Null(project.ProjectName);

            var result = Validator.TryValidateProperty(project.ProjectName, new ValidationContext(project) {MemberName = "ProjectName"}, null);

            Assert.False(result);
        }

        [Fact]
        public void ValidateProjectNamePassTest()
        {
            project.ProjectName = "Petro in the Wales";

            Assert.Equal("Petro in the Wales", project.ProjectName);

            var result = Validator.TryValidateProperty(project.ProjectName, new ValidationContext(project) {MemberName = "ProjectName"}, null);

            Assert.True(result);
            reset();
        }

        [Fact]
        public void ValidateCreatorNameFailTest()
        {
            Assert.Null(project.CreatorName);

            var result = Validator.TryValidateProperty(project.CreatorName, new ValidationContext(project) {MemberName = "CreatorName"}, null);

            Assert.False(result);
        }

        [Fact]
        public void ValidateCreatorNamePassTest()
        {
            project.CreatorName = "Niels";

            Assert.Equal("Niels", project.CreatorName);

            var result = Validator.TryValidateProperty(project.CreatorName, new ValidationContext(project) { MemberName = "CreatorName" }, null);
            Assert.True(result);
            reset();
        }

        [Fact]
        public void ValidateCustomerNameFailTest()
        {
            Assert.Null(project.CustomerName);

            var result = Validator.TryValidateProperty(project.CustomerName, new ValidationContext(project) { MemberName = "CustomerName" }, null);

            Assert.False(result);
        }

        [Fact]
        public void ValidateCustomerNamePassTest()
        {
            project.CustomerName = "Petro";

            Assert.Equal("Petro", project.CustomerName);

            var result = Validator.TryValidateProperty(project.CustomerName, new ValidationContext(project) { MemberName = "CustomerName" }, null);
            Assert.True(result);
            reset();
        }

        [Fact]
        public void ValidateCustomerPackingListsPassTest()
        {
            project.PackingLists = new List<int>();
            project.PackingLists.Add(1);

            Assert.NotNull(project.PackingLists);
            Assert.Single(project.PackingLists);
            Assert.Contains(1, project.PackingLists);

            reset();
        }

        [Fact]
        public void ValidateCustomerPackingListFailTest()
        {
            project.PackingLists = new List<int>();
            Assert.Empty(project.PackingLists);

            reset();
        }


        public void reset()
        {
            project = new ProjectBO();
        }
     

    }
}
