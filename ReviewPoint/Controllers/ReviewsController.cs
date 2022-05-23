using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using ReviewPoint.Business.Services.Interfaces;
using ReviewPoint.Business.ViewModels;
using ReviewPoint.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReviewPoint.Web.Controllers
{
    public class ReviewsController : Controller
    {
        private readonly IBookService bookService;
        private readonly IReviewService reviewService;
        private readonly UserManager<User> userManager;

        public ReviewsController(IReviewService reviewService, IBookService bookService, UserManager<User> userManager)
        {
            this.reviewService = reviewService;
            this.bookService = bookService;
            this.userManager = userManager;
        }

        [HttpGet]
        [Authorize]
        public ActionResult Create()
        {
            ViewData["BookId"] = new SelectList(this.bookService.GetAllBooks(), "Id", "Title");
            return View();
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Create(ReviewViewModel reviewViewModel)
        {
            reviewViewModel.UserId = this.userManager.GetUserId(User);
            await this.reviewService.Create(reviewViewModel);
            return RedirectToAction("Index", "Books");
        }

        [HttpGet]
        public IActionResult Index()
        {
            var reviews = this.reviewService.GetAllReviews();
            return View(reviews);
        }

        [HttpGet]
        public IActionResult Details(Guid id)
        {
            var review = this.reviewService.GetReview(id);
            return View(review);
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> Delete(Guid id)
        {
            await this.reviewService.Delete(id);
            return RedirectToAction("Index", "Books");
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> Edit(Guid id)
        {
            var review = await this.reviewService.GetByIdAsync(id);
            ViewData["BookId"] = new SelectList(this.bookService.GetAllBooks(), "Id", "Title");

            return View(review);
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Edit(ReviewViewModel reviewViewModel)
        {
            reviewViewModel.UserId = this.userManager.GetUserId(User);
            await this.reviewService.Update(reviewViewModel);
            return RedirectToAction("Index", "Books");
        }
    }
}
