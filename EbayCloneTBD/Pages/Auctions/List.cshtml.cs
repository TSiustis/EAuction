using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using EbayCloneTBD.Data;
using EbayCloneTBD.Models;

namespace EbayCloneTBD.Pages.Auctions
{
    public class ListModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        private readonly IAuctionRepository _auctionRepository;
        public string CurrentFilter { get; set; }
        [BindProperty(SupportsGet = true)]
        public string SearchString { get; set; }
        public List<Auction> Auctions { get; set; }
        public ListModel(ApplicationDbContext context, IAuctionRepository auctionRepository)
        {
            _auctionRepository = auctionRepository;
            _context = context;
        }

        public string NameSort { get; set; }
        public string DateSort { get; set; }
        public string CurrentSort { get; set; }

        public async Task OnGetAsync(string SearchString,string SortOrder)
        {

            Auctions = _auctionRepository.GetAuctions();
            CurrentFilter = SearchString;
            if(!string.IsNullOrEmpty(SearchString))
            {
                Auctions = _auctionRepository.GetAuctions(SearchString);
            }
            Auctions = _auctionRepository.SortAuctions(Auctions, SortOrder);
        }
    }
}
