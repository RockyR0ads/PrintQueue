using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PrintQueueDemo.Migrations
{
    /// <inheritdoc />
    public partial class SeedPricingConfig : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "PricingConfig",
                columns: new[] { "Id", "ElectricityCostPerKwh" },
                values: new object[] { 1, 0.30m });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "PricingConfig",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}
