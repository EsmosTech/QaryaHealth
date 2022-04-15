using Microsoft.EntityFrameworkCore.Migrations;

namespace QaryaHealth.Infrastructure.Migrations
{
    public partial class makelabimagenullable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_lab_upload-image_image-id",
                table: "lab");

            migrationBuilder.AlterColumn<int>(
                name: "image-id",
                table: "lab",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_lab_upload-image_image-id",
                table: "lab",
                column: "image-id",
                principalTable: "upload-image",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_lab_upload-image_image-id",
                table: "lab");

            migrationBuilder.AlterColumn<int>(
                name: "image-id",
                table: "lab",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_lab_upload-image_image-id",
                table: "lab",
                column: "image-id",
                principalTable: "upload-image",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
