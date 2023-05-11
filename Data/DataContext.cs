using financeAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Oracle.ManagedDataAccess.Client;
using System;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace financeAPI.Data
{
    public class DataContext:DbContext
    {
        private readonly IConfiguration _config;
        private readonly DbContextOptions<DataContext> _options;

        public DataContext(DbContextOptions<DataContext> options, IConfiguration config) : base(options)
        {
            _config = config;
            _options = options;
            
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

            optionsBuilder.EnableSensitiveDataLogging();

            var option = optionsBuilder.UseOracle(_config["sbtdb:ConnectionString"]);                       

            base.OnConfiguring(option);            

        }

        public DbSet<TransactionType> TransactionType { get; set; }
        public DbSet<CostCenter> CostCenter { get; set; }
        public DbSet<BankAccount> BankAccount { get; set; }
        public DbSet<ChartOfAccounts> ChartOfAccounts { get; set; }
        public DbSet<Supplier> Supplier { get; set; }
        public DbSet<Models.Transaction> Transaction{ get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CostCenter>()
                .HasIndex(p => new { p.Name })
                .IsUnique(true);

            modelBuilder.Entity<ChartOfAccounts>()
                .HasIndex(p => new { p.Name })
                .IsUnique(true);

            modelBuilder.Entity<BankAccount>()
                .HasIndex(p => new { p.Name })
                .IsUnique(true);

            modelBuilder.Entity<Supplier>()                            
                .HasIndex(p => new { p.Name })
                .IsUnique(true);

            modelBuilder.Entity<Supplier>()
                .HasIndex(p => new { p.Document })
                .IsUnique(true);

        }
    }
}
