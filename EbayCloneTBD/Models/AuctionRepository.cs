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
        public void CreateAction(Auction auction)
        {
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
            return _context.Auctions.Where(a => a.Name.IndexOf(SearchString, StringComparison.OrdinalIgnoreCase) >= 0);
        }
    }
}
