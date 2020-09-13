using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EbayCloneTBD.Models
{
    public class User : IdentityUser
    {
        [PersonalData]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        [PersonalData]
        [Display(Name =  "Last Name")]
        public string LastName { get; set; }

        public string NickName { get; set; }
        [PersonalData]
        public string Address { get; set; }
        [PersonalData]
        public string PostCode { get; set; }
        [PersonalData]
        public Country Country { get; set; }
        [PersonalData]
        public string City { get; set; }
        public double Feedback { get; set; }
    }
}
