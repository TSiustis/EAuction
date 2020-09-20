using EbayCloneTBD.Data;
using EbayCloneTBD.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EAuction.Models
{
    public class AuctionRepository : IAuctionRepository
    {
        private readonly ApplicationDbContext _context;
        public AuctionRepository(ApplicationDbContext context)
        {
            
            _context = context;

        }
       
        public void CreateAuction(Auction auction)
        {
            auction.StartDate = DateTime.UtcNow;
            
            _context.Add(auction);
            _context.SaveChanges();
        }

        public void DeleteAuctionById(Auction auction)
        {
            _context.Remove(auction);
        }

        public Auction GetAuctionById(int id)
        {
            return _context.Auctions.SingleOrDefault(a => a.Id == id);
        }

        public IQueryable<Auction> GetAuctions()
        {
            return _context.Auctions;
        }

        public IQueryable<Auction> GetAuctions(string SearchString)
        {
            return  _context.Auctions.Where(a => a.Name.IndexOf(SearchString, StringComparison.OrdinalIgnoreCase) >= 0);
        }

        
        public Auction Bid(int Id,double amount, User bidder)
        {
            var updatedAuction = _context.Auctions.FirstOrDefault(a => a.Id == Id);
            updatedAuction.Bids.Add(new Bid { Amount = amount, User = bidder });
            updatedAuction.Price = updatedAuction.Bids.Max(bid => bid.Amount);
            var entity = _context.Auctions.Attach(updatedAuction);
            entity.State = EntityState.Modified;
            _context.SaveChanges();
            return updatedAuction;
        }
        public Auction EndAuction(int Id)
        {
            User Winner;
            var updatedAuction = _context.Auctions.FirstOrDefault(a => a.Id == Id);
            Winner = updatedAuction.Bids.OrderByDescending(bid => bid.Amount).FirstOrDefault().User;
            updatedAuction.Winner = Winner;
            var entity = _context.Auctions.Attach(updatedAuction);
            entity.State = EntityState.Modified;
            _context.SaveChanges();
            return updatedAuction;
        }
        public Auction Update(Auction updatedAuction)
        {
            
            var entity = _context.Auctions.Attach(updatedAuction);
            entity.State = EntityState.Modified;
            return updatedAuction;
        }

        public IQueryable<Auction> FilterByCategory(string filterCategory)
        {
            return _context.Auctions.Where(a => a.Category == (Category)Enum.Parse(typeof(Category), filterCategory));
        }
    }
}
