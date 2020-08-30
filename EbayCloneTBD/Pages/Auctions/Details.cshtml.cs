using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Threading.Tasks;
using EbayCloneTBD.Data;
using EbayCloneTBD.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EAuction.Pages.Auctions
{
    public class DetailsModel : PageModel
    {
        private readonly ApplicationDbContext _applicationDbContext;
        private readonly IAuctionRepository _auctionRepository;
        public DetailsModel(ApplicationDbContext applicationDbContext, IAuctionRepository auctionRepository)

        {
            _applicationDbContext = applicationDbContext;
            _auctionRepository = auctionRepository;

        }
        public Auction Auction { get; set; }
        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
                return NotFound();
            int Id = (int)id;
            Auction =  _auctionRepository.GetAuctionById(Id);
            if (Auction == null)
                return NotFound();
            return Page();



        }
    }
}