using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ReviewPoint.Entities;
using Microsoft.EntityFrameworkCore;

namespace ReviewPoint.Data.Repositories
{
    public class AuthorRepository : BaseRepository<Author>, IAuthorRepository
    {
        public AuthorRepository(ReviewPointDbContext context) : base(context)
        {
        }
    }
}
