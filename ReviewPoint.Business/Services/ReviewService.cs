using AutoMapper;
using ReviewPoint.Business.Services.Interfaces;
using ReviewPoint.Business.ViewModels;
using ReviewPoint.Data.Repositories;
using ReviewPoint.Entities;
using ReviewPoint.Service;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReviewPoint.Business.Services
{
    public class ReviewService : BaseDataService<Review, ReviewViewModel, IReviewRepository>, IReviewService
    {
        public ReviewService(IReviewRepository repository, IMapper mapper) : base(repository, mapper)
        {

        }
        public IEnumerable<ReviewViewModel> GetAllReviews()
        {
            var reviews = this.repository.GetAll().Include(r => r.Book).Include(r => r.User).Select(r => new ReviewViewModel
            {
                Id=r.Id,
                Content=r.Content,
                Grade=r.Grade,
                BookId=r.BookId,
                Book=r.Book,
                UserId=r.UserId,
                User=r.User,
                Timestamp=r.Timestamp
            });
            return reviews;
        }
        public ReviewViewModel GetReview(Guid id)
        {
            var review = this.repository.GetAll().Include(r => r.Book).Include(r => r.User).Select(r => new ReviewViewModel
            {
                Id = r.Id,
                Content = r.Content,
                Grade = r.Grade,
                BookId = r.BookId,
                Book = r.Book,
                UserId = r.UserId,
                User = r.User,
                Timestamp=r.Timestamp
            }).Where(r => r.Id == id).SingleOrDefault();
            return review;
        }

        public IEnumerable<ReviewViewModel> GetReviewsForBook(Guid bookId)
        {
            var reviews = this.repository.GetAll().Include(r => r.Book).Include(r => r.User).Where(r => r.BookId == bookId).Select(r => new ReviewViewModel
            {
                Id = r.Id,
                Content = r.Content,
                Grade = r.Grade,
                UserId = r.UserId,
                User = r.User,
                Timestamp=r.Timestamp
            });
            return reviews;
        }
    }
}
