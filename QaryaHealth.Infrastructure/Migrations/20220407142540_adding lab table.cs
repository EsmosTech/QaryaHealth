using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace QaryaHealth.Infrastructure.Migrations
{
    public partial class addinglabtable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "blood-type",
                table: "user");

            migrationBuilder.AddColumn<string>(
                name: "address",
                table: "user",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "lab",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    workingdays = table.Column<string>(name: "working-days", type: "nvarchar(max)", nullable: true),
                    endworkinghour = table.Column<DateTime>(name: "end-working-hour", type: "datetime2", nullable: false),
                    EndWorkingHour = table.Column<DateTime>(type: "datetime2", nullable: false),
                    image = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    isActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_lab", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "volunteer",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    bloodtype = table.Column<int>(name: "blood-type", type: "int", nullable: false),
                    birthdate = table.Column<DateTime>(name: "birth-date", type: "datetime2", nullable: false),
                    isActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_volunteer", x => x.id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "lab");

            migrationBuilder.DropTable(
                name: "volunteer");

            migrationBuilder.DropColumn(
                name: "address",
                table: "user");

            migrationBuilder.AddColumn<int>(
                name: "blood-type",
                table: "user",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
