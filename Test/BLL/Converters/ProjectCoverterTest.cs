using System;
using Xunit;
using ShipmentPackerBLL.Converters;
using ShipmentPackerBLL.BusinessObjects;

namespace Test.BLL.Converters
{
    public class ProjectCoverterTest
    {
        ProjectConverter proConv;
        ProjectBO projectBO;

        public ProjectCoverterTest()
        {
            proConv = new ProjectConverter();

            projectBO = new ProjectBO()
            {
                CreatorName = "Bobby",
                CustomerName = "Billy",
                FreightType = "Mega tough",
                ProjectName = "Project Get Cool"
            };
        }



       [Fact]
        public void ConvertProjectBOPassTest()
        {
           var project = proConv.Convert(projectBO);

            Assert.Equal(projectBO.CreatorName, project.CreatorName);

        }
    }
}
