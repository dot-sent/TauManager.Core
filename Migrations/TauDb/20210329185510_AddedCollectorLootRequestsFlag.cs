using Microsoft.EntityFrameworkCore.Migrations;

namespace TauManager.Migrations.TauDb
{
    [System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverage]
    public partial class AddedCollectorLootRequestsFlag : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsCollectorRequest",
                table: "LootRequest",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsCollectorRequest",
                table: "LootRequest");
        }
    }
}
