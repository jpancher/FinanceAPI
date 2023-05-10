Configuração do EF Core e Autonomous Database

Packages:
	Microsoft.EntityFrameworkCore	(7.05)
	Microsoft.EntityFrameworkCore.Design	(7.05)
	Microsoft.EntityFrameworkCore.Tools	(7.05)
	Oracle.EntityFrameworkCore	(7.21.9)
	Oracle.ManagedDataAccess	(3.21.100)

Autonomous DB
	Database Connection --> Download Wallet (zip file) --> Unzip the content into a directory (ex.: c:\oracle\wallet)

In the class heritaged from DBContext, override OnConfiguring:
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Set TnsAdmin value to directory location of tnsnames.ora and sqlnet.ora files           
            OracleConfiguration.TnsAdmin = @"c:\Oracle\Wallet";
            // Set WalletLocation value to directory location of the ADB wallet (i.e. cwallet.sso)
            OracleConfiguration.WalletLocation = @"c:\Oracle\Wallet";

            base.OnConfiguring(optionsBuilder);            
            optionsBuilder.UseOracle(@"User Id = admin; Password = <password>; Data Source = sbt_high");
        }


--> https://stackoverflow.com/questions/62374283/connecting-oracle-autonomous-database-to-net-entity-framework