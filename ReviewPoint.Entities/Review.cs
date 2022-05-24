using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace ReviewPoint.Entities
{
   public class Review : BaseEntity
   {
        public Review()
        {
            this.Timestamp = DateTime.Now;
        }
        [Required]
        public string Content { get; set; }
        [Required]
        public int Grade { get; set; }
        public string UserId { get; set; }
        public User User { get; set; }
        public Guid BookId { get; set; }
        public Book Book { get; set; }
        public DateTime Timestamp { get; set; }

   }
}
