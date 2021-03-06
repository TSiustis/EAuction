﻿using EAuction.Data;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
namespace EAuction.Models
{
    public class MessageRepository : IMessageRepository
    {
        private readonly ApplicationDbContext _context;

        public MessageRepository(ApplicationDbContext context)
        {

            _context = context;

        }
        public List<Message> GetMessagesById(int id)
        {
            return _context.Messages.Where(m => m.Id == id || m.ParentId == id).ToList();
        }
        public List<Message> GetAllConversationsForUserExceptFirst(User User)
        {
            return _context.Messages.Where(m =>m.Receiver == User && m.ParentId !=0).ToList();
        }
        public List<Message> GetFirstMessageForUser(User User)
        {
            return _context.Messages.Where(m => m.Receiver == User && m.ParentId == 0).ToList();
        }
      

        public void SendMessage(Message Message, User receiver,User sender)
        {
            var prevMessage = _context.Messages.Where(p => (p.Receiver == receiver && p.Sender == sender)
                    || (p.Receiver== sender && p.Sender == receiver)).FirstOrDefault();

           Message.Subject =prevMessage != null ? prevMessage.Subject : Message.Subject;
            Message.ParentId = prevMessage == null? 0 :  prevMessage.Id;
            Message.CreatedAt = DateTime.UtcNow;
            Message.Sender = sender;
            Message.Receiver = receiver;
            _context.Messages.Add(Message);
            _context.SaveChanges();

        }

     
    

   
    }
}
