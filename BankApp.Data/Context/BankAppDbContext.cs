using BankApp.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApp.Data.Context
{
    public class BankAppDbContext : DbContext
    {
        DbSet<AccountEntity> Accounts { get; set; }
        DbSet<UserEntity> Users { get; set; }
        DbSet<MoneyTransactionEntity> MoneyTransactions { get; set; }
        DbSet<UserActivity> UserActivities { get; set; }
        DbSet<UserTwoFactorEntity> UserTwoFactors { get; set; }
        DbSet<BillEntity> Bills { get; set; }

        public BankAppDbContext(DbContextOptions<BankAppDbContext> options) : base(options)
        {

        }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(BankAppDbContext).Assembly); // Automatically apply all configurations from the current assembly
            
            modelBuilder.Entity<SettingEntity>().HasData(new SettingEntity
            {
                Id = 1,
                MaintenanceMode = false,

            });

            base.OnModelCreating(modelBuilder);
            
        }
  
    
    }// end of class BankAppDbContext
}
