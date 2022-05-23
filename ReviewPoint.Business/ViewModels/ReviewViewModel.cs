using ReviewPoint.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReviewPoint.Business.ViewModels
{
    public class ReviewViewModel
    {
        public Guid Id { get; set; }
        [Required]
        public string Content { get; set; }
        [Required]
        [Range(1, 10, ErrorMessage = "Value for {0} must be between {1} and {2}.")]
        public int Grade { get; set; }
        public string UserId { get; set; }
        public User User { get; set; }
        public Guid BookId { get; set; }
        public Book Book { get; set; }
        public DateTime Timestamp { get; set; }

    }
}
