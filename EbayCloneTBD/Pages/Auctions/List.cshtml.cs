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
        private readonly EbayCloneTBD.Data.ApplicationDbContext _context;
        private readonly IAuctionRepository _auctionRepository;
        public IEnumerable<Models.Auction> Auctions { get; set; }
        public ListModel(EbayCloneTBD.Data.ApplicationDbContext context, IAuctionRepository auctionRepository)
        {
            _auctionRepository = auctionRepository;
            _context = context;
        }


        public async Task OnGetAsync()
        {
            Auctions = _auctionRepository.GetAuctions();
        }
    }
}
