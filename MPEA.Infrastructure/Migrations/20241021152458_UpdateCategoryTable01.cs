using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MPEA.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UpdateCategoryTable01 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CategoryId",
                table: "spare-part",
                type: "text",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_spare-part_CategoryId",
                table: "spare-part",
                column: "CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_spare-part_Category_CategoryId",
                table: "spare-part",
                column: "CategoryId",
                principalTable: "Category",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_spare-part_Category_CategoryId",
                table: "spare-part");

            migrationBuilder.DropIndex(
                name: "IX_spare-part_CategoryId",
                table: "spare-part");

            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "spare-part");
        }
    }
}
