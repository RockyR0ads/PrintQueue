using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PrintQueueDemo.Migrations
{
    /// <inheritdoc />
    public partial class AddPrinterField : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Printer",
                table: "PrintJobs",
                type: "TEXT",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Printer",
                table: "PrintJobs");
        }
    }
}
