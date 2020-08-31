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
                new Auction{Id = 2, Name = "Rare Coin" , Details = "4th Century Coin ", StartDate = new DateTime(2020,8,29), EndDate = new DateTime(2020,9,3), Price = 300},
                new Auction{Id = 3, Name = "Authentic Sword 16th Century" , Details = "Authentic Sword from 16th Century Bavaria", StartDate = new DateTime(2020,8,29), EndDate = new DateTime(2020,9,3), Price = 2999}


            };
        }
        public void CreateAction()
        {
            throw new NotImplementedException();
        }

        public void Delettf_withById()
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

        public void Updattf_with()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Auction> GetAuctions(string SearchString)
        {
            return Auctions.Where(a => a.Name.IndexOf(SearchString, StringComparison.OrdinalIgnoreCase) >= 0);
        }

        public IEnumerable<Auction> SortAuctions(IEnumerable<Auction> auctions,string SortOrder)
        {
           string NameSort = String.IsNullOrEmpty(SortOrder) ? "name_desc" : "";
           string  DateSort = SortOrder == "Date" ? "date_desc" : "Date";
            switch (SortOrder)
            {
                case "name_desc":
                    auctions = auctions.OrderByDescending(s => s.Name);
                    break;
                case "Date":
                    auctions = auctions.OrderBy(s => s.EndDate);
                    break;
                case "date_desc":
                    auctions = auctions.OrderByDescending(s => s.EndDate);
                    break;
                default:
                    auctions = auctions.OrderBy(s => s.Name);
                    break;
            }
            return auctions;
        }
    }
}
