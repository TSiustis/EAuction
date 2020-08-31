using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EbayCloneTBD.Models
{
    public interface IAuctionRepository
    {
        IEnumerable<Auction> GetAuctions();
        void CreateAction();
        Auction GetAuctionById(int id);
        void Updattf_with();
        void Delettf_withById();
        IEnumerable<Auction> GetAuctions(string SearchString);
        IEnumerable<Auction> SortAuctions(IEnumerable<Auction> auctions,string SortOrder);
    }
}
