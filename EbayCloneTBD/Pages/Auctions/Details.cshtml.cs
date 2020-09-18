using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Threading.Tasks;
using EbayCloneTBD.Data;
using EbayCloneTBD.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace tf_with.Pages.Auctions
{
    public class DetailsModel : PageModel
    {
        private readonly ApplicationDbContext _applicationDbContext;

        public readonly SignInManager<User> _signInManager;
        private readonly IAuctionRepository _auctionRepository;
        public DetailsModel(ApplicationDbContext applicationDbContext, IAuctionRepository auctionRepository,SignInManager<User> signInManager)

        {
            _signInManager = signInManager;
            _applicationDbContext = applicationDbContext;
            _auctionRepository = auctionRepository;

        }
        public TimeSpan TimeLeft { get; set; }
        [BindProperty]
        public Auction Auction { get; set; }
        public new User User{get; set; }
        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
                return NotFound();
            int Id = (int)id;
            Auction =  _auctionRepository.GetAuctionById(Id);

            if (Auction == null)
                return NotFound();
            TimeLeft = Auction.EndDate - Auction.StartDate;

            return  Page();



        }
    }
}