using System;
using System.Collections.Generic;
using System.Linq;
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
            if (Id < 1)
            {
                return null;
            }
            using (var uow = _facade.UnitOfWork)
            {

                var user = Get(Id);
                if (user == null)
                {
                    return null;
                }
                user = _conv.Convert(uow.UserRepository.Delete(Id));
                uow.Complete();
                return user;
            }
        }

        public UserBO Get(int Id)
        {
            if (Id < 1)
            {
                return null;
            }
            using (var uow = _facade.UnitOfWork)
            {
                var user = _conv.Convert(uow.UserRepository.Get(Id));
                uow.Complete();
                return user;
            }
        }

        public List<UserBO> GetAll()
        {
            using (var uow = _facade.UnitOfWork)
            {
                return uow.UserRepository.GetAll().Select(u => _conv.Convert(u)).ToList();
            }
        }

        public UserBO Update(UserBO user)
        {
            throw new NotImplementedException();
        }
    }
}
