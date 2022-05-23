using ReviewPoint.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReviewPoint.Business.ViewModels
{
   public class BookDetailsViewModel
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public int Pages { get; set; }
        public string ISBN { get; set; }
        public string FrontCoverImageUrl { get; set; }
        public Guid GenreId { get; set; }
        public Genre Genre { get; set; }
        public Guid AuthorId { get; set; }
        public Author Author { get; set; }
        public IEnumerable<ReviewViewModel> Reviews { get; set; }
    }
}
