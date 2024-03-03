using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ET_Vest.Migrations
{
    /// <inheritdoc />
    public partial class UpdateSaleMode : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<double>(
                name: "SoldQuantity",
                table: "Sales",
                type: "float",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "SoldQuantity",
                table: "Sales",
                type: "int",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");
        }
    }
}
