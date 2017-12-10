using System;
using System.Collections.Generic;
using ShipmentPackerBLL.BusinessObjects;
using ShipmentPackerBLL.Converters;
using ShipmentPackerDAL.Entities;
using Xunit;

namespace Test.BLL.Converters
{
    public class UserConverterTest
    {
        UserConverter _conv;
        List<UserBO> userBOs;
        List<User> users;

        public UserConverterTest()
        {
            _conv = new UserConverter();
            userBOs = new List<UserBO>();
            userBOs.Add(new UserBO()
            {
                Id = 20,
                FirstName = "ImportantProject",
                LastName = "Bobby",
                UserName = "Billy",
                HomePhoneNumber = "20202020",
                WorkPhoneNumber = "75303030",
                WorkEmail = "drillenissen@gmail.com",
                Password = "TotalSecret",
                WorkTitle = "HardWorker"
            });

            userBOs.Add(new UserBO()
            {
                UserName = "User Without any name"
            });

            userBOs.Add(new UserBO());

            users = new List<User>();
            users.Add(new User()
            {
                Id = 20,
                FirstName = "ImportantProject",
                LastName = "Bobby",
                UserName = "Billy",
                HomePhoneNumber = "20202020",
                WorkPhoneNumber = "75303030",
                WorkEmail = "drillenissen@gmail.com",
                Password = "TotalSecret",
                WorkTitle = "HardWorker"
            });

            users.Add(new User()
            {
                UserName = "User Without any name"
            });

            users.Add(new User());


        }

        [Fact]
        public void ConvertUserBOPassTest()
        {
            foreach (var BO in userBOs)
            {
                var user = _conv.ConvertBO(BO);
                Assert.NotNull(user);
                Assert.Equal(BO.FirstName, user.FirstName);
                Assert.Equal(BO.LastName, user.LastName);
                Assert.Equal(BO.UserName, user.UserName);
                Assert.Equal(BO.HomePhoneNumber, user.HomePhoneNumber);
                Assert.Equal(BO.WorkPhoneNumber, user.WorkPhoneNumber);
                Assert.Equal(BO.WorkEmail, user.WorkEmail);
                Assert.Equal(BO.Password, user.Password);
                Assert.Equal(BO.WorkTitle, user.WorkTitle);
                Assert.Equal(BO.Id, user.Id);
            }
        }

        [Fact]
        public void ConvertUserBOFailTest()
        {
            var user = _conv.ConvertBO(null);

            Assert.Null(user);
        }

        [Fact]
        public void ConvertUserPassTest()
        {
            foreach (var entity in users)
            {
                var userBO = _conv.Convert(entity);
                Assert.NotNull(userBO);
                Assert.Equal(entity.FirstName, userBO.FirstName);
                Assert.Equal(entity.LastName, userBO.LastName);
                Assert.Equal(entity.UserName, userBO.UserName);
                Assert.Equal(entity.HomePhoneNumber, userBO.HomePhoneNumber);
                Assert.Equal(entity.WorkPhoneNumber, userBO.WorkPhoneNumber);
                Assert.Equal(entity.WorkEmail, userBO.WorkEmail);
                Assert.Equal(entity.Password, userBO.Password);
                Assert.Equal(entity.WorkTitle, userBO.WorkTitle);
                Assert.Equal(entity.Id, userBO.Id);
            }
        }

        [Fact]
        public void ConvertUserFailTest()
        {
            var userBO = _conv.Convert(null);

            Assert.Null(userBO);
        }
    }
}
