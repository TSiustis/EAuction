using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using EbayCloneTBD.Data;
using EbayCloneTBD.Models;
using EAuction.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;

namespace tf_with.Pages.Auctions
{
    public class CreateModel : PageModel
    {
        private readonly EbayCloneTBD.Data.ApplicationDbContext _context;
        private readonly SignInManager<User> _signInManager;
        private readonly UserManager<User> _userManager;
        private readonly IAuctionRepository _auctionRepository;
        private readonly IHtmlHelper htmlHelper;
        public int SelectedValue;
        public CategoryViewModel CategoriesVM { get; set; }
        [BindProperty(SupportsGet =true)]
        public IEnumerable<string> Categories { get; set; }
        public IEnumerable<SelectListItem> Countries { get; set; }
        public List<SelectListItem> CategoriesList { get; set; }
        public CreateModel(ApplicationDbContext context, IHtmlHelper htmlHelper,SignInManager<User> signInManager,IAuctionRepository auctionRepository, UserManager<User> userManager)
        {
            _userManager = userManager;
            _auctionRepository = auctionRepository;
            _signInManager = signInManager;
            CategoriesVM = new CategoryViewModel();
            _context = context;
            this.htmlHelper = htmlHelper;
        }

        public async Task<IActionResult> OnGetAsync()
        {
            Countries = htmlHelper.GetEnumSelectList<Country>();

            CategoriesList = CategoriesVM.Categories;
            return Page();
        }

        [BindProperty]
        public Auction Auction { get; set; }

        public async Task<IActionResult> OnPostAsync(string selectedValue)
        {
            if (!HttpContext.User.Identity.IsAuthenticated)
            {
                return Redirect("/Identity/Account/Login");
            }
            if (!ModelState.IsValid)
            {
                Countries = htmlHelper.GetEnumSelectList<Country>();

                CategoriesList = CategoriesVM.Categories;
                return Page();
            }
            var user = _userManager.GetUserAsync(User).GetAwaiter().GetResult();
            Auction.Seller = user;
            Auction.Category = (Category)Enum.Parse(typeof(Category), Categories.First(), true);
            _auctionRepository.CreateAuction(Auction);

            return RedirectToPage("./List");
        }
    }
}
