using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PrintQueueDemo.Migrations
{
    /// <inheritdoc />
    public partial class RenamePricingConfigTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_PricingConfigs",
                table: "PricingConfigs");

            migrationBuilder.RenameTable(
                name: "PricingConfigs",
                newName: "PricingConfig");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PricingConfig",
                table: "PricingConfig",
                column: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_PricingConfig",
                table: "PricingConfig");

            migrationBuilder.RenameTable(
                name: "PricingConfig",
                newName: "PricingConfigs");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PricingConfigs",
                table: "PricingConfigs",
                column: "Id");
        }
    }
}
