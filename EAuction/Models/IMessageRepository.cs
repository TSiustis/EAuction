using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EAuction.Models
{
    public interface IMessageRepository
    {
        void SendMessage(Message Message);
        List<Message> GetAllConversationsForUser(User User);
        int GetNewMessagesCount(int userId);
        void SetMessageViewed(int messageId);
        void SendMessage(Message Message, User receiver, User sender);
        
    }
}
