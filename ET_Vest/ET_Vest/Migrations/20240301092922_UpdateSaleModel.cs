using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ET_Vest.Migrations
{
    /// <inheritdoc />
    public partial class UpdateSaleModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Sum",
                table: "Sales");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "Sum",
                table: "Sales",
                type: "float",
                nullable: false,
                defaultValue: 0.0);
        }
    }
}
