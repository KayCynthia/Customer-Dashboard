using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FinanceBackend.Migrations
{
    /// <inheritdoc />
    public partial class UpdateSavingsLogic : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "date",
                table: "Transaction");

            migrationBuilder.AddColumn<string>(
                name: "Month",
                table: "Transaction",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Month",
                table: "Transaction");

            migrationBuilder.AddColumn<DateOnly>(
                name: "date",
                table: "Transaction",
                type: "date",
                nullable: false,
                defaultValue: new DateOnly(1, 1, 1));
        }
    }
}
