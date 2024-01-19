using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WatchPeopleDie.tv.Data.Migrations
{
    public partial class _1128 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "profilePath",
                table: "AspNetUsers");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "profilePath",
                table: "AspNetUsers",
                type: "TEXT",
                nullable: true);
        }
    }
}
