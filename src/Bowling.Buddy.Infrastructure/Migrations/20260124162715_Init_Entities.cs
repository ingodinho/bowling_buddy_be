using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Bowling.Buddy.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Init_Entities : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Bowling");

            migrationBuilder.CreateTable(
                name: "Groups",
                schema: "Bowling",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    DeletedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Groups", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Games",
                schema: "Bowling",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    DateTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    GroupId = table.Column<Guid>(type: "uuid", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    DeletedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Games", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Games_Groups_GroupId",
                        column: x => x.GroupId,
                        principalSchema: "Bowling",
                        principalTable: "Groups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Players",
                schema: "Bowling",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    DisplayName = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    GroupId = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    DeletedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Players", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Players_Groups_GroupId",
                        column: x => x.GroupId,
                        principalSchema: "Bowling",
                        principalTable: "Groups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Scores",
                schema: "Bowling",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    FinalScore = table.Column<int>(type: "integer", nullable: false),
                    PlayerId = table.Column<Guid>(type: "uuid", nullable: false),
                    GameId = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    DeletedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Scores", x => x.Id);
                    table.CheckConstraint("CK_Scores_FinalScore_Range", "\"FinalScore\" >= 0 AND \"FinalScore\" <= 300");
                    table.ForeignKey(
                        name: "FK_Scores_Games_GameId",
                        column: x => x.GameId,
                        principalSchema: "Bowling",
                        principalTable: "Games",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Scores_Players_PlayerId",
                        column: x => x.PlayerId,
                        principalSchema: "Bowling",
                        principalTable: "Players",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Games_GroupId",
                schema: "Bowling",
                table: "Games",
                column: "GroupId");

            migrationBuilder.CreateIndex(
                name: "IX_Players_GroupId",
                schema: "Bowling",
                table: "Players",
                column: "GroupId");

            migrationBuilder.CreateIndex(
                name: "IX_Scores_GameId",
                schema: "Bowling",
                table: "Scores",
                column: "GameId");

            migrationBuilder.CreateIndex(
                name: "IX_Scores_PlayerId_GameId",
                schema: "Bowling",
                table: "Scores",
                columns: new[] { "PlayerId", "GameId" },
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Scores",
                schema: "Bowling");

            migrationBuilder.DropTable(
                name: "Games",
                schema: "Bowling");

            migrationBuilder.DropTable(
                name: "Players",
                schema: "Bowling");

            migrationBuilder.DropTable(
                name: "Groups",
                schema: "Bowling");
        }
    }
}
