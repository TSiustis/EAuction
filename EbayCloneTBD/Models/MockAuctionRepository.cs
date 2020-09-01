using EAuction.Models;
using EbayCloneTBD.Pages.Auctions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EbayCloneTBD.Models
{
    public class MockAuctionRepository : IAuctionRepository
    {

        public PaginatedList<Auction> Auctions { get; set; }
        public MockAuctionRepository()
        {
            //IEnumerable<Auction> _auctions =
            //Auctions.AddRange(new List<Auction>  {
            //    new Auction{Id = 1, Name = "Ps4 Game" , Details = "PS4 Game in very good condition", StartDate = new DateTime(2020,8,29), EndDate = new DateTime(2020,9,3), Price = 30},
            //    new Auction{Id = 2, Name = "Rare Coin" , Details = "4th Century Coin ", StartDate = new DateTime(2020,8,29), EndDate = new DateTime(2020,9,3), Price = 300},
            //    new Auction{Id = 3, Name = "Authentic Sword 16th Century" , Details = "Authentic Sword from 16th Century Bavaria", StartDate = new DateTime(2020,8,29), EndDate = new DateTime(2020,9,3), Price = 2999}


            //});
       
        }
        public void CreateAction()
        {
            throw new NotImplementedException();
        }


        public Auction GetAuctionById(int id)
        {
            return Auctions.SingleOrDefault(a => a.Id == id);
        }

       
    


        IQueryable<Auction> IAuctionRepository.GetAuctions()
        {
            throw new NotImplementedException();
        }

        public void CreateAction(Auction auction)
        {
            throw new NotImplementedException();
        }

        public void DeleteAuctionById(Auction Auction)
        {
            throw new NotImplementedException();
        }

        IQueryable<Auction> IAuctionRepository.GetAuctions(string SearchString)
        {
            throw new NotImplementedException();
        }
    }
}
