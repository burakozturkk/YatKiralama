using Microsoft.EntityFrameworkCore.Migrations;

namespace YatKiralama.Data.Migrations
{
    public partial class FinalMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "Yatlar");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Yatlar",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
