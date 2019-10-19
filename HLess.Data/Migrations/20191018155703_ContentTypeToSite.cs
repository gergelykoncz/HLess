using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HLess.Data.Migrations
{
    public partial class ContentTypeToSite : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ContentTypes_Account_OwnerId",
                table: "ContentTypes");

            migrationBuilder.DropIndex(
                name: "IX_ContentTypes_OwnerId",
                table: "ContentTypes");

            migrationBuilder.DropColumn(
                name: "OwnerId",
                table: "ContentTypes");

            migrationBuilder.AddColumn<Guid>(
                name: "SiteId",
                table: "ContentTypes",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ContentTypes_SiteId",
                table: "ContentTypes",
                column: "SiteId");

            migrationBuilder.AddForeignKey(
                name: "FK_ContentTypes_Site_SiteId",
                table: "ContentTypes",
                column: "SiteId",
                principalTable: "Site",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ContentTypes_Site_SiteId",
                table: "ContentTypes");

            migrationBuilder.DropIndex(
                name: "IX_ContentTypes_SiteId",
                table: "ContentTypes");

            migrationBuilder.DropColumn(
                name: "SiteId",
                table: "ContentTypes");

            migrationBuilder.AddColumn<Guid>(
                name: "OwnerId",
                table: "ContentTypes",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_ContentTypes_OwnerId",
                table: "ContentTypes",
                column: "OwnerId");

            migrationBuilder.AddForeignKey(
                name: "FK_ContentTypes_Account_OwnerId",
                table: "ContentTypes",
                column: "OwnerId",
                principalTable: "Account",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
