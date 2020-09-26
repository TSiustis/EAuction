using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EAuction.Models;
using EAuction.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EAuction.Pages.Users
{
    public class WonModel : PageModel
    {
       
            private readonly UserManager<EAuction.Models.User> _userManager;
            private readonly ApplicationDbContext _context;
            private readonly IAuctionRepository _auctionRepository;

            public IQueryable<Auction> AuctionsIQ { get; private set; }
            public PaginatedList<Auction> Auctions { get; set; }
            public WonModel(ApplicationDbContext context, IAuctionRepository auctionRepository, UserManager<EAuction.Models.User> userManager)
            {
                _auctionRepository = auctionRepository;
                _userManager = userManager;
                _context = context;
            }

            public async Task OnGetAsync(int? pageIndex)
            {
                var user = _userManager.GetUserAsync(User).GetAwaiter().GetResult();
                AuctionsIQ = _auctionRepository.GetAuctions().Where(a => a.Winner == user);
                int pageSize = AuctionsIQ.Count();
                Auctions = await PaginatedList<Auction>.CreateAsync(
                    AuctionsIQ, pageIndex ?? 1, pageSize);
            }
        }
}