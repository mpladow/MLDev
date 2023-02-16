using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MLDev.LOTOW.Migrations
{
    /// <inheritdoc />
    public partial class UpdateSchemas2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CharacterStat_Characters_CharacterId",
                schema: "LOTOW",
                table: "CharacterStat");

            migrationBuilder.DropForeignKey(
                name: "FK_CharacterStat_Stats_StatId",
                schema: "LOTOW",
                table: "CharacterStat");

            migrationBuilder.DropForeignKey(
                name: "FK_StatModifiers_CharacterStat_CharacterStatId",
                table: "StatModifiers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Stats",
                table: "Stats");

            migrationBuilder.DropPrimaryKey(
                name: "PK_StatModifiers",
                table: "StatModifiers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Characters",
                table: "Characters");

            migrationBuilder.RenameTable(
                name: "Stats",
                newName: "Stat",
                newSchema: "LOTOW");

            migrationBuilder.RenameTable(
                name: "StatModifiers",
                newName: "StatModifier",
                newSchema: "LOTOW");

            migrationBuilder.RenameTable(
                name: "Characters",
                newName: "Character",
                newSchema: "LOTOW");

            migrationBuilder.RenameIndex(
                name: "IX_StatModifiers_CharacterStatId",
                schema: "LOTOW",
                table: "StatModifier",
                newName: "IX_StatModifier_CharacterStatId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Stat",
                schema: "LOTOW",
                table: "Stat",
                column: "StatId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_StatModifier",
                schema: "LOTOW",
                table: "StatModifier",
                column: "StatModifierId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Character",
                schema: "LOTOW",
                table: "Character",
                column: "CharacterId");

            migrationBuilder.AddForeignKey(
                name: "FK_CharacterStat_Character_CharacterId",
                schema: "LOTOW",
                table: "CharacterStat",
                column: "CharacterId",
                principalSchema: "LOTOW",
                principalTable: "Character",
                principalColumn: "CharacterId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CharacterStat_Stat_StatId",
                schema: "LOTOW",
                table: "CharacterStat",
                column: "StatId",
                principalSchema: "LOTOW",
                principalTable: "Stat",
                principalColumn: "StatId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_StatModifier_CharacterStat_CharacterStatId",
                schema: "LOTOW",
                table: "StatModifier",
                column: "CharacterStatId",
                principalSchema: "LOTOW",
                principalTable: "CharacterStat",
                principalColumn: "CharacterStatId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CharacterStat_Character_CharacterId",
                schema: "LOTOW",
                table: "CharacterStat");

            migrationBuilder.DropForeignKey(
                name: "FK_CharacterStat_Stat_StatId",
                schema: "LOTOW",
                table: "CharacterStat");

            migrationBuilder.DropForeignKey(
                name: "FK_StatModifier_CharacterStat_CharacterStatId",
                schema: "LOTOW",
                table: "StatModifier");

            migrationBuilder.DropPrimaryKey(
                name: "PK_StatModifier",
                schema: "LOTOW",
                table: "StatModifier");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Stat",
                schema: "LOTOW",
                table: "Stat");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Character",
                schema: "LOTOW",
                table: "Character");

            migrationBuilder.RenameTable(
                name: "StatModifier",
                schema: "LOTOW",
                newName: "StatModifiers");

            migrationBuilder.RenameTable(
                name: "Stat",
                schema: "LOTOW",
                newName: "Stats");

            migrationBuilder.RenameTable(
                name: "Character",
                schema: "LOTOW",
                newName: "Characters");

            migrationBuilder.RenameIndex(
                name: "IX_StatModifier_CharacterStatId",
                table: "StatModifiers",
                newName: "IX_StatModifiers_CharacterStatId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_StatModifiers",
                table: "StatModifiers",
                column: "StatModifierId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Stats",
                table: "Stats",
                column: "StatId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Characters",
                table: "Characters",
                column: "CharacterId");

            migrationBuilder.AddForeignKey(
                name: "FK_CharacterStat_Characters_CharacterId",
                schema: "LOTOW",
                table: "CharacterStat",
                column: "CharacterId",
                principalTable: "Characters",
                principalColumn: "CharacterId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CharacterStat_Stats_StatId",
                schema: "LOTOW",
                table: "CharacterStat",
                column: "StatId",
                principalTable: "Stats",
                principalColumn: "StatId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_StatModifiers_CharacterStat_CharacterStatId",
                table: "StatModifiers",
                column: "CharacterStatId",
                principalSchema: "LOTOW",
                principalTable: "CharacterStat",
                principalColumn: "CharacterStatId");
        }
    }
}
