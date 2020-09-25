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
                    (new Auction {  Name = "Ps4 Game", Details = "PS4 Game in very good condition", StartDate = new DateTime(2020, 8, 29), EndDate = new DateTime(2020, 9, 3), Price = 30 ,UrlImage = "https://www.ryze.ro/wp-content/uploads/2019/07/100-de-milioane-de-unitati.jpg"},
                    new Auction {  Name = "Rare Coin", Details = "4th Century Coin ", StartDate = new DateTime(2020, 8, 29), EndDate = new DateTime(2020, 9, 3), Price = 300, UrlImage = "https://lcdn.altex.ro/resize/media/catalog/product/G/r/2bd48d28d1c32adea0e55139a4e6434a/Grand_Theft_Auto_V_Premium_Edition_PS4_2D_COVER_076fd4ac.jpg" },
                    new Auction { Name = "Authentic Sword 16th Century", Details = "Authentic Sword from 16th Century Bavaria", StartDate = new DateTime(2020, 8, 29), EndDate = new DateTime(2020, 9, 3), Price = 2999,UrlImage= "https://lcdn.altex.ro/media/catalog/product/G/o/God_of_War_PS4_2D_Coperta_PlayStation_Hits_3fbfd5d9.jpg" }
                );
            }

            context.SaveChanges();
        }

    }
}
