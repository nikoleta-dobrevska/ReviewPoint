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
    public interface IBookService : IBaseDataService<Book, BookViewModel>
    {
        IEnumerable<BookViewModel> GetAllBooks();
        BookViewModel GetBook(Guid id);
        BookDetailsViewModel GetDetailsForBook(Guid id);
    }
}
