using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace ReviewPoint.Entities
{
    public class Genre : BaseEntity
    {
        [Required]
        public string Name { get; set; }
        public ICollection<Book> Books { get; set; }
    }
}
