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
        void CreateAction(Auction auction);
        Auction GetAuctionById(int id);
        void DeleteAuctionById(Auction Auction);
        IQueryable<Auction> GetAuctions(string SearchString);
    }
}
