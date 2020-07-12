using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace YatKiralama.Data.Migrations
{
    public partial class testMigrationn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Price",
                table: "Yatlar",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Yatlar",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ImgLocation",
                table: "Yatlar",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ImgLocation2",
                table: "Yatlar",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ImgLocation3",
                table: "Yatlar",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Sifre",
                table: "Users",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Cart",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserID = table.Column<int>(nullable: false),
                    Tarih = table.Column<DateTime>(nullable: false),
                    SaatID = table.Column<int>(nullable: false),
                    YatID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cart", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Kirala",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    YatID = table.Column<int>(nullable: false),
                    UserID = table.Column<int>(nullable: false),
                    Tarih = table.Column<DateTime>(nullable: false),
                    SaatID = table.Column<int>(nullable: false),
                    Onay = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kirala", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Saatler",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Saat = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Saatler", x => x.ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cart");

            migrationBuilder.DropTable(
                name: "Kirala");

            migrationBuilder.DropTable(
                name: "Saatler");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Yatlar");

            migrationBuilder.DropColumn(
                name: "ImgLocation",
                table: "Yatlar");

            migrationBuilder.DropColumn(
                name: "ImgLocation2",
                table: "Yatlar");

            migrationBuilder.DropColumn(
                name: "ImgLocation3",
                table: "Yatlar");

            migrationBuilder.DropColumn(
                name: "Sifre",
                table: "Users");

            migrationBuilder.AlterColumn<decimal>(
                name: "Price",
                table: "Yatlar",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(int));
        }
    }
}
