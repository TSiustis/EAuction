using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EAuction.Data;
using EAuction.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EAuction.Pages.Users
{
    public class MessagesModel : PageModel
    {
        private readonly UserManager<EAuction.Models.User> _userManager;
        private readonly ApplicationDbContext _context;
        private readonly IMessageRepository _messageRepository;

         public string? MessageSubject;
        [BindProperty(SupportsGet =true)]
        public List<Message> Messages { get; set; }
        [BindProperty]
        public Message Message { get; set; }
        public MessagesModel(ApplicationDbContext context, IMessageRepository messageRepository, UserManager<EAuction.Models.User> userManager)
        {
            _messageRepository = messageRepository;
            _userManager = userManager;
            _context = context;
        }
        public IActionResult OnGet()
        {
            var user = _userManager.GetUserAsync(User).GetAwaiter().GetResult();
            Messages = _messageRepository.GetAllConversationsForUser(user);
            if (Messages.FirstOrDefault() != null)
            {
                MessageSubject = Messages.FirstOrDefault().ToString();
            }
                return Page();
        }
        public IActionResult OnPost()
        {

            var user = _userManager.GetUserAsync(User).GetAwaiter().GetResult();
            if (!ModelState.IsValid)
            {
                Messages = _messageRepository.GetAllConversationsForUser(user);

                MessageSubject = Messages[1].Subject;
                return Page();
            }
            
            _messageRepository.SendMessage(Message,user,user);

            Messages = _messageRepository.GetAllConversationsForUser(user);
            Message.MessageBody = "";
            return Page();
        }
    }
}