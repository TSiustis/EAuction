using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EbayCloneTBD.Models
{
    public interface IAuctionRepository
    {
        List<Auction> GetAuctions();
        void CreateAction();
        Auction GetAuctionById(int id);
        void DeleteAuctionById();
        List<Auction> GetAuctions(string SearchString);
        List<Auction> SortAuctions(List<Auction> auctions, string SortOrder);
    }
}
