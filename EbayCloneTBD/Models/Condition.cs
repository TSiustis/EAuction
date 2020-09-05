using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EAuction.Models
{
    public enum Condition
    {
        New,
        [Display(Name = "Like New")]
        LikeNew,
        Used
    }
}
