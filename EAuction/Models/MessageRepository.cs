using EAuction.Data;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
namespace EAuction.Models
{
    public class MessageRepository : IMessageRepository
    {
        private readonly ApplicationDbContext _context;

        private readonly List<Message> messageHistory = new List<Message>();
        public MessageRepository(ApplicationDbContext context)
        {

            _context = context;

        }
        public List<Message> GetAllConversationsForUser(User User)
        {
            return _context.Messages.Where(m =>m.Sender == User).ToList();
        }

        public int GetNewMessagesCount(int userId)
        {
            throw new NotImplementedException();
        }

        public void SendMessage(Message Message, User receiver,User sender)
        {
            var prevMessage = _context.Messages.Where(p => (p.Receiver == receiver && p.Sender == sender)
                    || (p.Receiver== sender && p.Sender == receiver)).FirstOrDefault();

            if (prevMessage != null)
            {
                Message.ParentId = prevMessage.Id;
               
            }
            Message.Sender = sender;
            Message.Receiver = receiver;
            _context.Messages.Add(Message);
            _context.SaveChanges();

        }
        private void GetChildMessages(int messageId, List<Message> lsMessages, int currentUserId)
        {
            var childMsg = lsMessages.FirstOrDefault(p => p.ParentId == messageId);
        if (childMsg != null)
            {
                messageHistory.Add(childMsg);
                GetChildMessages(childMsg.Id, lsMessages, currentUserId);
            }
        }
    

    public void SendMessage(Message Message)
        {
            throw new NotImplementedException();
        }

        public void SetMessageViewed(int messageId)
        {
            throw new NotImplementedException();
        }
    }
}
