using System;
using System.Collections.Generic;
using ShipmentPackerBLL.BusinessObjects;
using ShipmentPackerBLL.Services;
using Test.Mock.DAL;
using Xunit;

namespace Test.BLL.Services
{
    public class UserServiceTest
    {
        UserService service;
        MockFacade facade;

        public UserServiceTest()
        {
            facade = new MockFacade();
            service = new UserService(facade);
        }

        [Fact]
        public void CreatePassTest()
        {
            try
            {
                var user = getUserMock();
                var newUser = service.Create(user);

                Assert.True(newUser.Id > 0);
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
            var newUser = service.Create(null);

            Assert.Null(newUser);

            clearDb();
        }

        [Fact]
        public void ReadPassTest()
        {
            try
            {
                var user = getUserMock();
                var newUser = service.Create(user);

                var createdUser = service.Get(newUser.Id);
                Assert.Equal(newUser.UserName, createdUser.UserName);
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
            for (int i = -2; i < 1; i++)
            {
                var entityUser = service.Get(i);

                Assert.Null(entityUser);
            }
            clearDb();
        }

        [Fact]
        public void GetAllPassTest()
        {
            try
            {
                List<UserBO> createdUsers = new List<UserBO>();
                for (int i = 0; i < 2; i++)
                {
                    var user = getUserMock();
                    var newUser = service.Create(user);
                    createdUsers.Add(newUser);
                }

                var userList = service.GetAll();
                Assert.Equal(createdUsers.Count, userList.Count);
                Assert.Equal(createdUsers.ToString(), userList.ToString());
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



        public UserBO getUserMock()
        {
            UserBO user = new UserBO()
            {
                Id = 12,
                FirstName = "ImportantProject",
                LastName = "Bobby",
                UserName = "Billy",
                HomePhoneNumber = "20202020",
                WorkPhoneNumber = "75303030",
                WorkEmail = "drillenissen@gmail.com",
                Password = "TotalSecret",
                WorkTitle = "HardWorker"
            };

            return user;
        }


        private void clearDb()
        {
            service._facade.UnitOfWork.clearDb();
        }
    }
}
