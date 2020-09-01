using EbayCloneTBD.Data;
using EbayCloneTBD.Models;
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

         

            if (!context.Auctions.Any())
            {
                context.AddRange
                    (new Auction {  Name = "Ps4 Game", Details = "PS4 Game in very good condition", StartDate = new DateTime(2020, 8, 29), EndDate = new DateTime(2020, 9, 3), Price = 30 },
                    new Auction {  Name = "Rare Coin", Details = "4th Century Coin ", StartDate = new DateTime(2020, 8, 29), EndDate = new DateTime(2020, 9, 3), Price = 300 },
                    new Auction { Name = "Authentic Sword 16th Century", Details = "Authentic Sword from 16th Century Bavaria", StartDate = new DateTime(2020, 8, 29), EndDate = new DateTime(2020, 9, 3), Price = 2999 }
                );
            }

            context.SaveChanges();
        }

    }
}
