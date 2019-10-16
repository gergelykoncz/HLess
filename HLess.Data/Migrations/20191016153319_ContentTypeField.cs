using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HLess.Data.Migrations
{
    public partial class ContentTypeField : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ContentTypes_AspNetUsers_OwnerId",
                table: "ContentTypes");

            migrationBuilder.AlterColumn<Guid>(
                name: "OwnerId",
                table: "ContentTypes",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "ContentField",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Deleted = table.Column<bool>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    CreatedByUserId = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(maxLength: 128, nullable: false),
                    Slug = table.Column<string>(maxLength: 128, nullable: false),
                    FieldType = table.Column<int>(nullable: false),
                    ContentTypeId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContentField", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ContentField_ContentTypes_ContentTypeId",
                        column: x => x.ContentTypeId,
                        principalTable: "ContentTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ContentField_AspNetUsers_CreatedByUserId",
                        column: x => x.CreatedByUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ContentField_ContentTypeId",
                table: "ContentField",
                column: "ContentTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_ContentField_CreatedByUserId",
                table: "ContentField",
                column: "CreatedByUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_ContentTypes_AspNetUsers_OwnerId",
                table: "ContentTypes",
                column: "OwnerId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ContentTypes_AspNetUsers_OwnerId",
                table: "ContentTypes");

            migrationBuilder.DropTable(
                name: "ContentField");

            migrationBuilder.AlterColumn<Guid>(
                name: "OwnerId",
                table: "ContentTypes",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid));

            migrationBuilder.AddForeignKey(
                name: "FK_ContentTypes_AspNetUsers_OwnerId",
                table: "ContentTypes",
                column: "OwnerId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
