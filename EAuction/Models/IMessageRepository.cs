using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EAuction.Models
{
    public interface IMessageRepository
    {
        void SendMessage(Message Message, User receiver, User sender);
        List<Message> GetAllConversationsForUserExceptFirst(User User);
        List<Message> GetFirstMessageForUser(User User);
        List<Message> GetChildMessages(int messageId, List<Message> Messages);
    }
}
