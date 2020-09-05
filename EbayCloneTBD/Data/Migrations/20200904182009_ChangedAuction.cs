using Microsoft.EntityFrameworkCore.Migrations;

namespace EbayCloneTBD.Data.Migrations
{
    public partial class ChangedAuction : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Winner",
                table: "Auctions");

            migrationBuilder.AddColumn<int>(
                name: "WinnerId",
                table: "Auctions",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Auctions_WinnerId",
                table: "Auctions",
                column: "WinnerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Auctions_AuctionUser_WinnerId",
                table: "Auctions",
                column: "WinnerId",
                principalTable: "AuctionUser",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Auctions_AuctionUser_WinnerId",
                table: "Auctions");

            migrationBuilder.DropIndex(
                name: "IX_Auctions_WinnerId",
                table: "Auctions");

            migrationBuilder.DropColumn(
                name: "WinnerId",
                table: "Auctions");

            migrationBuilder.AddColumn<string>(
                name: "Winner",
                table: "Auctions",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
