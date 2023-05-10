using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace financeAPI.Migrations
{
    /// <inheritdoc />
    public partial class FewChangesAndFlatChartOfAccount : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AccountId",
                table: "Transaction");

            migrationBuilder.DropColumn(
                name: "Type",
                table: "Transaction");

            migrationBuilder.DropColumn(
                name: "ParentAccountId",
                table: "ChartOfAccounts");

            migrationBuilder.AlterColumn<Guid>(
                name: "SupplierGuid",
                table: "Transaction",
                type: "RAW(16)",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "RAW(16)");

            migrationBuilder.AlterColumn<int>(
                name: "CostCenterId",
                table: "Transaction",
                type: "NUMBER(10)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "NUMBER(10)");

            migrationBuilder.AlterColumn<int>(
                name: "BankAccountId",
                table: "Transaction",
                type: "NUMBER(10)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "NUMBER(10)");

            migrationBuilder.AddColumn<int>(
                name: "ChartOfAccountsId",
                table: "Transaction",
                type: "NUMBER(10)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TransactionTypeId",
                table: "Transaction",
                type: "NUMBER(10)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "TransactionType",
                columns: table => new
                {
                    Id = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    Name = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TransactionType", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Transaction_BankAccountId",
                table: "Transaction",
                column: "BankAccountId");

            migrationBuilder.CreateIndex(
                name: "IX_Transaction_ChartOfAccountsId",
                table: "Transaction",
                column: "ChartOfAccountsId");

            migrationBuilder.CreateIndex(
                name: "IX_Transaction_CostCenterId",
                table: "Transaction",
                column: "CostCenterId");

            migrationBuilder.CreateIndex(
                name: "IX_Transaction_SupplierGuid",
                table: "Transaction",
                column: "SupplierGuid");

            migrationBuilder.CreateIndex(
                name: "IX_Transaction_TransactionTypeId",
                table: "Transaction",
                column: "TransactionTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Transaction_BankAccount_BankAccountId",
                table: "Transaction",
                column: "BankAccountId",
                principalTable: "BankAccount",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Transaction_ChartOfAccounts_ChartOfAccountsId",
                table: "Transaction",
                column: "ChartOfAccountsId",
                principalTable: "ChartOfAccounts",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Transaction_CostCenter_CostCenterId",
                table: "Transaction",
                column: "CostCenterId",
                principalTable: "CostCenter",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Transaction_Supplier_SupplierGuid",
                table: "Transaction",
                column: "SupplierGuid",
                principalTable: "Supplier",
                principalColumn: "Guid");

            migrationBuilder.AddForeignKey(
                name: "FK_Transaction_TransactionType_TransactionTypeId",
                table: "Transaction",
                column: "TransactionTypeId",
                principalTable: "TransactionType",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Transaction_BankAccount_BankAccountId",
                table: "Transaction");

            migrationBuilder.DropForeignKey(
                name: "FK_Transaction_ChartOfAccounts_ChartOfAccountsId",
                table: "Transaction");

            migrationBuilder.DropForeignKey(
                name: "FK_Transaction_CostCenter_CostCenterId",
                table: "Transaction");

            migrationBuilder.DropForeignKey(
                name: "FK_Transaction_Supplier_SupplierGuid",
                table: "Transaction");

            migrationBuilder.DropForeignKey(
                name: "FK_Transaction_TransactionType_TransactionTypeId",
                table: "Transaction");

            migrationBuilder.DropTable(
                name: "TransactionType");

            migrationBuilder.DropIndex(
                name: "IX_Transaction_BankAccountId",
                table: "Transaction");

            migrationBuilder.DropIndex(
                name: "IX_Transaction_ChartOfAccountsId",
                table: "Transaction");

            migrationBuilder.DropIndex(
                name: "IX_Transaction_CostCenterId",
                table: "Transaction");

            migrationBuilder.DropIndex(
                name: "IX_Transaction_SupplierGuid",
                table: "Transaction");

            migrationBuilder.DropIndex(
                name: "IX_Transaction_TransactionTypeId",
                table: "Transaction");

            migrationBuilder.DropColumn(
                name: "ChartOfAccountsId",
                table: "Transaction");

            migrationBuilder.DropColumn(
                name: "TransactionTypeId",
                table: "Transaction");

            migrationBuilder.AlterColumn<Guid>(
                name: "SupplierGuid",
                table: "Transaction",
                type: "RAW(16)",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "RAW(16)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "CostCenterId",
                table: "Transaction",
                type: "NUMBER(10)",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "NUMBER(10)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "BankAccountId",
                table: "Transaction",
                type: "NUMBER(10)",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "NUMBER(10)",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "AccountId",
                table: "Transaction",
                type: "NUMBER(10)",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Type",
                table: "Transaction",
                type: "NVARCHAR2(2000)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ParentAccountId",
                table: "ChartOfAccounts",
                type: "NUMBER(10)",
                nullable: false,
                defaultValue: 0);
        }
    }
}
