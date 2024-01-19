using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WatchPeopleDie.tv.Data.Migrations
{
    public partial class noUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Video_AspNetUsers_UserId",
                table: "Video");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Video",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.AddForeignKey(
                name: "FK_Video_AspNetUsers_UserId",
                table: "Video",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Video_AspNetUsers_UserId",
                table: "Video");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Video",
                type: "TEXT",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Video_AspNetUsers_UserId",
                table: "Video",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
