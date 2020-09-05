using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EbayCloneTBD.Models
{
    public class User
    {
        public int Id { get; set; }
        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string NickName { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string PostCode { get; set; }
        public Country Country { get; set; }
        public string City { get; set; }
        public double Feedback { get; set; }
    }
}
