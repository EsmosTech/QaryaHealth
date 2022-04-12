using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace QaryaHealth.Infrastructure.Migrations
{
    public partial class addingimagetable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "image",
                table: "lab");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "volunteer",
                newName: "user-id");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "lab",
                newName: "user-id");

            migrationBuilder.RenameColumn(
                name: "EndWorkingHour",
                table: "lab",
                newName: "start-working-hour");

            migrationBuilder.AddColumn<int>(
                name: "image-id",
                table: "lab",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "upload-image",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    image = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    isActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_upload-image", x => x.id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_volunteer_user-id",
                table: "volunteer",
                column: "user-id");

            migrationBuilder.CreateIndex(
                name: "IX_lab_image-id",
                table: "lab",
                column: "image-id");

            migrationBuilder.CreateIndex(
                name: "IX_lab_user-id",
                table: "lab",
                column: "user-id");

            migrationBuilder.AddForeignKey(
                name: "FK_lab_upload-image_image-id",
                table: "lab",
                column: "image-id",
                principalTable: "upload-image",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_lab_user_user-id",
                table: "lab",
                column: "user-id",
                principalTable: "user",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_volunteer_user_user-id",
                table: "volunteer",
                column: "user-id",
                principalTable: "user",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_lab_upload-image_image-id",
                table: "lab");

            migrationBuilder.DropForeignKey(
                name: "FK_lab_user_user-id",
                table: "lab");

            migrationBuilder.DropForeignKey(
                name: "FK_volunteer_user_user-id",
                table: "volunteer");

            migrationBuilder.DropTable(
                name: "upload-image");

            migrationBuilder.DropIndex(
                name: "IX_volunteer_user-id",
                table: "volunteer");

            migrationBuilder.DropIndex(
                name: "IX_lab_image-id",
                table: "lab");

            migrationBuilder.DropIndex(
                name: "IX_lab_user-id",
                table: "lab");

            migrationBuilder.DropColumn(
                name: "image-id",
                table: "lab");

            migrationBuilder.RenameColumn(
                name: "user-id",
                table: "volunteer",
                newName: "UserId");

            migrationBuilder.RenameColumn(
                name: "user-id",
                table: "lab",
                newName: "UserId");

            migrationBuilder.RenameColumn(
                name: "start-working-hour",
                table: "lab",
                newName: "EndWorkingHour");

            migrationBuilder.AddColumn<byte[]>(
                name: "image",
                table: "lab",
                type: "varbinary(max)",
                nullable: true);
        }
    }
}
