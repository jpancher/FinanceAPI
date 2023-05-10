using financeAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Oracle.ManagedDataAccess.Client;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace financeAPI.Data
{
    public class DataContext:DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
            
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (OracleConfiguration.TnsAdmin != @"c:\Oracle\Wallet") {
                // Set TnsAdmin value to directory location of tnsnames.ora and sqlnet.ora files           
                OracleConfiguration.TnsAdmin = @"c:\Oracle\Wallet";

                //if (OracleConfiguration.WalletLocation == null)
                // Set WalletLocation value to directory location of the ADB wallet (i.e. cwallet.sso)
                OracleConfiguration.WalletLocation = @"c:\Oracle\Wallet";
            }
            base.OnConfiguring(optionsBuilder);             
        }

        public DbSet<TransactionType> TransactionType { get; set; }
        public DbSet<CostCenter> CostCenter { get; set; }
        public DbSet<BankAccount> BankAccount { get; set; }
        public DbSet<ChartOfAccounts> ChartOfAccounts { get; set; }
        public DbSet<Supplier> Supplier { get; set; }
        public DbSet<Models.Transaction> Transaction{ get; set; }

    }
}
