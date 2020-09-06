using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EbayCloneTBD.Data.Migrations
{
    public partial class Api : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "Feedback",
                table: "AuctionUser",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<string>(
                name: "NickName",
                table: "AuctionUser",
                nullable: true);

            migrationBuilder.AddColumn<TimeSpan>(
                name: "TimeLeft",
                table: "Auctions",
                nullable: false,
                defaultValue: new TimeSpan(0, 0, 0, 0, 0));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Feedback",
                table: "AuctionUser");

            migrationBuilder.DropColumn(
                name: "NickName",
                table: "AuctionUser");

            migrationBuilder.DropColumn(
                name: "TimeLeft",
                table: "Auctions");
        }
    }
}
