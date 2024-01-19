using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WatchPeopleDie.tv.Data.Migrations
{
    public partial class _1133 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "Video",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Video_UserId",
                table: "Video",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Video_AspNetUsers_UserId",
                table: "Video",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Video_AspNetUsers_UserId",
                table: "Video");

            migrationBuilder.DropIndex(
                name: "IX_Video_UserId",
                table: "Video");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Video");
        }
    }
}
