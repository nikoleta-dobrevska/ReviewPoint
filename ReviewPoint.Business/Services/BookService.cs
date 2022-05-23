using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ReviewPoint.Business.Services.Interfaces;
using ReviewPoint.Business.ViewModels;
using ReviewPoint.Data.Repositories;
using ReviewPoint.Entities;
using ReviewPoint.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReviewPoint.Business.Services
{
    public class BookService : BaseDataService<Book, BookViewModel, IBookRepository>, IBookService
    {
        public BookService(IBookRepository repository, IMapper mapper) : base(repository, mapper)
        {

        }

        public IEnumerable<BookViewModel> GetAllBooks()
        {
            var books = this.repository.GetAll().Include(b => b.Genre).Include(b => b.Author).Select(b => new BookViewModel
            {
                Id = b.Id,
                Title = b.Title,
                Pages = b.Pages,
                ISBN = b.ISBN,
                FrontCoverImageUrl=b.FrontCoverImageUrl,
                GenreId = b.GenreId,
                Genre = b.Genre,
                AuthorId = b.AuthorId,
                Author = b.Author
            }); 
            return books;
        }

        public BookViewModel GetBook(Guid id)
        {
            var book = this.repository.GetAll().Include(b => b.Genre).Include(b => b.Author).Select(b => new BookViewModel
            {
                Id = b.Id,
                Title = b.Title,
                Pages = b.Pages,
                ISBN = b.ISBN,
                FrontCoverImageUrl = b.FrontCoverImageUrl,
                GenreId = b.GenreId,
                Genre = b.Genre,
                AuthorId = b.AuthorId,
                Author = b.Author
            }).Where(b => b.Id == id).SingleOrDefault();
            return book;
        }

        public BookDetailsViewModel GetDetailsForBook(Guid id)
        {
            var book = this.repository.GetAll().Include(b => b.Genre).Include(b => b.Author).Select(b => new BookDetailsViewModel
            {
                Id = b.Id,
                Title = b.Title,
                Pages = b.Pages,
                ISBN = b.ISBN,
                FrontCoverImageUrl = b.FrontCoverImageUrl,
                GenreId = b.GenreId,
                Genre = b.Genre,
                AuthorId = b.AuthorId,
                Author = b.Author
            }).Where(b => b.Id == id).SingleOrDefault();
            return book;
        }
    }
}
