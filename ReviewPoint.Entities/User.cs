using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace ReviewPoint.Entities
{
    public class User : IdentityUser
    {
        public ICollection<Review> Reviews { get; set; }
    }
}
