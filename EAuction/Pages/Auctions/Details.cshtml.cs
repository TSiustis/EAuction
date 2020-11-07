using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Threading.Tasks;
using EAuction.Data;
using EAuction.Helpers;
using EAuction.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EAuction.Pages.Auctions
{
    public class DetailsModel : PageModel
    {
        private readonly ApplicationDbContext _applicationDbContext;

        private readonly CustomIDataProtection _customIDataProtection;
        public readonly SignInManager<EAuction.Models.User> _signInManager;

        private readonly UserManager<EAuction.Models.User> _userManager;
        private readonly IAuctionRepository _auctionRepository;
        public DetailsModel(ApplicationDbContext applicationDbContext, IAuctionRepository auctionRepository,
                        SignInManager<EAuction.Models.User> signInManager,UserManager<EAuction.Models.User> userManager,
                        CustomIDataProtection customIDataProtection)

        {
            _customIDataProtection = customIDataProtection;
            _userManager = userManager;
            _signInManager = signInManager;
            _applicationDbContext = applicationDbContext;
            _auctionRepository = auctionRepository;

        }
        [BindProperty]
        public TimeSpan TimeLeft { get; set; }
        [BindProperty]
        public Auction Auction { get; set; }
        [BindProperty]
        public double Amount { get; set; }
        [BindProperty]
        public string Error { get; set; }
        [BindProperty]
        public int NoOfBids { get; set; }
        public string EncryptedId { get; set; }
        public async Task<IActionResult> OnGetAsync(int? id)
        {

            if (id == null)
                return NotFound();
            int Id = (int)id;
            Auction =  _auctionRepository.GetAuctionById(Id);

            if (Auction == null)
                return NotFound();

            EncryptedId = _customIDataProtection.Encode(Auction.Seller.Id);
            TimeLeft = Auction.EndDate - Auction.StartDate;
            NoOfBids = Auction.Bids.Count();

            return  Page();



        }
        public async Task<IActionResult> OnPostAsync(int id)
        {
            if (!HttpContext.User.Identity.IsAuthenticated)
            {
                return Redirect("/Identity/Account/Login");
            }
            //if (!ModelState.IsValid)
            //{
            //    return Page();
            //}
            int Id = (int)id;
            Auction = _auctionRepository.GetAuctionById(Id);
            var currentBid = Auction.Bids.Select(bid=>bid.Amount)
                                          .DefaultIfEmpty()
                                          .Max();
            if(Amount == 0)
            {
                Error = "Please enter a value!";
                TimeLeft = Auction.EndDate - Auction.StartDate;
                return Page();
            }
            NoOfBids = Auction.Bids.Count();
            if (Amount < currentBid)
            {
                Error = "Your bid must be higher than the last bid!";

                TimeLeft = Auction.EndDate - Auction.StartDate;
                return Page();
            }
            var user = _userManager.GetUserAsync(User).GetAwaiter().GetResult();
            _auctionRepository.Bid(Auction.Id,Amount,user );

            return RedirectToPage("./Details", new {id = Id});
        }
    }
}