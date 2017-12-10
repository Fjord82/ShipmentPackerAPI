using System;
using System.Collections.Generic;
using ShipmentPackerBLL.BusinessObjects;
using ShipmentPackerBLL.Converters;
using ShipmentPackerDAL;

namespace ShipmentPackerBLL.Services
{
    public class UserService : IUserService
    {
        public IDALFacade _facade { get; set; }
        UserConverter _conv;

        public UserService(IDALFacade facade)
        {
            _facade = facade;
            _conv = new UserConverter();
        }

        public UserBO Create(UserBO user)
        {
            if (user == null)
            {
                return null;
            }
            using (var uow = _facade.UnitOfWork)
            {
                var createdUser = uow.UserRepository.Create(_conv.ConvertBO(user));
                uow.Complete();
                return _conv.Convert(createdUser);
            }
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
