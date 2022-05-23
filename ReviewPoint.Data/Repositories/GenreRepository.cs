using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ReviewPoint.Entities;
using Microsoft.EntityFrameworkCore;

namespace ReviewPoint.Data.Repositories
{
    public class GenreRepository : BaseRepository<Genre>, IGenreRepository
    {
        public GenreRepository(ReviewPointDbContext context) : base(context)
        { }
    }
}
