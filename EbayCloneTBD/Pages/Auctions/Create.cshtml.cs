using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using EbayCloneTBD.Data;
using EbayCloneTBD.Models;
using tf_with.Models;

namespace tf_with.Pages.Auctions
{
    public class CreateModel : PageModel
    {
        private readonly EbayCloneTBD.Data.ApplicationDbContext _context;
        private readonly IHtmlHelper htmlHelper;
        public int SelectedValue;

        public IEnumerable<SelectListItem> Countries { get; set; }
        public IEnumerable<SelectListItem> Countries2 { get; set; }
        public CreateModel(ApplicationDbContext context, IHtmlHelper htmlHelper)
        {
            _context = context;
            this.htmlHelper = htmlHelper;
        }

        public async Task<IActionResult> OnGetAsync()
        {
            Countries = htmlHelper.GetEnumSelectList<SimpleCategory>();
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
                return Page();
            }
            string result = Enum.GetName(typeof(SimpleCategory), Int32.Parse(selectedValue));

            _context.Auctions.Add(Auction);
            await _context.SaveChangesAsync();

            return RedirectToPage("./List");
        }
    }
}
