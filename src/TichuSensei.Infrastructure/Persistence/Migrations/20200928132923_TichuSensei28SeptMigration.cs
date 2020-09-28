using Microsoft.EntityFrameworkCore.Migrations;

namespace TichuSensei.Infrastructure.Persistence.Migrations
{
    public partial class TichuSensei28SeptMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_games_player_stats_stats_id",
                table: "games");

            migrationBuilder.DropIndex(
                name: "ix_games_stats_id",
                table: "games");

            migrationBuilder.DropColumn(
                name: "stats_id",
                table: "games");

            migrationBuilder.AlterColumn<bool>(
                name: "success",
                table: "calls",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "boolean");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "stats_id",
                table: "games",
                type: "text",
                nullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "success",
                table: "calls",
                type: "boolean",
                nullable: false,
                oldClrType: typeof(bool),
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "ix_games_stats_id",
                table: "games",
                column: "stats_id");

            migrationBuilder.AddForeignKey(
                name: "fk_games_player_stats_stats_id",
                table: "games",
                column: "stats_id",
                principalTable: "player_stats",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
