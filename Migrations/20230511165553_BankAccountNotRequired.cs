using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace financeAPI.Migrations
{
    /// <inheritdoc />
    public partial class BankAccountNotRequired : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Transaction_BankAccount_BankAccountId",
                table: "Transaction");

            migrationBuilder.AlterColumn<int>(
                name: "BankAccountId",
                table: "Transaction",
                type: "NUMBER(10)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "NUMBER(10)");

            migrationBuilder.AddForeignKey(
                name: "FK_Transaction_BankAccount_BankAccountId",
                table: "Transaction",
                column: "BankAccountId",
                principalTable: "BankAccount",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Transaction_BankAccount_BankAccountId",
                table: "Transaction");

            migrationBuilder.AlterColumn<int>(
                name: "BankAccountId",
                table: "Transaction",
                type: "NUMBER(10)",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "NUMBER(10)",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Transaction_BankAccount_BankAccountId",
                table: "Transaction",
                column: "BankAccountId",
                principalTable: "BankAccount",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
