using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using ReviewPoint.Business.Services.Interfaces;
using ReviewPoint.Business.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReviewPoint.Web.Controllers
{
    public class BooksController : Controller
    {
        private readonly IBookService bookService;
        private readonly IGenreService genreService;
        private readonly IAuthorService authorService;
        private readonly IReviewService reviewService;

        public BooksController(IBookService bookService, IGenreService genreService, IAuthorService authorService, IReviewService reviewService)
        {
            this.bookService = bookService;
            this.genreService = genreService;
            this.authorService = authorService;
            this.reviewService = reviewService;
        }

        [HttpGet]
        [Authorize(Roles = "Administrator")]
        public ActionResult Create()
        {
            ViewData["GenreId"] = new SelectList(this.genreService.GetGenres(), "Id", "Name");
            ViewData["AuthorId"] = new SelectList(this.authorService.GetAuthors(), "Id", "Name");
            return View();
        }

        [HttpPost]
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> Create(BookViewModel bookViewModel)
        {
            await this.bookService.Create(bookViewModel);
            return RedirectToAction(nameof(this.Index));
        }

        [HttpGet]
        public IActionResult Index()
        {
            var books =  this.bookService.GetAllBooks();
            return View(books);
        }

        [HttpGet]
        public IActionResult Details(Guid id)
        {
            var book = this.bookService.GetDetailsForBook(id);
            book.Reviews = this.reviewService.GetReviewsForBook(id);
            return View(book);
        }

        [HttpGet]
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> Delete(Guid id)
        {
            await this.bookService.Delete(id);
            return RedirectToAction(nameof(this.Index));
        }

        [HttpGet]
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> Edit(Guid id)
        {
            var book = await this.bookService.GetByIdAsync(id);
            ViewData["GenreId"] = new SelectList(this.genreService.GetGenres(), "Id", "Name");
            ViewData["AuthorId"] = new SelectList(this.authorService.GetAuthors(), "Id", "Name");

            return View(book);
        }

        [HttpPost]
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> Edit(BookViewModel bookViewModel)
        {
            await this.bookService.Update(bookViewModel);
            return RedirectToAction(nameof(this.Index));
        }
    }
}
