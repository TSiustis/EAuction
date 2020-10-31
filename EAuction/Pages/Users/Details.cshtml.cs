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
using EAuction.Helpers;

namespace EAuction.Pages.Users
{
    public class DetailsModel : PageModel
    {
        private readonly IMessageRepository _messageRepository;
        private readonly CustomIDataProtection _customIDataProtection;
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;

        public DetailsModel(ApplicationDbContext context,
            UserManager<User> userManager,
            SignInManager<User> signInManager, CustomIDataProtection customIDataProtection,
            IMessageRepository messageRepository)
        {
            _messageRepository = messageRepository;
            _customIDataProtection = customIDataProtection;
            _context = context;
            _userManager = userManager;
            _signInManager = signInManager;
        }
        private readonly EAuction.Data.ApplicationDbContext _context;

        [BindProperty(SupportsGet =true)]
        public User MyUser { get; set; }
        [BindProperty]
        public Message Message { get; set; }

        public  IActionResult OnGetAsync(string? id)
        {
            ViewData["id"] = _customIDataProtection.Encode(id);
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
        public async Task<IActionResult> OnPostAsync(string Id)
        {
            //currently authenticated user
            string id;
            var sender = _userManager.GetUserAsync(User).GetAwaiter().GetResult();
            if (!HttpContext.User.Identity.IsAuthenticated)
            {
                return Redirect("/Identity/Account/Login");
            }
           
            MyUser = _userManager.FindByIdAsync(Id).GetAwaiter().GetResult();
            if(string.IsNullOrEmpty(Message.Subject) || string.IsNullOrEmpty(Message.MessageBody))
            {
                return Page();
            }
            _messageRepository.SendMessage(Message, MyUser, sender);

            return RedirectToPage("./Details", new { id = Id });
        }
    }
}
