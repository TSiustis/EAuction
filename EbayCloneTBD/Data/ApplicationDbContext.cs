using System;
using System.Collections.Generic;
using System.Text;
using EbayCloneTBD.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace EbayCloneTBD.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Auction> Auctions { get; set; }
        public DbSet<User> AuctionUser { get; set; }
    }
}
