using System;
using ShipmentPackerBLL.BusinessObjects;
using ShipmentPackerDAL.Entities;

namespace ShipmentPackerBLL.Converters
{
    public class UserConverter
    {
        public UserConverter()
        {
        }

        public User ConvertBO(UserBO userBO)
        {
            if (userBO == null)
            {
                return null;
            }
            return new User()
            {
                Id = userBO.Id,
                FirstName = userBO.FirstName,
                LastName = userBO.LastName,
                UserName = userBO.UserName,
                HomePhoneNumber = userBO.HomePhoneNumber,
                WorkPhoneNumber = userBO.WorkPhoneNumber,
                WorkEmail = userBO.WorkEmail,
                Password = userBO.Password,
                WorkTitle = userBO.WorkTitle

            };
        }

        public UserBO Convert(User user)
        {
            if (user == null)
            {
                return null;
            }
            return new UserBO()
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                UserName = user.UserName,
                HomePhoneNumber = user.HomePhoneNumber,
                WorkPhoneNumber = user.WorkPhoneNumber,
                WorkEmail = user.WorkEmail,
                Password = user.Password,
                WorkTitle = user.WorkTitle

            };
        }
    }
}
