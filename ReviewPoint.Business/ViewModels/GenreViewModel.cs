using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReviewPoint.Business.ViewModels
{
    public class GenreViewModel
    {
        public Guid Id { get; set; }
        [Required]
        public string Name { get; set; }
    }
}
