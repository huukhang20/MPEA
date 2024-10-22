using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MPEA.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UpdateSparePartTable221024 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "SparePart",
                type: "timestamp with time zone",
                nullable: true,
                defaultValueSql: "now()");

            migrationBuilder.AddColumn<double>(
                name: "Price",
                table: "SparePart",
                type: "double precision",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "SparePart");

            migrationBuilder.DropColumn(
                name: "Price",
                table: "SparePart");
        }
    }
}
