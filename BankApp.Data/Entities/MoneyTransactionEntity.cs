using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApp.Data.Entities
{
    public class MoneyTransactionEntity : BaseEntity
    {
        public int SenderUserId { get; set; }          
        public int? ReceiverUserId { get; set; }      
        public decimal Amount { get; set; }            
        public string TransactionType { get; set; }    
        public DateTime Timestamp { get; set; }        
        public string? Description { get; set; }        

        // Navigation properties
        public UserEntity SenderUser { get; set; }
        public UserEntity ReceiverUser { get; set; }

    } // end of class MoneyTransactionEntity
}
