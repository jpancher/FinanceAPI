using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace financeAPI.Migrations
{
    /// <inheritdoc />
    public partial class MainEntities : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_CostCenterEF",
                table: "CostCenterEF");

            migrationBuilder.RenameTable(
                name: "CostCenterEF",
                newName: "CostCenter");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CostCenter",
                table: "CostCenter",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "BankAccount",
                columns: table => new
                {
                    Id = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    Name = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    Agency = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    AccountNumber = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    BankNumber = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    BankName = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    Observation = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BankAccount", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ChartOfAccounts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    Name = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    ParentAccountId = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    ShowIncomeStatement = table.Column<bool>(type: "NUMBER(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChartOfAccounts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Supplier",
                columns: table => new
                {
                    Guid = table.Column<Guid>(type: "RAW(16)", nullable: false),
                    Name = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    Document = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    Phone = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    Address = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    PostalCode = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    City = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    County = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    State = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    Country = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Supplier", x => x.Guid);
                });

            migrationBuilder.CreateTable(
                name: "Transaction",
                columns: table => new
                {
                    Guid = table.Column<Guid>(type: "RAW(16)", nullable: false),
                    AccrualDate = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false),
                    DueDate = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false),
                    PaymentDate = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false),
                    Status = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    Value = table.Column<decimal>(type: "DECIMAL(18,4)", precision: 18, scale: 4, nullable: false),
                    PenaltyAndInterestOrDiscount = table.Column<decimal>(type: "DECIMAL(18,4)", precision: 18, scale: 4, nullable: false),
                    Description = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    SupplierGuid = table.Column<Guid>(type: "RAW(16)", nullable: false),
                    AccountId = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    CostCenterId = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    Type = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    BankAccountId = table.Column<int>(type: "NUMBER(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transaction", x => x.Guid);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BankAccount");

            migrationBuilder.DropTable(
                name: "ChartOfAccounts");

            migrationBuilder.DropTable(
                name: "Supplier");

            migrationBuilder.DropTable(
                name: "Transaction");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CostCenter",
                table: "CostCenter");

            migrationBuilder.RenameTable(
                name: "CostCenter",
                newName: "CostCenterEF");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CostCenterEF",
                table: "CostCenterEF",
                column: "Id");
        }
    }
}
