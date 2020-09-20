using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EbayCloneTBD.Models
{
    public class Bid 
    {
        public int Id { get; set; }
        public double Amount { get; set; }
        public virtual User User { get; set; }
      
    }
}