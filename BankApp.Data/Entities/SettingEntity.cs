using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApp.Data.Entities
{
    public class SettingEntity : BaseEntity
    {
        public int Id { get; set; }

        public bool MaintenanceMode { get; set; }
    }// end of class SettingEntity
}
