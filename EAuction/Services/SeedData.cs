using EAuction.Data;
using EAuction.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EAuction.Models
{
    public class SeedData
    {
        public static void Seed(IApplicationBuilder applicationBuilder)
        {
            var scope = applicationBuilder.ApplicationServices.CreateScope();

            ApplicationDbContext context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();


            if (!context.Users.Any())
            {
                context.AddRange(new User { FirstName = "Johnny", LastName = "B.Goode", Email = "joh134255@yahoo.com", NickName = "john1243", Feedback = 100, Country = Country.UK },
                                new User { FirstName = "Mike", LastName = "Roost", Email = "miker455@yahoo.com", NickName = "mike_seller", Feedback = 98, Country = Country.Germany });
                context.SaveChanges();
            }
            if (!context.Auctions.Any())
            {
                
                var user1 = context.AuctionUser.Single(u => u.NickName.Equals("john1243"));
                var user2 = context.AuctionUser.Single(u => u.NickName.Equals("mike_seller"));


                context.AddRange
                    (new Auction { Name = "Grand Theft Auto V - PS4 Game", Details = "Grand Theft Auto V - PS4 Game - new sealed", EndDate = new DateTime(2020, 10, 27), Price = 30, UrlImage = "gta5_ps4.jpg", Category = Category.Video, Condition = Condition.New, Seller = user1 },
                    new Auction { Name = "Last Of Us 2 - PS4 Game", Details = "Last of Us 2 - PS4 Game - like new", EndDate = new DateTime(2020, 11, 03), Price = 30, UrlImage = "lastofus2.jpg", Category = Category.Video, Condition = Condition.LikeNew, Seller = user1 },
                   new Auction { Name = "Red Dead Redemption 2 - PS4 Game", Details = "Red Dead Redemption 2 - PS4 Game - in good condition", EndDate = new DateTime(2020, 10, 14), Price = 45, UrlImage = "rdr2_ps4.jpg", Category = Category.Video, Condition = Condition.Used, Seller = user1 },
                   new Auction { Name = "Uncharted 4 - PS4 Game", Details = "Uncharted 4 - PS4 Game - new sealed", EndDate = new DateTime(2020, 10, 05), Price = 15, UrlImage = "uncharted4.jpg", Category = Category.Video, Condition = Condition.New, Seller = user1 },
                   new Auction { Name = "Playstation 4 Console", Details = "Playstation 4 Console - brand new", EndDate = new DateTime(2020, 12, 12), Price = 170, UrlImage = "console_ps4.jpg", Category = Category.Video, Condition = Condition.New, Seller = user2 },
                   new Auction { Name = "Razer BlackWidow Keyboard", Details = "Razer BlackWidow Keyboard - new sealed", EndDate = new DateTime(2020, 12, 30), Price = 30, UrlImage = "razer_blackwidow.jpg", Category = Category.Video, Condition = Condition.New, Seller = user2 },
                   new Auction { Name = "Razer Kraken - Headset", Details = "Razer Kraken - Headset", EndDate = new DateTime(2020, 10, 22), Price = 30, UrlImage = "razer_kraken.jpg", Category = Category.Video, Condition = Condition.New, Seller = user2 }
                );
            }

            context.SaveChanges();
        }

    }
}
