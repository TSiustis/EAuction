using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using EbayCloneTBD.Data;
using EbayCloneTBD.Models;
using EAuction.Models;

namespace EbayCloneTBD.Pages.Auctions
{
    public class ListModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        private readonly IAuctionRepository _auctionRepository;
        public string CurrentFilter { get; set; }
        [BindProperty(SupportsGet = true)]
        public string SearchString { get; set; }
        public PaginatedList<Auction> Auctions { get; set; }
        public ListModel(ApplicationDbContext context, IAuctionRepository auctionRepository)
        {
            _auctionRepository = auctionRepository;
            _context = context;
        }

        public string NameSort { get; set; }
        public string DateSort { get; set; }
        public string CurrentSort { get; set; }
        public IQueryable<Auction> AuctionsIQ { get; private set; }

        public async Task OnGetAsync(string SortOrder,
            string currentFilter, string SearchString, int? pageIndex)
        {
            CurrentSort = SortOrder;
            AuctionsIQ = _auctionRepository.GetAuctions();
            if (SearchString != null)
            {
                pageIndex = 1;
            }
            else
            {
                SearchString = currentFilter;
            }
            if (!string.IsNullOrEmpty(SearchString))
            {
                AuctionsIQ = _auctionRepository.GetAuctions(SearchString);
            }
           NameSort = String.IsNullOrEmpty(SortOrder) ? "name_desc" : "";
           DateSort = SortOrder == "Date" ? "date_desc" : "Date";
            switch (SortOrder)
            {
                case "date_asc":
                    AuctionsIQ = AuctionsIQ.OrderBy(s => s.EndDate);
                    break;
                case "date_desc":
                    AuctionsIQ = AuctionsIQ.OrderByDescending(s => s.EndDate);
                    break;
                case "price_asc":
                    AuctionsIQ = AuctionsIQ.OrderBy(s => s.Price);
                    break;
                case "price_desc":
                    AuctionsIQ = AuctionsIQ.OrderByDescending(s => s.Price);
                    break;
                default:
                    AuctionsIQ = AuctionsIQ.OrderBy(s => s.Name);
                    break;
            }
            int pageSize = AuctionsIQ.Count();

            Auctions =  await PaginatedList<Auction>.CreateAsync(
                AuctionsIQ, pageIndex ?? 1, pageSize);
        }
    }
}
