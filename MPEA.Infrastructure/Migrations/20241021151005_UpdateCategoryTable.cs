using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MPEA.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UpdateCategoryTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ExchangePart_SparePart_SparePartId",
                table: "ExchangePart");

            migrationBuilder.DropForeignKey(
                name: "FK_SparePart_Warranty_WarrantyId",
                table: "SparePart");

            migrationBuilder.DropForeignKey(
                name: "FK_SparePart_user_UserId",
                table: "SparePart");

            migrationBuilder.DropForeignKey(
                name: "FK_Wishlist_SparePart_SparePartId",
                table: "Wishlist");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SparePart",
                table: "SparePart");

            migrationBuilder.DropColumn(
                name: "TechnicalSpecifications",
                table: "SparePart");

            migrationBuilder.RenameTable(
                name: "SparePart",
                newName: "spare-part");

            migrationBuilder.RenameIndex(
                name: "IX_SparePart_WarrantyId",
                table: "spare-part",
                newName: "IX_spare-part_WarrantyId");

            migrationBuilder.RenameIndex(
                name: "IX_SparePart_UserId",
                table: "spare-part",
                newName: "IX_spare-part_UserId");

            migrationBuilder.AlterColumn<string>(
                name: "Status",
                table: "spare-part",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "spare-part",
                type: "character varying(50)",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(50)",
                oldMaxLength: 50);

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "spare-part",
                type: "character varying(150)",
                maxLength: 150,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Image",
                table: "spare-part",
                type: "text",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_spare-part",
                table: "spare-part",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false, defaultValue: "gen_random_uuid()"),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Level = table.Column<string>(type: "text", nullable: true),
                    Status = table.Column<string>(type: "text", nullable: true),
                    ParentCateId = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Category_Category_ParentCateId",
                        column: x => x.ParentCateId,
                        principalTable: "Category",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Category_ParentCateId",
                table: "Category",
                column: "ParentCateId");

            migrationBuilder.AddForeignKey(
                name: "FK_ExchangePart_spare-part_SparePartId",
                table: "ExchangePart",
                column: "SparePartId",
                principalTable: "spare-part",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_spare-part_Warranty_WarrantyId",
                table: "spare-part",
                column: "WarrantyId",
                principalTable: "Warranty",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_spare-part_user_UserId",
                table: "spare-part",
                column: "UserId",
                principalTable: "user",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Wishlist_spare-part_SparePartId",
                table: "Wishlist",
                column: "SparePartId",
                principalTable: "spare-part",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ExchangePart_spare-part_SparePartId",
                table: "ExchangePart");

            migrationBuilder.DropForeignKey(
                name: "FK_spare-part_Warranty_WarrantyId",
                table: "spare-part");

            migrationBuilder.DropForeignKey(
                name: "FK_spare-part_user_UserId",
                table: "spare-part");

            migrationBuilder.DropForeignKey(
                name: "FK_Wishlist_spare-part_SparePartId",
                table: "Wishlist");

            migrationBuilder.DropTable(
                name: "Category");

            migrationBuilder.DropPrimaryKey(
                name: "PK_spare-part",
                table: "spare-part");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "spare-part");

            migrationBuilder.DropColumn(
                name: "Image",
                table: "spare-part");

            migrationBuilder.RenameTable(
                name: "spare-part",
                newName: "SparePart");

            migrationBuilder.RenameIndex(
                name: "IX_spare-part_WarrantyId",
                table: "SparePart",
                newName: "IX_SparePart_WarrantyId");

            migrationBuilder.RenameIndex(
                name: "IX_spare-part_UserId",
                table: "SparePart",
                newName: "IX_SparePart_UserId");

            migrationBuilder.AlterColumn<string>(
                name: "Status",
                table: "SparePart",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "SparePart",
                type: "character varying(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "character varying(50)",
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TechnicalSpecifications",
                table: "SparePart",
                type: "character varying(150)",
                maxLength: 150,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SparePart",
                table: "SparePart",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ExchangePart_SparePart_SparePartId",
                table: "ExchangePart",
                column: "SparePartId",
                principalTable: "SparePart",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_SparePart_Warranty_WarrantyId",
                table: "SparePart",
                column: "WarrantyId",
                principalTable: "Warranty",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_SparePart_user_UserId",
                table: "SparePart",
                column: "UserId",
                principalTable: "user",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Wishlist_SparePart_SparePartId",
                table: "Wishlist",
                column: "SparePartId",
                principalTable: "SparePart",
                principalColumn: "Id");
        }
    }
}
