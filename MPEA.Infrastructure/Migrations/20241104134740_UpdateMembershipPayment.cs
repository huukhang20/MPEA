using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MPEA.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UpdateMembershipPayment : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "MembershipId",
                table: "Payment",
                type: "uuid",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Payment_MembershipId",
                table: "Payment",
                column: "MembershipId");

            migrationBuilder.AddForeignKey(
                name: "FK_Payment_Membership_MembershipId",
                table: "Payment",
                column: "MembershipId",
                principalTable: "Membership",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Payment_Membership_MembershipId",
                table: "Payment");

            migrationBuilder.DropIndex(
                name: "IX_Payment_MembershipId",
                table: "Payment");

            migrationBuilder.DropColumn(
                name: "MembershipId",
                table: "Payment");
        }
    }
}
