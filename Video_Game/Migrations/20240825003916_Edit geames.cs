using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Video_Game.Migrations
{
    /// <inheritdoc />
    public partial class Editgeames : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Games_Gamers_GamerID",
                table: "Games");

            migrationBuilder.AlterColumn<int>(
                name: "GamerID",
                table: "Games",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Games_Gamers_GamerID",
                table: "Games",
                column: "GamerID",
                principalTable: "Gamers",
                principalColumn: "GamerID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Games_Gamers_GamerID",
                table: "Games");

            migrationBuilder.AlterColumn<int>(
                name: "GamerID",
                table: "Games",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Games_Gamers_GamerID",
                table: "Games",
                column: "GamerID",
                principalTable: "Gamers",
                principalColumn: "GamerID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
