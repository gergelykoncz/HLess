using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HLess.Data.Migrations
{
    public partial class AddAccount : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ContentTypes_AspNetUsers_OwnerId",
                table: "ContentTypes");

            migrationBuilder.AddColumn<Guid>(
                name: "AccountId",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "Account",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Deleted = table.Column<bool>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    CreatedByUserId = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Account", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Account_AspNetUsers_CreatedByUserId",
                        column: x => x.CreatedByUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_AccountId",
                table: "AspNetUsers",
                column: "AccountId");

            migrationBuilder.CreateIndex(
                name: "IX_Account_CreatedByUserId",
                table: "Account",
                column: "CreatedByUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Account_AccountId",
                table: "AspNetUsers",
                column: "AccountId",
                principalTable: "Account",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ContentTypes_Account_OwnerId",
                table: "ContentTypes",
                column: "OwnerId",
                principalTable: "Account",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Account_AccountId",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_ContentTypes_Account_OwnerId",
                table: "ContentTypes");

            migrationBuilder.DropTable(
                name: "Account");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_AccountId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "AccountId",
                table: "AspNetUsers");

            migrationBuilder.AddForeignKey(
                name: "FK_ContentTypes_AspNetUsers_OwnerId",
                table: "ContentTypes",
                column: "OwnerId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
