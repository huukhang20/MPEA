using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MPEA.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class DeleteWarrantyTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ExchangePart_spare-part_SparePartId",
                table: "ExchangePart");

            migrationBuilder.DropForeignKey(
                name: "FK_spare-part_Category_CategoryId",
                table: "spare-part");

            migrationBuilder.DropForeignKey(
                name: "FK_spare-part_Warranty_WarrantyId",
                table: "spare-part");

            migrationBuilder.DropForeignKey(
                name: "FK_spare-part_user_UserId",
                table: "spare-part");

            migrationBuilder.DropForeignKey(
                name: "FK_Wishlist_spare-part_SparePartId",
                table: "Wishlist");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Warranty",
                table: "Warranty");

            migrationBuilder.DropPrimaryKey(
                name: "PK_spare-part",
                table: "spare-part");

            migrationBuilder.DropIndex(
                name: "IX_spare-part_WarrantyId",
                table: "spare-part");

            migrationBuilder.RenameTable(
                name: "Warranty",
                newName: "Warrantys");

            migrationBuilder.RenameTable(
                name: "spare-part",
                newName: "SparePart");

            migrationBuilder.RenameColumn(
                name: "WarrantyId",
                table: "SparePart",
                newName: "WarrntyImage");

            migrationBuilder.RenameIndex(
                name: "IX_spare-part_UserId",
                table: "SparePart",
                newName: "IX_SparePart_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_spare-part_CategoryId",
                table: "SparePart",
                newName: "IX_SparePart_CategoryId");

            migrationBuilder.AlterColumn<string>(
                name: "Id",
                table: "Warrantys",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text",
                oldDefaultValueSql: "gen_random_uuid()");

            migrationBuilder.AddColumn<string>(
                name: "SparePartId",
                table: "Warrantys",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "IsWarranty",
                table: "SparePart",
                type: "boolean",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Warrantys",
                table: "Warrantys",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SparePart",
                table: "SparePart",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Warrantys_SparePartId",
                table: "Warrantys",
                column: "SparePartId");

            migrationBuilder.AddForeignKey(
                name: "FK_ExchangePart_SparePart_SparePartId",
                table: "ExchangePart",
                column: "SparePartId",
                principalTable: "SparePart",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_SparePart_Category_CategoryId",
                table: "SparePart",
                column: "CategoryId",
                principalTable: "Category",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_SparePart_user_UserId",
                table: "SparePart",
                column: "UserId",
                principalTable: "user",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Warrantys_SparePart_SparePartId",
                table: "Warrantys",
                column: "SparePartId",
                principalTable: "SparePart",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Wishlist_SparePart_SparePartId",
                table: "Wishlist",
                column: "SparePartId",
                principalTable: "SparePart",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ExchangePart_SparePart_SparePartId",
                table: "ExchangePart");

            migrationBuilder.DropForeignKey(
                name: "FK_SparePart_Category_CategoryId",
                table: "SparePart");

            migrationBuilder.DropForeignKey(
                name: "FK_SparePart_user_UserId",
                table: "SparePart");

            migrationBuilder.DropForeignKey(
                name: "FK_Warrantys_SparePart_SparePartId",
                table: "Warrantys");

            migrationBuilder.DropForeignKey(
                name: "FK_Wishlist_SparePart_SparePartId",
                table: "Wishlist");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Warrantys",
                table: "Warrantys");

            migrationBuilder.DropIndex(
                name: "IX_Warrantys_SparePartId",
                table: "Warrantys");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SparePart",
                table: "SparePart");

            migrationBuilder.DropColumn(
                name: "SparePartId",
                table: "Warrantys");

            migrationBuilder.DropColumn(
                name: "IsWarranty",
                table: "SparePart");

            migrationBuilder.RenameTable(
                name: "Warrantys",
                newName: "Warranty");

            migrationBuilder.RenameTable(
                name: "SparePart",
                newName: "spare-part");

            migrationBuilder.RenameColumn(
                name: "WarrntyImage",
                table: "spare-part",
                newName: "WarrantyId");

            migrationBuilder.RenameIndex(
                name: "IX_SparePart_UserId",
                table: "spare-part",
                newName: "IX_spare-part_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_SparePart_CategoryId",
                table: "spare-part",
                newName: "IX_spare-part_CategoryId");

            migrationBuilder.AlterColumn<string>(
                name: "Id",
                table: "Warranty",
                type: "text",
                nullable: false,
                defaultValueSql: "gen_random_uuid()",
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Warranty",
                table: "Warranty",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_spare-part",
                table: "spare-part",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_spare-part_WarrantyId",
                table: "spare-part",
                column: "WarrantyId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ExchangePart_spare-part_SparePartId",
                table: "ExchangePart",
                column: "SparePartId",
                principalTable: "spare-part",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_spare-part_Category_CategoryId",
                table: "spare-part",
                column: "CategoryId",
                principalTable: "Category",
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
    }
}
