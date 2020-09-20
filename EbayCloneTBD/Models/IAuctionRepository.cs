using EAuction.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EbayCloneTBD.Models
{
    public interface IAuctionRepository
    {
       IQueryable<Auction> GetAuctions();
        void CreateAuction(Auction auction);
        Auction GetAuctionById(int id);
        void DeleteAuctionById(Auction Auction);
        IQueryable<Auction> GetAuctions(string SearchString);
        Auction Update(Auction updatedAuction);
        Auction Bid(int Id, double amount, User bidder);
        Auction EndAuction(int Id);
        IQueryable<Auction> FilterByCategory(string filterCategory);
    }
}
