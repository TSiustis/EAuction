using EAuction.Data;
using EAuction.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;

namespace EAuction.UnitTests
{
    [TestClass]
    public class AuctionRepositoryTest
    {
        protected DbContextOptions<ApplicationDbContext> ContextOptions { get; }
        public AuctionRepositoryTest()
        {
            ContextOptions = new DbContextOptionsBuilder<ApplicationDbContext>().UseInMemoryDatabase(databaseName: "database_name").Options;
            Seed();
        }
        public AuctionRepositoryTest(DbContextOptions<ApplicationDbContext> ContextOptions)
        {
            ContextOptions = new DbContextOptionsBuilder<ApplicationDbContext>().UseInMemoryDatabase(databaseName: "database_name").Options;
            Seed();
        }
        [TestInitialize]
        public void Seed()
        {
         
            using (var context = new ApplicationDbContext(ContextOptions))
            {

                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();
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
        [TestMethod]
        public void Can_get_auctions()
        {
          
            using (var context = new ApplicationDbContext(ContextOptions))
            {
                var repository = new AuctionRepository(context);

                var items = repository.GetAuctions().ToList();

                Assert.AreEqual(7, items.Count());
                Assert.AreEqual("Last Of Us 2 - PS4 Game", items[0].Name);
                Assert.AreEqual("Grand Theft Auto V - PS4 Game", items[1].Name);
                Assert.AreEqual("Red Dead Redemption 2 - PS4 Game", items[2].Name);
                Assert.AreEqual("Uncharted 4 - PS4 Game", items[3].Name);
                Assert.AreEqual("Playstation 4 Console", items[4].Name);
                Assert.AreEqual("Razer BlackWidow Keyboard", items[5].Name);
                Assert.AreEqual("Razer Kraken - Headset", items[6].Name);
            }
        }
        [TestMethod]
        public void Can_get_auction_by_id()
        {
            using (var context = new ApplicationDbContext(ContextOptions))
            {
                var repository = new AuctionRepository(context);
                var item = repository.GetAuctionById(1);
                Assert.AreEqual("Grand Theft Auto V - PS4 Game", item.Name);
            }
        }
        [TestMethod]
        public void Can_create_auction()
        {
            using (var context = new ApplicationDbContext(ContextOptions))
            {
                var repository = new AuctionRepository(context);
                repository.CreateAuction(new Auction { Name = "Test Auction", Details = "This is a test auction", EndDate = new DateTime(2020, 10, 22), Price = 30 });
                var item = context.Set<Auction>().Single(a => a.Name == "Test Auction");
                Assert.AreEqual("Test Auction", item.Name);
           }
        }
        [TestMethod]
        public void Can_search_auction()
        {
            using (var context = new ApplicationDbContext(ContextOptions))
            {
                var repository = new AuctionRepository(context);
                var item = repository.GetAuctions("Uncharted").FirstOrDefault();
                Assert.AreEqual("Uncharted 4 - PS4 Game", item.Name);
            }
        }
    }
}
