using ReviewPoint.Business.ViewModels;
using ReviewPoint.Entities;
using ReviewPoint.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReviewPoint.Business.Services.Interfaces
{
    public interface IReviewService : IBaseDataService<Review, ReviewViewModel>
    {
        IEnumerable<ReviewViewModel> GetAllReviews();
        ReviewViewModel GetReview(Guid id);
        IEnumerable<ReviewViewModel> GetReviewsForBook(Guid bookId);
    }
}
