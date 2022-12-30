using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.DomainClasses.S00210326.Models
{
    public class AccountsContext:DbContext
    {
        public DbSet<Account> Accounts { get; set; }

        public DbSet<Customer> Customers { get; set; }

        public DbSet<Transactions> Transactions { get; set; }

        public DbSet<AccountType> AccountTypes { get; set; }

        //public DbSet<TransactionType> TransactionTypes { get; set; }
        public AccountsContext()
            : base("name=BankConnection")
        {
        }
    }
}
