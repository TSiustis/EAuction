using EbayCloneTBD.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EbayCloneTBD.Models
{
    public class Auction
    {

        public IEnumerable<Bid> Bids { get; set; }
        private string name;

        public string Name
        {
            get { return name; }
            set { 
                if(!String.IsNullOrEmpty(value))
                name = value; 
            }
        }

        public int Id { get; set; }

        public Category Category { get; set; }
        public string Winner { get; set; }
        public string Details { get; set; }
        public string UrlImage { get; set; }
        public double Price { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }



    }
}
