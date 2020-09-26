using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using EAuction.Data;
using EAuction.Models;

namespace EAuction.Pages.Auctions
{
    public class ListModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        private readonly IAuctionRepository _auctionRepository;
        public string CurrentFilter { get; set; }
        [BindProperty]
        public string selectedDropdown { get; set; }
        [BindProperty(SupportsGet = true)]
        public string SearchString { get; set; }
        [BindProperty(SupportsGet = true)]
        public HashSet<Category> Categories { get; set; }
        public PaginatedList<Auction> Auctions { get; set; }
        public ListModel(ApplicationDbContext context, IAuctionRepository auctionRepository)
        {
            _auctionRepository = auctionRepository;
          
            _context = context;
        }

        public string FilterCategory { get; set; }
        public string NameSort { get; set; }
        public string DateSort { get; set; }
        public string CurrentSort { get; set; }
        public IQueryable<Auction> AuctionsIQ { get; private set; }

        public async Task OnGetAsync(string SortOrder,
            string currentFilter, string SearchString, int? pageIndex, string FilterCategory)
        {
            CurrentSort = SortOrder;
            AuctionsIQ =  _auctionRepository.GetAuctions();
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
                AuctionsIQ =  _auctionRepository.GetAuctions(SearchString);
            }
            if (!string.IsNullOrEmpty(FilterCategory))
            {
                AuctionsIQ = _auctionRepository.FilterByCategory(FilterCategory);
            }
            selectedDropdown = "Best Match";
            NameSort = String.IsNullOrEmpty(SortOrder) ? "name_desc" : "";
           DateSort = SortOrder == "Date" ? "date_desc" : "Date";
            switch (SortOrder)
            {
                case "date_asc":
                    AuctionsIQ = AuctionsIQ.OrderBy(s => s.EndDate);
                    selectedDropdown = "Ending First";
                    break;
                case "date_desc":
                    AuctionsIQ = AuctionsIQ.OrderByDescending(s => s.EndDate);
                    selectedDropdown = "Ending Last";
                    break;
                case "price_asc":
                    AuctionsIQ = AuctionsIQ.OrderBy(s => s.Price);
                    selectedDropdown = "Lowest Price";
                    break;
                case "price_desc":
                    AuctionsIQ = AuctionsIQ.OrderByDescending(s => s.Price);
                    selectedDropdown = "Highest Price";
                    break;
                default:
                    AuctionsIQ = AuctionsIQ.OrderBy(s => s.Name);
                    selectedDropdown = "Best Match";
                    break;
            }
            int pageSize = AuctionsIQ.Count();
            Auctions =  await PaginatedList<Auction>.CreateAsync(
                AuctionsIQ, pageIndex ?? 1, pageSize);

            foreach (var item in Auctions)
                Categories.Add(item.Category);
        }
    }
}
