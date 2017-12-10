using System;
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



        public UserBO getUserMock()
        {
            UserBO user = new UserBO()
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
            };

            return user;
        }


        private void clearDb()
        {
            service._facade.UnitOfWork.clearDb();
        }
    }
}
