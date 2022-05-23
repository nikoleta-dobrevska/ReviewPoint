using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace ReviewPoint.Entities
{
    public class Book : BaseEntity
    {
        public Book()
        {
            this.DateOfPublishing = DateTime.Now;
        }

        public string Title { get; set; }
        public int Pages { get; set; }
        public DateTime DateOfPublishing { get; set;}
        public string ISBN { get; set; }
        public string FrontCoverImageUrl { get; set; }
        public Guid GenreId { get; set; }
        public Genre Genre { get; set; }
        public Guid AuthorId { get; set; }
        public Author Author { get; set; }
        public ICollection<Review> Reviews { get; set; }



    }
}
