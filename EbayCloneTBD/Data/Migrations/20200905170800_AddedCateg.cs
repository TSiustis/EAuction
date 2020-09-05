using Microsoft.EntityFrameworkCore.Migrations;

namespace EbayCloneTBD.Data.Migrations
{
    public partial class AddedCateg : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Condition",
                table: "Auctions",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Condition",
                table: "Auctions");
        }
    }
}
