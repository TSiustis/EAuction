using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EbayCloneTBD.Data;
using EbayCloneTBD.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace EbayCloneTBD.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        private readonly IAuctionRepository _auctionRepository;
        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger,IAuctionRepository auctionRepository, ApplicationDbContext context)
        {
            _logger = logger;
            _auctionRepository = auctionRepository;

            _context = context;
        }
        public List<Auction> Auctions { get; set; }
        public void OnGet()
        {
            Auctions = _auctionRepository.GetAuctions().ToList();
        }
    }
}
