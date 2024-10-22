using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MPEA.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UpdateUserTable221024 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Address_user_UserId",
                table: "Address");

            migrationBuilder.DropForeignKey(
                name: "FK_Chat_user_ReceiverId",
                table: "Chat");

            migrationBuilder.DropForeignKey(
                name: "FK_Chat_user_SenderId",
                table: "Chat");

            migrationBuilder.DropForeignKey(
                name: "FK_Exchange_user_OffererId",
                table: "Exchange");

            migrationBuilder.DropForeignKey(
                name: "FK_Exchange_user_ProviderId",
                table: "Exchange");

            migrationBuilder.DropForeignKey(
                name: "FK_ExchangePart_user_ExchangerId",
                table: "ExchangePart");

            migrationBuilder.DropForeignKey(
                name: "FK_Feedback_user_UserId",
                table: "Feedback");

            migrationBuilder.DropForeignKey(
                name: "FK_Notification_user_UserId",
                table: "Notification");

            migrationBuilder.DropForeignKey(
                name: "FK_Report_user_UserId",
                table: "Report");

            migrationBuilder.DropForeignKey(
                name: "FK_SparePart_user_UserId",
                table: "SparePart");

            migrationBuilder.DropForeignKey(
                name: "FK_Wishlist_user_UserId",
                table: "Wishlist");

            migrationBuilder.DropPrimaryKey(
                name: "PK_user",
                table: "user");

            migrationBuilder.DropIndex(
                name: "IX_user_Email",
                table: "user");

            migrationBuilder.RenameTable(
                name: "user",
                newName: "User");

            migrationBuilder.AddPrimaryKey(
                name: "PK_User",
                table: "User",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_User_Email",
                table: "User",
                column: "Email");

            migrationBuilder.AddForeignKey(
                name: "FK_Address_User_UserId",
                table: "Address",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Chat_User_ReceiverId",
                table: "Chat",
                column: "ReceiverId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Chat_User_SenderId",
                table: "Chat",
                column: "SenderId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Exchange_User_OffererId",
                table: "Exchange",
                column: "OffererId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Exchange_User_ProviderId",
                table: "Exchange",
                column: "ProviderId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ExchangePart_User_ExchangerId",
                table: "ExchangePart",
                column: "ExchangerId",
                principalTable: "User",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Feedback_User_UserId",
                table: "Feedback",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Notification_User_UserId",
                table: "Notification",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Report_User_UserId",
                table: "Report",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_SparePart_User_UserId",
                table: "SparePart",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Wishlist_User_UserId",
                table: "Wishlist",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Address_User_UserId",
                table: "Address");

            migrationBuilder.DropForeignKey(
                name: "FK_Chat_User_ReceiverId",
                table: "Chat");

            migrationBuilder.DropForeignKey(
                name: "FK_Chat_User_SenderId",
                table: "Chat");

            migrationBuilder.DropForeignKey(
                name: "FK_Exchange_User_OffererId",
                table: "Exchange");

            migrationBuilder.DropForeignKey(
                name: "FK_Exchange_User_ProviderId",
                table: "Exchange");

            migrationBuilder.DropForeignKey(
                name: "FK_ExchangePart_User_ExchangerId",
                table: "ExchangePart");

            migrationBuilder.DropForeignKey(
                name: "FK_Feedback_User_UserId",
                table: "Feedback");

            migrationBuilder.DropForeignKey(
                name: "FK_Notification_User_UserId",
                table: "Notification");

            migrationBuilder.DropForeignKey(
                name: "FK_Report_User_UserId",
                table: "Report");

            migrationBuilder.DropForeignKey(
                name: "FK_SparePart_User_UserId",
                table: "SparePart");

            migrationBuilder.DropForeignKey(
                name: "FK_Wishlist_User_UserId",
                table: "Wishlist");

            migrationBuilder.DropPrimaryKey(
                name: "PK_User",
                table: "User");

            migrationBuilder.DropIndex(
                name: "IX_User_Email",
                table: "User");

            migrationBuilder.RenameTable(
                name: "User",
                newName: "user");

            migrationBuilder.AddPrimaryKey(
                name: "PK_user",
                table: "user",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_user_Email",
                table: "user",
                column: "Email",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Address_user_UserId",
                table: "Address",
                column: "UserId",
                principalTable: "user",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Chat_user_ReceiverId",
                table: "Chat",
                column: "ReceiverId",
                principalTable: "user",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Chat_user_SenderId",
                table: "Chat",
                column: "SenderId",
                principalTable: "user",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Exchange_user_OffererId",
                table: "Exchange",
                column: "OffererId",
                principalTable: "user",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Exchange_user_ProviderId",
                table: "Exchange",
                column: "ProviderId",
                principalTable: "user",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ExchangePart_user_ExchangerId",
                table: "ExchangePart",
                column: "ExchangerId",
                principalTable: "user",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Feedback_user_UserId",
                table: "Feedback",
                column: "UserId",
                principalTable: "user",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Notification_user_UserId",
                table: "Notification",
                column: "UserId",
                principalTable: "user",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Report_user_UserId",
                table: "Report",
                column: "UserId",
                principalTable: "user",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_SparePart_user_UserId",
                table: "SparePart",
                column: "UserId",
                principalTable: "user",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Wishlist_user_UserId",
                table: "Wishlist",
                column: "UserId",
                principalTable: "user",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
