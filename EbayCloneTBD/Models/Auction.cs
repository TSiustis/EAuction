using EAuction.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EbayCloneTBD.Models
{
    public class Auction : IValidatableObject
    {

        public List<Bid> Bids { get; set; }
        private string name;
        [Required]
        public string Name
        {
            get { return name; }
            set { 
                if(!String.IsNullOrEmpty(value))
                name = value; 
            }
        }

        public int Id { get; set; }
        [Required]
        public Category Category { get; set; }
        public User Winner { get; set; }
        [Required]
        [StringLength(4000)]
        public string Details { get; set; }
        public string UrlImage { get; set; }
        [Required]
        public double Price { get; set; }
        public TimeSpan TimeLeft { get; set; }
        [Required]
        public DateTime StartDate { get; set; }
        [Required]
        public DateTime EndDate { get; set; }
        [Required]
        public Country Country { get; set; }
        public Condition Condition { get; set; }
        IEnumerable<ValidationResult> IValidatableObject.Validate(ValidationContext validationContext)
        {
            if (EndDate < StartDate)
            {
                yield return new ValidationResult("EndDate must be greater than StartDate");
            }
        }

       
    }
}
