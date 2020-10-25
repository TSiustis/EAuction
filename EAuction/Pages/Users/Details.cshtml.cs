using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using EAuction.Data;
using EAuction.Models;
using Microsoft.AspNetCore.Identity;

namespace EAuction.Pages.Users
{
    public class DetailsModel : PageModel
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;

        public DetailsModel(ApplicationDbContext context,
            UserManager<User> userManager,
            SignInManager<User> signInManager)
        {
            _context = context;
            _userManager = userManager;
            _signInManager = signInManager;
        }
        private readonly EAuction.Data.ApplicationDbContext _context;

        [BindProperty(SupportsGet =true)]
        public User MyUser { get; set; }


        public  IActionResult OnGetAsync(string? id)
        {
            if (id == null)
            {
                return NotFound();
            }
             MyUser =  _userManager.FindByIdAsync(id).GetAwaiter().GetResult();

            if (MyUser == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
