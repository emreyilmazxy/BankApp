using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApp.Data.Entities
{
    public class UserEntity : BaseEntity
    {
        public string Name { get; set; }
        public string LastName { get; set; }

        public string PhoneNumber { get; set; }
        public string Email { get; set; }

        public string Password { get; set; }
        public bool IsTwoFactorEnable { get; set; }

        //Navigation Properties

        public UserTwoFactorEntity TwoFactor { get; set; }
        public ICollection<UserActivity> Activities { get; set; }
    } // end of class UserEntity
}
