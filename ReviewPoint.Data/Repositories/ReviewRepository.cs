using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ReviewPoint.Entities;
using Microsoft.EntityFrameworkCore;

namespace ReviewPoint.Data.Repositories
{
    public class ReviewRepository : BaseRepository<Review>, IReviewRepository
    {
        public ReviewRepository(ReviewPointDbContext context) : base(context)
        {
        }

        public async Task<ICollection<Review>> GetAllReviewsByUserId(string userId)
        {
            return await context.Reviews.Where(r => r.UserId == userId).ToListAsync();
        }
    }
}
