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
        void UpdateAuction();
        void DeleteAuctionById();
    }
}
