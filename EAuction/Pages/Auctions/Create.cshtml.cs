using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using EAuction.Data;
using EAuction.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using System.IO;
using Microsoft.AspNetCore.Hosting;

namespace EAuction.Pages.Auctions
{
    public class CreateModel : PageModel
    {
        private readonly ApplicationDbContext _context;
        private readonly SignInManager<EAuction.Models.User> _signInManager;
        private readonly UserManager<EAuction.Models.User> _userManager;
        private readonly IAuctionRepository _auctionRepository;
        private readonly IHtmlHelper htmlHelper;
        private readonly IWebHostEnvironment _hostingEnvironment;
        public int SelectedValue;
        public CategoryViewModel CategoriesVM { get; set; }
        [BindProperty(SupportsGet =true)]
        public IEnumerable<string> Categories { get; set; }
        public IEnumerable<SelectListItem> Countries { get; set; }
        public List<SelectListItem> CategoriesList { get; set; }
        [BindProperty]
        public IFormFile selectedFile { get; set; }
        public CreateModel(ApplicationDbContext context, IHtmlHelper htmlHelper,SignInManager<EAuction.Models.User> signInManager,IAuctionRepository auctionRepository, 
                        UserManager<EAuction.Models.User> userManager, IWebHostEnvironment hostingEnvironment)
        {
            _hostingEnvironment = hostingEnvironment;
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
                if (selectedFile != null && selectedFile.Length > 0)
            {
                var fileName = Path.GetFileName(selectedFile.FileName);
               // var filePath = Path.Combine(@"wwwroot\images", fileName);
                var filePath =  Path.Combine(_hostingEnvironment.WebRootPath, "images", fileName);
                using var fileStream = new FileStream(filePath, FileMode.Create);
               await selectedFile.CopyToAsync(fileStream);
            }
            var user = _userManager.GetUserAsync(User).GetAwaiter().GetResult();
            Auction.Seller = user;
            Auction.UrlImage = selectedFile.FileName;
            Auction.Category = (Category)Enum.Parse(typeof(Category), Categories.First(), true);
            _auctionRepository.CreateAuction(Auction);

            return RedirectToPage("./List");
        }
    }
}
