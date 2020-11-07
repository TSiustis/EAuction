using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EAuction.Models
{
    public class Bid 
    {
        public int Id { get; set; }
        [Required]
        public double Amount { get; set; }
        public virtual User User { get; set; }
      
    }
}