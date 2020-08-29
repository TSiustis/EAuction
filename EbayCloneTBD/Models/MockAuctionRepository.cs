using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EbayCloneTBD.Models
{
    public class MockAuctionRepository : IAuctionRepository
    {

        public List<Auction> Auctions { get; set; }
        public MockAuctionRepository()
        {
            Auctions = new List<Auction>()
            {
                new Auction{Id = 1, Name = "Ps4 Game" , Details = "PS4 Game in very good condition", StartDate = new DateTime(2020,8,29), EndDate = new DateTime(2020,9,3), Price = 30},
                new Auction{Id = 1, Name = "Rare Coin" , Details = "4th Century Coin ", StartDate = new DateTime(2020,8,29), EndDate = new DateTime(2020,9,3), Price = 300},
                new Auction{Id = 1, Name = "Authentic Sword 16th Century" , Details = "Authentic Sword from 16th Century Bavaria", StartDate = new DateTime(2020,8,29), EndDate = new DateTime(2020,9,3), Price = 2999}


            };
        }
        public void CreateAction()
        {
            throw new NotImplementedException();
        }

        public void DeleteAuctionById()
        {
            throw new NotImplementedException();
        }

        public Auction GetAuctionById(int id)
        {
            return Auctions.SingleOrDefault(a => a.Id == id);
        }

        public IEnumerable<Auction> GetAuctions()
        {

            return Auctions;
            
        }

        public void UpdateAuction()
        {
            throw new NotImplementedException();
        }
    }
}
