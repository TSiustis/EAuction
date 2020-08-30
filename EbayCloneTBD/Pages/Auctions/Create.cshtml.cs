using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using EbayCloneTBD.Data;
using EbayCloneTBD.Models;

namespace EAuction.Pages.Auctions
{
    public class CreateModel : PageModel
    {
        private readonly EbayCloneTBD.Data.ApplicationDbContext _context;

        public CreateModel(EbayCloneTBD.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Auction Auction { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Auctions.Add(Auction);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
