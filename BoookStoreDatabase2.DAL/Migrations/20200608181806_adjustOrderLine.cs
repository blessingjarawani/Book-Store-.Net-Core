using Microsoft.EntityFrameworkCore.Migrations;

namespace BoookStoreDatabase2.DAL.Migrations
{
    public partial class adjustOrderLine : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CartStatus",
                table: "OrderLines",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CartStatus",
                table: "OrderLines");
        }
    }
}
