using financeAPI.Repo;
using financeAPI.Data;
using financeAPI.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections;
using System.Text.Json;

#region TODO: APAGAR : Acesso Direto ao Banco
////Enter directory where you unzipped your cloud credentials
//OracleConfiguration.TnsAdmin = @"c:\Oracle\Wallet";
//OracleConfiguration.WalletLocation = OracleConfiguration.TnsAdmin;

//using (OracleConnection con = new OracleConnection(conString))
//{
//    using (OracleCommand cmd = con.CreateCommand())
//    {
//        try
//        {
//            con.Open();
//            Console.WriteLine("Successfully connected to Oracle Autonomous Database");
//            Console.WriteLine();

//            cmd.CommandText = "SELECT * FROM ADMIN.\"CostCenter\"";
//            OracleDataReader reader = cmd.ExecuteReader();
//            while (reader.Read())
//                Console.WriteLine(reader.GetString(0) + " " + reader.GetString(1));
//            Console.WriteLine("sucesso!!!!");
//        }
//        catch (Exception ex)
//        {
//            Console.WriteLine(ex.Message);
//        }
//    }
//}
#endregion TODO: APAGAR : Acesso Direto ao Banco

var builder = WebApplication.CreateBuilder(args);

//Autonomous Database (Oracle)
//string conString = "User Id=<userName>;Password=<password>;Data Source=<dbName_high>;Connection Timeout=30;";
string conString = builder.Configuration["sbtdb:ConnectionString"];
var option = new DbContextOptionsBuilder<DataContext>().UseOracle(conString).Options;
using var db = new DataContext(option);
//db.Database.EnsureCreated();
SeedData.SeedAll(db);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<DataContext>();

var app = builder.Build();

app.UseSwagger();

var costCenterRepo = new CostCenterRepo(db);
var chartOfAccountsRepo = new ChartOfAccountsRepo(db);
var bankAccountRepo = new BankAccountRepo(db);
var supplierRepo = new SupplierRepo(db);

app.MapGet("/CostCenter", () => costCenterRepo.GetAll());
app.MapGet("/CostCenter/{id}", (int id) => costCenterRepo.Get(id));
app.MapDelete("/CostCenter/{id}", (int id) => costCenterRepo.Delete(id));
app.MapPut("/CostCenter/{id}", (int id, CostCenter updatedCostCenter) => costCenterRepo.Update(id, updatedCostCenter));
app.MapPost("/CostCenter/{id}", (CostCenter costCenter) => costCenterRepo.Create(costCenter));

app.MapGet("/ChartOfAccounts", () => chartOfAccountsRepo.GetAll());
app.MapGet("/ChartOfAccounts/{id}", (int id) => chartOfAccountsRepo.Get(id));
app.MapDelete("/ChartOfAccounts/{id}", (int id) => chartOfAccountsRepo.Delete(id));
app.MapPut("/ChartOfAccounts/{id}", (int id, ChartOfAccounts updatedChartOfAccounts) => chartOfAccountsRepo.Update(id, updatedChartOfAccounts));
app.MapPost("/ChartOfAccounts/{id}", (ChartOfAccounts chartOfAccounts) => chartOfAccountsRepo.Create(chartOfAccounts));

app.MapGet("/BankAccount", () => bankAccountRepo.GetAll());
app.MapGet("/BankAccount/{id}", (int id) => bankAccountRepo.Get(id));
app.MapDelete("/BankAccount/{id}", (int id) => bankAccountRepo.Delete(id));
app.MapPut("/BankAccount/{id}", (int id, BankAccount updatedBankAccount) => bankAccountRepo.Update(id, updatedBankAccount));
app.MapPost("/BankAccount/{id}", (BankAccount bankAccount) => bankAccountRepo.Create(bankAccount));

app.MapGet("/Supplier", () => supplierRepo.GetAll());
app.MapGet("/Supplier/{id}", (int id) => supplierRepo.Get(id));
app.MapDelete("/Supplier/{id}", (int id) => supplierRepo.Delete(id));
app.MapPut("/Supplier/{id}", (int id, Supplier updatedSupplier) => supplierRepo.Update(id, updatedSupplier));
app.MapPost("/Supplier/{id}", (Supplier supplier) => supplierRepo.Create(supplier));

app.UseSwaggerUI();

app.Run();


//Refer�ncias
//app.MapGet("/GetAllCostCenter", (DataContext db) => {
//    //return db.CostCenter.ToArrayAsync();
//    //return db.CostCenter.ToArray();
//    return db.CostCenter.ToList();
//});
