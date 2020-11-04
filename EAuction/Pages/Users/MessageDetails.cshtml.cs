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
    public class MessageDetailsModel : PageModel
    {
        private readonly UserManager<EAuction.Models.User> _userManager;
        private readonly ApplicationDbContext _context;
        private readonly IMessageRepository _messageRepository;

        public string? MessageSubject;
        [BindProperty(SupportsGet = true)]
        public List<Message> Messages { get; set; }
        [BindProperty]
        public Message Message { get; set; }
        [BindProperty(SupportsGet = true)]
        public List<Message> FirstMessage { get; set; }
        public MessageDetailsModel(ApplicationDbContext context, IMessageRepository messageRepository, UserManager<User> userManager)
        {
            _messageRepository = messageRepository;
            _userManager = userManager;
            _context = context;
        }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            var user = _userManager.GetUserAsync(User).GetAwaiter().GetResult();
            Messages = _messageRepository.GetMessagesById(id);
           
            if (Messages.FirstOrDefault() != null)
            {
                MessageSubject = Messages.FirstOrDefault().Subject;
            }
            if (Messages == null)
            {
                return NotFound();
            }


           
            return Page();
        }
        public IActionResult OnPost(int id)
        {

            var user = _userManager.GetUserAsync(User).GetAwaiter().GetResult();
            if (!ModelState.IsValid)
            {
                Messages = _messageRepository.GetMessagesById(id);

                MessageSubject = Messages[0].Subject;
                return Page();
            }

            Messages = _messageRepository.GetMessagesById(id);
            _messageRepository.SendMessage(Message, Messages[0].Sender, user);

            Message.MessageBody = "";
            return Page();
        }
    }
}
