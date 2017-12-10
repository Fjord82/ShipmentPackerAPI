using System;
using System.Collections.Generic;
using ShipmentPackerBLL.BusinessObjects;
using ShipmentPackerDAL;

namespace ShipmentPackerBLL.Services
{
    public class UserService : IUserService
    {
        public IDALFacade _facade { get; set; }

        public UserService(IDALFacade facade)
        {
        }

        public UserBO Create(UserBO user)
        {
            throw new NotImplementedException();
        }

        public UserBO Delete(int Id)
        {
            throw new NotImplementedException();
        }

        public UserBO Get(int Id)
        {
            throw new NotImplementedException();
        }

        public List<UserBO> GetAll()
        {
            throw new NotImplementedException();
        }

        public UserBO Update(UserBO user)
        {
            throw new NotImplementedException();
        }
    }
}
