using System;
using System.Collections.Generic;
using ShipmentPackerBLL.BusinessObjects;
using ShipmentPackerBLL.Converters;
using ShipmentPackerDAL.Entities;
using Xunit;

namespace Test.BLL.Converters
{
    public class ColliListConverterTest
    {
        ColliListConverter clConv;
        List<ColliListBO> clListBOs;
        List<ColliList> clLists;

        public ColliListConverterTest()
        {
            clConv = new ColliListConverter();
            clListBOs = new List<ColliListBO>();
            clListBOs.Add(new ColliListBO()
            {
                Id = 40,
                ItemType = "ImportantItem",
                FreightType = "Mega tough",
                Dimensions= "Large",
                IsActive = true,
                NetWeight = 20,
                ProjectName = "Project",
                TotalWeight = 25,
                Worker = "Billy"
            });

            clListBOs.Add(new ColliListBO()
            {
                ItemType = "Item Without other info"
            });

            clListBOs.Add(new ColliListBO());

            clLists = new List<ColliList>();
            clLists.Add(new ColliList()
            {
                Id = 40,
                ItemType = "ImportantItem",
                FreightType = "Mega tough"
            });

            clLists.Add(new ColliList()
            {
                ItemType = "Item Without other info"
            });

            clLists.Add(new ColliList());


        }

        [Fact]
        public void ConvertColliListBOPassTest()
        {
            foreach (var BO in clListBOs)
            {
                var colliList = clConv.ConvertBO(BO);
                Assert.NotNull(colliList);
                Assert.Equal(BO.ItemType, colliList.ItemType);
                Assert.Equal(BO.FreightType, colliList.FreightType);
                Assert.Equal(BO.Id, colliList.Id);
                Assert.Equal(BO.IsActive, colliList.IsActive);
                Assert.Equal(BO.NetWeight, colliList.NetWeight);
                Assert.Equal(BO.TotalWeight, colliList.TotalWeight);
                Assert.Equal(BO.Dimensions, colliList.Dimensions);
                Assert.Equal(BO.ProjectName, colliList.ProjectName);
                Assert.Equal(BO.Worker, colliList.Worker);
            }
        }

        [Fact]
        public void ConvertColliListBOFailTest()
        {
            var colliList = clConv.ConvertBO(null);

            Assert.Null(colliList);
        }

        [Fact]
        public void ConvertColliListPassTest()
        {
            foreach (var entity in clLists)
            {
                var ColliListBO = clConv.Convert(entity);
                Assert.NotNull(ColliListBO);
                Assert.Equal(entity.ItemType, ColliListBO.ItemType);
                Assert.Equal(entity.FreightType, ColliListBO.FreightType);
                Assert.Equal(entity.Id, ColliListBO.Id);
            }
        }

        [Fact]
        public void ConvertColliListFailTest()
        {
            var ColliListBO = clConv.Convert(null);

            Assert.Null(ColliListBO);
        }
    }

}
