using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReviewPoint.Entities
{
   public class Author : BaseEntity
    {
        [Required]
        public string Name { get; set; }
        public ICollection<Book> Books { get; set; }

    }
}
