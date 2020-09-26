using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EAuction.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EAuction.Pages.Bids
{
    public class IndexModel : PageModel
    {
        IAuctionRepository _auctionRepository;
        public IndexModel(IAuctionRepository auctionRepository)
            
        {
            _auctionRepository = auctionRepository;

        }
        [BindProperty]
        public Auction Auction { get; set; }
        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
                return NotFound();
            int Id = (int)id;
            Auction = _auctionRepository.GetAuctionById(Id);

            if (Auction == null)
                return NotFound();

            return Page();



        }
    }
}