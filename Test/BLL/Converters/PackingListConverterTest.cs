using System;
using System.Collections.Generic;
using ShipmentPackerBLL.BusinessObjects;
using ShipmentPackerBLL.Converters;
using ShipmentPackerDAL.Entities;
using Xunit;

namespace Test.BLL.Converters
{
    public class PackingListConverterTest
    {
        PackingListConverter packConv;
        List<PackingListBO> packingListBOs;
        List<PackingList> packingLists;

        public PackingListConverterTest()
        {

            packConv = new PackingListConverter();
            packingListBOs = new List<PackingListBO>();
            packingListBOs.Add(new PackingListBO()
            {
                Id = 30,
                PackingName = "Thorsminde",
                CreatorName = "Emil",
                DeliveryAddress = "Skolegade",
                DeliveryDate = "02-10-2107",
                ItemType = "Cylinder",
                FreightType = "Road"
            });

            packingListBOs.Add(new PackingListBO()
            {
                FreightType = "PackingList without FrieghtType info"
            });

            packingListBOs.Add(new PackingListBO());

            packingLists = new List<PackingList>();

            packingLists.Add(new PackingList()
            {
                Id = 30,
                PackingName = "Thorsminde",
                CreatorName = "Emil",
                DeliveryAddress = "Skolegade",
                DeliveryDate = "02-10-2107",
                ItemType = "Cylinder",
                FreightType = "Road"
            });

            packingLists.Add(new PackingList()
            {
                FreightType = "PackingList without FrieghtType info"
            });

            packingLists.Add(new PackingList());

        }

            [Fact]
            public void ConvertPackingListBOPassTest()
            {
                foreach (var BO in packingListBOs)
                {
                    var packingList = packConv.ConvertBO(BO);
                    Assert.NotNull(packingList);
                    Assert.Equal(BO.ItemType, packingList.ItemType);
                    Assert.Equal(BO.FreightType, packingList.FreightType);
                    Assert.Equal(BO.Id, packingList.Id);
                }
            }

            [Fact]
            public void ConvertPackingListBOFailTest()
            {
                var packingList = packConv.ConvertBO(null);

                Assert.Null(packingList);
            }

            [Fact]
            public void ConvertPackingListPassTest()
            {
                foreach (var entity in packingLists)
                {
                    var packingListBO = packConv.Convert(entity);
                    Assert.NotNull(packingListBO);
                    Assert.Equal(entity.ItemType, packingListBO.ItemType);
                    Assert.Equal(entity.FreightType, packingListBO.FreightType);
                    Assert.Equal(entity.Id, packingListBO.Id);
                }
            }

            [Fact]
            public void ConvertPackingListFailTest()
            {
                var packingListBO = packConv.Convert(null);

                Assert.Null(packingListBO);
            }
         }
   }

