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

namespace tf_with.Pages.Auctions
{
    public class CreateModel : PageModel
    {
        private readonly EbayCloneTBD.Data.ApplicationDbContext _context;
        private readonly IHtmlHelper htmlHelper;
        public int SelectedValue;
        public CategoryViewModel CategoriesVM { get; set; }
        [BindProperty(SupportsGet =true)]
        public IEnumerable<string> Categories { get; set; }
        public IEnumerable<SelectListItem> Countries { get; set; }
        public List<SelectListItem> CategoriesList { get; set; }
        public CreateModel(ApplicationDbContext context, IHtmlHelper htmlHelper)
        {
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

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync(string selectedValue)
        {
            if (!ModelState.IsValid)
            {
                Countries = htmlHelper.GetEnumSelectList<Country>();

                CategoriesList = CategoriesVM.Categories;
                return Page();
            }
            Auction.Category = (Category)Enum.Parse(typeof(Category), Categories.First(), true);
            _context.Auctions.Add(Auction);
            await _context.SaveChangesAsync();

            return RedirectToPage("./List");
        }
    }
}
