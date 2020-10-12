using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace TichuSensei.Infrastructure.Persistence.Migrations
{
    public partial class initialPgsqlMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    id = table.Column<string>(nullable: false),
                    name = table.Column<string>(maxLength: 256, nullable: true),
                    normalized_name = table.Column<string>(maxLength: 256, nullable: true),
                    concurrency_stamp = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_roles", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    id = table.Column<string>(nullable: false),
                    user_name = table.Column<string>(maxLength: 256, nullable: true),
                    normalized_user_name = table.Column<string>(maxLength: 256, nullable: true),
                    email = table.Column<string>(maxLength: 256, nullable: true),
                    normalized_email = table.Column<string>(maxLength: 256, nullable: true),
                    email_confirmed = table.Column<bool>(nullable: false),
                    password_hash = table.Column<string>(nullable: true),
                    security_stamp = table.Column<string>(nullable: true),
                    concurrency_stamp = table.Column<string>(nullable: true),
                    phone_number = table.Column<string>(nullable: true),
                    phone_number_confirmed = table.Column<bool>(nullable: false),
                    two_factor_enabled = table.Column<bool>(nullable: false),
                    lockout_end = table.Column<DateTimeOffset>(nullable: true),
                    lockout_enabled = table.Column<bool>(nullable: false),
                    access_failed_count = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_users", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "DeviceCodes",
                columns: table => new
                {
                    user_code = table.Column<string>(maxLength: 200, nullable: false),
                    device_code = table.Column<string>(maxLength: 200, nullable: false),
                    subject_id = table.Column<string>(maxLength: 200, nullable: true),
                    client_id = table.Column<string>(maxLength: 200, nullable: false),
                    creation_time = table.Column<DateTime>(nullable: false),
                    expiration = table.Column<DateTime>(nullable: false),
                    data = table.Column<string>(maxLength: 50000, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_device_codes", x => x.user_code);
                });

            migrationBuilder.CreateTable(
                name: "PersistedGrants",
                columns: table => new
                {
                    key = table.Column<string>(maxLength: 200, nullable: false),
                    type = table.Column<string>(maxLength: 50, nullable: false),
                    subject_id = table.Column<string>(maxLength: 200, nullable: true),
                    client_id = table.Column<string>(maxLength: 200, nullable: false),
                    creation_time = table.Column<DateTime>(nullable: false),
                    expiration = table.Column<DateTime>(nullable: true),
                    data = table.Column<string>(maxLength: 50000, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_persisted_grants", x => x.key);
                });

            migrationBuilder.CreateTable(
                name: "players",
                columns: table => new
                {
                    player_id = table.Column<long>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    user_id = table.Column<string>(nullable: true),
                    name = table.Column<string>(nullable: true),
                    date_created = table.Column<DateTime>(nullable: false),
                    avatar_path = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_players", x => x.player_id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    role_id = table.Column<string>(nullable: false),
                    claim_type = table.Column<string>(nullable: true),
                    claim_value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_role_claims", x => x.id);
                    table.ForeignKey(
                        name: "fk_role_claims_asp_net_roles_identity_role_id",
                        column: x => x.role_id,
                        principalTable: "AspNetRoles",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    user_id = table.Column<string>(nullable: false),
                    claim_type = table.Column<string>(nullable: true),
                    claim_value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_user_claims", x => x.id);
                    table.ForeignKey(
                        name: "fk_user_claims_asp_net_users_application_user_id",
                        column: x => x.user_id,
                        principalTable: "AspNetUsers",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    login_provider = table.Column<string>(maxLength: 128, nullable: false),
                    provider_key = table.Column<string>(maxLength: 128, nullable: false),
                    provider_display_name = table.Column<string>(nullable: true),
                    user_id = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_user_logins", x => new { x.login_provider, x.provider_key });
                    table.ForeignKey(
                        name: "fk_user_logins_asp_net_users_application_user_id",
                        column: x => x.user_id,
                        principalTable: "AspNetUsers",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    user_id = table.Column<string>(nullable: false),
                    role_id = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_user_roles", x => new { x.user_id, x.role_id });
                    table.ForeignKey(
                        name: "fk_user_roles_asp_net_roles_identity_role_id",
                        column: x => x.role_id,
                        principalTable: "AspNetRoles",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_user_roles_asp_net_users_application_user_id",
                        column: x => x.user_id,
                        principalTable: "AspNetUsers",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    user_id = table.Column<string>(nullable: false),
                    login_provider = table.Column<string>(maxLength: 128, nullable: false),
                    name = table.Column<string>(maxLength: 128, nullable: false),
                    value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_user_tokens", x => new { x.user_id, x.login_provider, x.name });
                    table.ForeignKey(
                        name: "fk_user_tokens_asp_net_users_application_user_id",
                        column: x => x.user_id,
                        principalTable: "AspNetUsers",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "player_stats",
                columns: table => new
                {
                    id = table.Column<long>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    elo_rating = table.Column<int>(nullable: false),
                    games_total = table.Column<long>(nullable: false),
                    games_won = table.Column<long>(nullable: false),
                    rounds_total = table.Column<long>(nullable: false),
                    rounds_drawn = table.Column<long>(nullable: false),
                    rounds_won = table.Column<long>(nullable: false),
                    points_won = table.Column<long>(nullable: false),
                    grand_tichu_calls_total = table.Column<long>(nullable: false),
                    grand_tichu_calls_won = table.Column<long>(nullable: false),
                    tichu_calls_total = table.Column<long>(nullable: false),
                    tichu_calls_won = table.Column<long>(nullable: false),
                    high_cards_total = table.Column<long>(nullable: false),
                    opponents_high_cards_total = table.Column<long>(nullable: false),
                    bombs_total = table.Column<long>(nullable: false),
                    opponents_bombs_total = table.Column<long>(nullable: false),
                    player_id = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_player_stats", x => x.id);
                    table.ForeignKey(
                        name: "fk_player_stats_players_player_id",
                        column: x => x.player_id,
                        principalTable: "players",
                        principalColumn: "player_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "teams",
                columns: table => new
                {
                    team_id = table.Column<long>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(nullable: true),
                    date_created = table.Column<DateTime>(nullable: false),
                    player_one_id = table.Column<long>(nullable: false),
                    player_two_id = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_teams", x => x.team_id);
                    table.ForeignKey(
                        name: "fk_teams_players_player_one_id",
                        column: x => x.player_one_id,
                        principalTable: "players",
                        principalColumn: "player_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_teams_players_player_two_id",
                        column: x => x.player_two_id,
                        principalTable: "players",
                        principalColumn: "player_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "games",
                columns: table => new
                {
                    game_id = table.Column<long>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    date_created = table.Column<DateTime>(nullable: false),
                    created_by = table.Column<string>(nullable: true),
                    date_last_modified = table.Column<DateTime>(nullable: true),
                    last_modified_by = table.Column<string>(nullable: true),
                    mercy_rule = table.Column<bool>(nullable: false),
                    game_over = table.Column<bool>(nullable: false),
                    team_one_id = table.Column<long>(nullable: false),
                    team_two_id = table.Column<long>(nullable: false),
                    player_one_id = table.Column<long>(nullable: false),
                    player_two_id = table.Column<long>(nullable: false),
                    player_three_id = table.Column<long>(nullable: false),
                    player_four_id = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_games", x => x.game_id);
                    table.ForeignKey(
                        name: "fk_games_players_player_four_id",
                        column: x => x.player_four_id,
                        principalTable: "players",
                        principalColumn: "player_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_games_players_player_one_id",
                        column: x => x.player_one_id,
                        principalTable: "players",
                        principalColumn: "player_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_games_players_player_three_id",
                        column: x => x.player_three_id,
                        principalTable: "players",
                        principalColumn: "player_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_games_players_player_two_id",
                        column: x => x.player_two_id,
                        principalTable: "players",
                        principalColumn: "player_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_games_teams_team_one_id",
                        column: x => x.team_one_id,
                        principalTable: "teams",
                        principalColumn: "team_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_games_teams_team_two_id",
                        column: x => x.team_two_id,
                        principalTable: "teams",
                        principalColumn: "team_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "team_stats",
                columns: table => new
                {
                    id = table.Column<long>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    elo_rating = table.Column<int>(nullable: false),
                    games_total = table.Column<long>(nullable: false),
                    games_won = table.Column<long>(nullable: false),
                    rounds_total = table.Column<long>(nullable: false),
                    rounds_drawn = table.Column<long>(nullable: false),
                    rounds_won = table.Column<long>(nullable: false),
                    points_won = table.Column<long>(nullable: false),
                    grand_tichu_calls_total = table.Column<long>(nullable: false),
                    grand_tichu_calls_won = table.Column<long>(nullable: false),
                    tichu_calls_total = table.Column<long>(nullable: false),
                    tichu_calls_won = table.Column<long>(nullable: false),
                    high_cards_total = table.Column<long>(nullable: false),
                    opponents_high_cards_total = table.Column<long>(nullable: false),
                    bombs_total = table.Column<long>(nullable: false),
                    opponents_bombs_total = table.Column<long>(nullable: false),
                    team_id = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_team_stats", x => x.id);
                    table.ForeignKey(
                        name: "fk_team_stats_teams_team_id",
                        column: x => x.team_id,
                        principalTable: "teams",
                        principalColumn: "team_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "game_stats",
                columns: table => new
                {
                    id = table.Column<long>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    date_created = table.Column<DateTime>(nullable: false),
                    created_by = table.Column<string>(nullable: true),
                    date_last_modified = table.Column<DateTime>(nullable: true),
                    last_modified_by = table.Column<string>(nullable: true),
                    rounds_total = table.Column<long>(nullable: false),
                    rounds_won_team_one = table.Column<long>(nullable: false),
                    rounds_won_team_two = table.Column<long>(nullable: false),
                    grand_tichu_calls_total_team_one = table.Column<long>(nullable: false),
                    grand_tichu_calls_won_team_one = table.Column<long>(nullable: false),
                    grand_tichu_calls_total_team_two = table.Column<long>(nullable: false),
                    grand_tichu_calls_won_team_two = table.Column<long>(nullable: false),
                    tichu_calls_total_team_one = table.Column<long>(nullable: false),
                    tichu_calls_won_team_one = table.Column<long>(nullable: false),
                    tichu_calls_total_team_two = table.Column<long>(nullable: false),
                    tichu_calls_won_team_two = table.Column<long>(nullable: false),
                    high_cards_total_team_one = table.Column<long>(nullable: false),
                    high_cards_total_team_two = table.Column<long>(nullable: false),
                    bombs_total_team_one = table.Column<long>(nullable: false),
                    bombs_total_team_two = table.Column<long>(nullable: false),
                    game_id = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_game_stats", x => x.id);
                    table.ForeignKey(
                        name: "fk_game_stats_games_game_id",
                        column: x => x.game_id,
                        principalTable: "games",
                        principalColumn: "game_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "rounds",
                columns: table => new
                {
                    round_id = table.Column<long>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    date_created = table.Column<DateTime>(nullable: false),
                    date_ended = table.Column<DateTime>(nullable: true),
                    team_one_id = table.Column<long>(nullable: false),
                    team_two_id = table.Column<long>(nullable: false),
                    player_one_id = table.Column<long>(nullable: false),
                    player_two_id = table.Column<long>(nullable: false),
                    player_three_id = table.Column<long>(nullable: false),
                    player_four_id = table.Column<long>(nullable: false),
                    score_team_one = table.Column<long>(nullable: false),
                    score_team_two = table.Column<long>(nullable: false),
                    high_cards_team_one = table.Column<long>(nullable: false),
                    high_cards_team_two = table.Column<long>(nullable: false),
                    bombs_team_one = table.Column<long>(nullable: false),
                    bombs_team_two = table.Column<long>(nullable: false),
                    game_stats_id = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_rounds", x => x.round_id);
                    table.ForeignKey(
                        name: "fk_rounds_game_stats_game_stats_id",
                        column: x => x.game_stats_id,
                        principalTable: "game_stats",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_rounds_players_player_four_id",
                        column: x => x.player_four_id,
                        principalTable: "players",
                        principalColumn: "player_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_rounds_players_player_one_id",
                        column: x => x.player_one_id,
                        principalTable: "players",
                        principalColumn: "player_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_rounds_players_player_three_id",
                        column: x => x.player_three_id,
                        principalTable: "players",
                        principalColumn: "player_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_rounds_players_player_two_id",
                        column: x => x.player_two_id,
                        principalTable: "players",
                        principalColumn: "player_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_rounds_teams_team_one_id",
                        column: x => x.team_one_id,
                        principalTable: "teams",
                        principalColumn: "team_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_rounds_teams_team_two_id",
                        column: x => x.team_two_id,
                        principalTable: "teams",
                        principalColumn: "team_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "calls",
                columns: table => new
                {
                    call_id = table.Column<long>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    player_id = table.Column<long>(nullable: false),
                    team_id = table.Column<long>(nullable: false),
                    call_type = table.Column<int>(nullable: false),
                    success = table.Column<bool>(nullable: true),
                    round_id = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_calls", x => x.call_id);
                    table.ForeignKey(
                        name: "fk_calls_rounds_round_id",
                        column: x => x.round_id,
                        principalTable: "rounds",
                        principalColumn: "round_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "ix_role_claims_role_id",
                table: "AspNetRoleClaims",
                column: "role_id");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "normalized_name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_user_claims_user_id",
                table: "AspNetUserClaims",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "ix_user_logins_user_id",
                table: "AspNetUserLogins",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "ix_user_roles_role_id",
                table: "AspNetUserRoles",
                column: "role_id");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "normalized_email");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "normalized_user_name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_calls_round_id",
                table: "calls",
                column: "round_id");

            migrationBuilder.CreateIndex(
                name: "ix_device_codes_device_code",
                table: "DeviceCodes",
                column: "device_code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_device_codes_expiration",
                table: "DeviceCodes",
                column: "expiration");

            migrationBuilder.CreateIndex(
                name: "ix_game_stats_game_id",
                table: "game_stats",
                column: "game_id");

            migrationBuilder.CreateIndex(
                name: "ix_games_player_four_id",
                table: "games",
                column: "player_four_id");

            migrationBuilder.CreateIndex(
                name: "ix_games_player_one_id",
                table: "games",
                column: "player_one_id");

            migrationBuilder.CreateIndex(
                name: "ix_games_player_three_id",
                table: "games",
                column: "player_three_id");

            migrationBuilder.CreateIndex(
                name: "ix_games_player_two_id",
                table: "games",
                column: "player_two_id");

            migrationBuilder.CreateIndex(
                name: "ix_games_team_one_id",
                table: "games",
                column: "team_one_id");

            migrationBuilder.CreateIndex(
                name: "ix_games_team_two_id",
                table: "games",
                column: "team_two_id");

            migrationBuilder.CreateIndex(
                name: "ix_persisted_grants_expiration",
                table: "PersistedGrants",
                column: "expiration");

            migrationBuilder.CreateIndex(
                name: "ix_persisted_grants_subject_id_client_id_type",
                table: "PersistedGrants",
                columns: new[] { "subject_id", "client_id", "type" });

            migrationBuilder.CreateIndex(
                name: "ix_player_stats_player_id",
                table: "player_stats",
                column: "player_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_rounds_game_stats_id",
                table: "rounds",
                column: "game_stats_id");

            migrationBuilder.CreateIndex(
                name: "ix_rounds_player_four_id",
                table: "rounds",
                column: "player_four_id");

            migrationBuilder.CreateIndex(
                name: "ix_rounds_player_one_id",
                table: "rounds",
                column: "player_one_id");

            migrationBuilder.CreateIndex(
                name: "ix_rounds_player_three_id",
                table: "rounds",
                column: "player_three_id");

            migrationBuilder.CreateIndex(
                name: "ix_rounds_player_two_id",
                table: "rounds",
                column: "player_two_id");

            migrationBuilder.CreateIndex(
                name: "ix_rounds_team_one_id",
                table: "rounds",
                column: "team_one_id");

            migrationBuilder.CreateIndex(
                name: "ix_rounds_team_two_id",
                table: "rounds",
                column: "team_two_id");

            migrationBuilder.CreateIndex(
                name: "ix_team_stats_team_id",
                table: "team_stats",
                column: "team_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_teams_player_one_id",
                table: "teams",
                column: "player_one_id");

            migrationBuilder.CreateIndex(
                name: "ix_teams_player_two_id",
                table: "teams",
                column: "player_two_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "calls");

            migrationBuilder.DropTable(
                name: "DeviceCodes");

            migrationBuilder.DropTable(
                name: "PersistedGrants");

            migrationBuilder.DropTable(
                name: "player_stats");

            migrationBuilder.DropTable(
                name: "team_stats");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "rounds");

            migrationBuilder.DropTable(
                name: "game_stats");

            migrationBuilder.DropTable(
                name: "games");

            migrationBuilder.DropTable(
                name: "teams");

            migrationBuilder.DropTable(
                name: "players");
        }
    }
}
