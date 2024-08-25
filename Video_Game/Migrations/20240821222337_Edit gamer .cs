using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Video_Game.Migrations
{
    /// <inheritdoc />
    public partial class Editgamer : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Gamers_Subscriptions_SubscriptionId",
                table: "Gamers");

            migrationBuilder.DropIndex(
                name: "IX_Gamers_SubscriptionId",
                table: "Gamers");

            migrationBuilder.AlterColumn<string>(
                name: "SubscriptionType",
                table: "Gamers",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<int>(
                name: "SubscriptionId",
                table: "Gamers",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_Gamers_SubscriptionId",
                table: "Gamers",
                column: "SubscriptionId",
                unique: true,
                filter: "[SubscriptionId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Gamers_Subscriptions_SubscriptionId",
                table: "Gamers",
                column: "SubscriptionId",
                principalTable: "Subscriptions",
                principalColumn: "SubscriptionID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Gamers_Subscriptions_SubscriptionId",
                table: "Gamers");

            migrationBuilder.DropIndex(
                name: "IX_Gamers_SubscriptionId",
                table: "Gamers");

            migrationBuilder.AlterColumn<string>(
                name: "SubscriptionType",
                table: "Gamers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "SubscriptionId",
                table: "Gamers",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Gamers_SubscriptionId",
                table: "Gamers",
                column: "SubscriptionId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Gamers_Subscriptions_SubscriptionId",
                table: "Gamers",
                column: "SubscriptionId",
                principalTable: "Subscriptions",
                principalColumn: "SubscriptionID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
