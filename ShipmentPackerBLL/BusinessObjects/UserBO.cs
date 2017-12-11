using System;
namespace ShipmentPackerBLL.BusinessObjects
{
    public class UserBO
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string UserName { get; set; }

        public string HomePhoneNumber { get; set; }

        public string WorkPhoneNumber { get; set; }

        public string WorkEmail { get; set; }

        public string Password { get; set; }

        public string WorkTitle { get; set; }
    }
}
