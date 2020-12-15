using Microsoft.EntityFrameworkCore.Migrations;

namespace ServerScraper.Migrations
{
    public partial class AnonBanExpire : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<ulong>(
                name: "ExpiresAt",
                table: "anonbans",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0ul);

            migrationBuilder.AddPrimaryKey(
                name: "PK_prefixes",
                table: "prefixes",
                columns: new[] { "prefix", "server" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_prefixes",
                table: "prefixes");

            migrationBuilder.DropColumn(
                name: "ExpiresAt",
                table: "anonbans");
        }
    }
}
