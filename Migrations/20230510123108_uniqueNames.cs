using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace financeAPI.Migrations
{
    /// <inheritdoc />
    public partial class uniqueNames : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Transaction_CostCenter_CostCenterId",
                table: "Transaction");

            migrationBuilder.RenameColumn(
                name: "CostCenterId",
                table: "Transaction",
                newName: "CostCenterEntityId");

            migrationBuilder.RenameIndex(
                name: "IX_Transaction_CostCenterId",
                table: "Transaction",
                newName: "IX_Transaction_CostCenterEntityId");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Supplier",
                type: "NVARCHAR2(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "NVARCHAR2(2000)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Document",
                table: "Supplier",
                type: "NVARCHAR2(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "NVARCHAR2(2000)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "CostCenter",
                type: "NVARCHAR2(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "NVARCHAR2(2000)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "ChartOfAccounts",
                type: "NVARCHAR2(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "NVARCHAR2(2000)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "BankAccount",
                type: "NVARCHAR2(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "NVARCHAR2(2000)",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Supplier_Document",
                table: "Supplier",
                column: "Document",
                unique: true,
                filter: "\"Document\" IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Supplier_Name",
                table: "Supplier",
                column: "Name",
                unique: true,
                filter: "\"Name\" IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_CostCenter_Name",
                table: "CostCenter",
                column: "Name",
                unique: true,
                filter: "\"Name\" IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_ChartOfAccounts_Name",
                table: "ChartOfAccounts",
                column: "Name",
                unique: true,
                filter: "\"Name\" IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_BankAccount_Name",
                table: "BankAccount",
                column: "Name",
                unique: true,
                filter: "\"Name\" IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Transaction_CostCenter_CostCenterEntityId",
                table: "Transaction",
                column: "CostCenterEntityId",
                principalTable: "CostCenter",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Transaction_CostCenter_CostCenterEntityId",
                table: "Transaction");

            migrationBuilder.DropIndex(
                name: "IX_Supplier_Document",
                table: "Supplier");

            migrationBuilder.DropIndex(
                name: "IX_Supplier_Name",
                table: "Supplier");

            migrationBuilder.DropIndex(
                name: "IX_CostCenter_Name",
                table: "CostCenter");

            migrationBuilder.DropIndex(
                name: "IX_ChartOfAccounts_Name",
                table: "ChartOfAccounts");

            migrationBuilder.DropIndex(
                name: "IX_BankAccount_Name",
                table: "BankAccount");

            migrationBuilder.RenameColumn(
                name: "CostCenterEntityId",
                table: "Transaction",
                newName: "CostCenterId");

            migrationBuilder.RenameIndex(
                name: "IX_Transaction_CostCenterEntityId",
                table: "Transaction",
                newName: "IX_Transaction_CostCenterId");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Supplier",
                type: "NVARCHAR2(2000)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "NVARCHAR2(450)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Document",
                table: "Supplier",
                type: "NVARCHAR2(2000)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "NVARCHAR2(450)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "CostCenter",
                type: "NVARCHAR2(2000)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "NVARCHAR2(450)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "ChartOfAccounts",
                type: "NVARCHAR2(2000)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "NVARCHAR2(450)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "BankAccount",
                type: "NVARCHAR2(2000)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "NVARCHAR2(450)",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Transaction_CostCenter_CostCenterId",
                table: "Transaction",
                column: "CostCenterId",
                principalTable: "CostCenter",
                principalColumn: "Id");
        }
    }
}
