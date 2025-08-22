using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApp.Data.Entities
{
    public class UserActivity : BaseEntity
    {
        public int UserId { get; set; }          
        public string Action { get; set; }       
        public string IpAddress { get; set; }    
        public string? Device { get; set; }      
        public DateTime Timestamp { get; set; } 

        //Navigation Property
        public UserEntity User { get; set; }
    }// end of class UserLog
}
