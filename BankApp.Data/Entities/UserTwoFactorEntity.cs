using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApp.Data.Entities
{
    public class UserTwoFactorEntity : BaseEntity
    {
        public int UserId { get; set; }

        public string OtpCode { get; set; }          
        public DateTime ExpireAt { get; set; }     
        public bool IsUsedCode { get; set; }           //otp code  was it used ?
        public string Provider { get; set; }       // "SMS", "Email", "Authenticator" like

        public string? TwoFactorSecretKey { get; set; }

        //Navigation Property
        public UserEntity User { get; set; }
    } // end of class UserTwoFactorEntity
}
