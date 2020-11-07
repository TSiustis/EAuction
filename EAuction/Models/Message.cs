using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EAuction.Models
{
    public class Message
    {
        public int Id { get; set; }
        public string Subject { get; set; }

        [Required]
        [Display(Name ="Message: ")]
        public string MessageBody { get; set; }
        public int ParentId { get; set; }
        public bool IsViewed { get; set; }
        public virtual User Sender { get; set; }
        public virtual User Receiver { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime ViewedAt { get; set; }
    }
}
