using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MLDev.LOTOW.Migrations
{
    /// <inheritdoc />
    public partial class initialmigration2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "LOTOW");

            migrationBuilder.CreateTable(
                name: "Characters",
                schema: "LOTOW",
                columns: table => new
                {
                    CharacterId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "varchar(200)", nullable: false),
                    Level = table.Column<decimal>(type: "decimal(14,2)", precision: 14, scale: 2, nullable: false),
                    Cost = table.Column<decimal>(type: "decimal(14,2)", precision: 14, scale: 2, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Characters", x => x.CharacterId);
                });

            migrationBuilder.CreateTable(
                name: "Stats",
                schema: "LOTOW",
                columns: table => new
                {
                    StatId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Order = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsFinite = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stats", x => x.StatId);
                });

            migrationBuilder.CreateTable(
                name: "CharacterStats",
                schema: "LOTOW",
                columns: table => new
                {
                    CharacterStatId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StatId = table.Column<int>(type: "int", nullable: false),
                    CharacterId = table.Column<int>(type: "int", nullable: false),
                    InitialValue = table.Column<int>(type: "int", nullable: false),
                    CurrentValue = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CharacterStats", x => x.CharacterStatId);
                    table.ForeignKey(
                        name: "FK_CharacterStats_Characters_CharacterId",
                        column: x => x.CharacterId,
                        principalSchema: "LOTOW",
                        principalTable: "Characters",
                        principalColumn: "CharacterId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CharacterStats_Stats_StatId",
                        column: x => x.StatId,
                        principalSchema: "LOTOW",
                        principalTable: "Stats",
                        principalColumn: "StatId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StatModifiers",
                schema: "LOTOW",
                columns: table => new
                {
                    StatModifierId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Value = table.Column<int>(type: "int", nullable: false),
                    SourceDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CharacterStatId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StatModifiers", x => x.StatModifierId);
                    table.ForeignKey(
                        name: "FK_StatModifiers_CharacterStats_CharacterStatId",
                        column: x => x.CharacterStatId,
                        principalSchema: "LOTOW",
                        principalTable: "CharacterStats",
                        principalColumn: "CharacterStatId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_CharacterStats_CharacterId",
                schema: "LOTOW",
                table: "CharacterStats",
                column: "CharacterId");

            migrationBuilder.CreateIndex(
                name: "IX_CharacterStats_StatId",
                schema: "LOTOW",
                table: "CharacterStats",
                column: "StatId");

            migrationBuilder.CreateIndex(
                name: "IX_StatModifiers_CharacterStatId",
                schema: "LOTOW",
                table: "StatModifiers",
                column: "CharacterStatId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "StatModifiers",
                schema: "LOTOW");

            migrationBuilder.DropTable(
                name: "CharacterStats",
                schema: "LOTOW");

            migrationBuilder.DropTable(
                name: "Characters",
                schema: "LOTOW");

            migrationBuilder.DropTable(
                name: "Stats",
                schema: "LOTOW");
        }
    }
}
